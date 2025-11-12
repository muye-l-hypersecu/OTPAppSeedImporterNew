using System;
using System.Data.SQLite;
using System.Data.SqlTypes;
//using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Model;

namespace Utility;

// Manages imports and connections to database. 
public static class DatabaseManager
{

    // EFFECT: Initializes database, such as creating the tables when it doesn't exist yet. 
    public static void InitializeDatabase(string dbPath)
	{
		// check if dbPath exists
		if (!File.Exists(dbPath))
		{
			throw new FileNotFoundException($"Database file not found: {dbPath}");
		}

		// Get the sql string from the Init.sql file, and then open the database connection
		string sql = File.ReadAllText("Init.sql");
		using var connection = new SQLiteConnection($"Data Source={dbPath}");

		try
		{
			connection.Open();
		}
		catch (Exception ex)
		{
            throw new InvalidOperationException("Unable to open database. Please check the database path.");
        }

		// Execute the sql file
		//try
		//{
  //          using var sqLiteCmd = new SQLiteCommand(sql, connection);
  //          sqLiteCmd.ExecuteNonQuery();
  //      } catch (Exception ex)
		//{
		//	throw new InvalidOperationException("Unable to execute SQL tables.\n" + ex.Message);
		//}
		
	}

	// EFFECT: Inserts the seed entries into database
	// RETURNS: the number of serial numbers inserted
	public static int InsertSeedEntries(string dbPath, List<SeedEntry> entries, string specId)
	{
		InitializeDatabase(dbPath);

		using var connection = new SQLiteConnection($"Data Source={dbPath}");
        try
        {
            connection.Open();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Unable to open database. Please check the database path.");
        }

		// checks if required tables exist
		if (!TablesExist(connection))
		{
			throw new InvalidOperationException("Required tables 'ft_tokeninfo' and/or 'ft_tokenspec' does not exist in the database.");
		}

        // checks that the provided specId exists
        bool specExists = IsValidSpecId(connection, specId);
		if (!specExists)
		{
			throw new InvalidOperationException($"The selected spec type ({specId}) with ID '{specId}' does not exist in the database." +
												$"\nPlease check your database or select a different spec type.");
		}

        using var command = connection.CreateCommand();
        command.CommandText = @"
                INSERT INTO ft_tokeninfo (
                    token, pubkey, authnum, physicaltype, producttype, specid, 
                    importtime, pubkeystate, tknifmid, tknofmid, tkntype, tknstate
                ) VALUES (
                    @token, @pubkey, @authnum, @physicaltype, @producttype, @specid,
                    @importtime, @pubkeystate, @tknifmid, @tknofmid, @tkntype, @tknstate
                )";

		var tokenParam = command.Parameters.Add("@token", System.Data.DbType.String);
        var pubkeyParam = command.Parameters.Add("@pubkey", System.Data.DbType.String);
        var authnumParam = command.Parameters.Add("@authnum", System.Data.DbType.String);
        var physicaltypeParam = command.Parameters.Add("@physicaltype", System.Data.DbType.String);
        var producttypeParam = command.Parameters.Add("@producttype", System.Data.DbType.String);
        var specidParam = command.Parameters.Add("@specid", System.Data.DbType.String);
        var importtimeParam = command.Parameters.Add("@importtime", System.Data.DbType.String);
        var pubkeystateParam = command.Parameters.Add("@pubkeystate", System.Data.DbType.String);
        var tknifmidParam = command.Parameters.Add("@tknifmid", System.Data.DbType.String);
        var tknofmidParam = command.Parameters.Add("@tknofmid", System.Data.DbType.String);
        var tkntypeParam = command.Parameters.Add("@tkntype", System.Data.DbType.String);
        var tknstateParam = command.Parameters.Add("@tknstate", System.Data.DbType.String);

        // Set default values for all entries
        authnumParam.Value = "0";
        physicaltypeParam.Value = 0;
        producttypeParam.Value = 0;
        specidParam.Value = specId;
        importtimeParam.Value = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        pubkeystateParam.Value = 0;
        tknifmidParam.Value = 1;
        tknofmidParam.Value = 1;
        tkntypeParam.Value = 1;
        tknstateParam.Value = 1;

        // prepares for insertion
        //using var command2 = connection.CreateCommand();
		//command.CommandText = @"INSERT INTO ft_tokeninfo (token, pubkey, specid) " +
        //                   "VALUES (@token, @pubkey, @specid)";

		int numberEntries = 0;
        // inserts entries
        foreach (var entry in entries)
		{
			numberEntries++;
			//command.Parameters.Clear();
   //         command.Parameters.AddWithValue("@token", entry.GetSerialNumber());
   //         command.Parameters.AddWithValue("@pubkey", entry.GetSeed());
   //         command.Parameters.AddWithValue("@specid", specId);
			tokenParam.Value = entry.GetSerialNumber();
			pubkeyParam.Value = entry.GetSeed();

            // executes SQL commands that do not return a result but modifies data in the database.
            command.ExecuteNonQuery();
			
        }
		return numberEntries;
	}


	// EFFECT: Checks for duplicates in serial numbers
	// RETURNS: a list of duplicate serial numbers
	public static List<string> CheckForDuplicates(string dbPath, List<SeedEntry> entries)
	{
		InitializeDatabase(dbPath);
        using var connection = new SQLiteConnection($"Data Source={dbPath}");
        try
        {
            connection.Open();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Unable to open database.");
        }

        var duplicates = new List<string>();

		// A query to check the existing serialNumber
		using var command = connection.CreateCommand();
		command.CommandText = "SELECT token FROM ft_tokeninfo WHERE token = @token";
		var tokenParam = command.Parameters.Add("@token", System.Data.DbType.String);

		foreach (var entry in entries)
		{
			tokenParam.Value = entry.GetSerialNumber();
			var result = command.ExecuteScalar();

			// if there is a duplicate
			if (result != null) {
				duplicates.Add(entry.GetSerialNumber());
			}
		}
        return duplicates;
	}


	// EFFECT: Checks if the provided specId is in the table.
	private static bool IsValidSpecId(SQLiteConnection connection, string specId)
	{
		try
		{
			var cmd = connection.CreateCommand();
			cmd.CommandText = "SELECT COUNT(*) FROM ft_tokenspec WHERE specid = @specid";
			cmd.Parameters.AddWithValue("@specid", specId);

			var count = Convert.ToInt32(cmd.ExecuteScalar());
			return count > 0;
		}
		catch
		{
            return false;
        }
	}

	// EFFECT: Checks if required tables exist in the database.
	private static bool TablesExist(SQLiteConnection connection)
	{
        var tableExistsCommand = connection.CreateCommand();
        tableExistsCommand.CommandText = @"
			SELECT COUNT(*) FROM sqlite_master
			WHERE type='table' AND name IN ('ft_tokeninfo', 'ft_tokenspec')";

        var tableCount = Convert.ToInt32(tableExistsCommand.ExecuteScalar());
		return tableCount >= 2;
    }
}
