using System;
using System.Data.SQLite;
using System.Data.SqlTypes;
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
		try
		{
            using var sqLiteCmd = new SQLiteCommand(sql, connection);
            sqLiteCmd.ExecuteNonQuery();
        } catch (Exception ex)
		{
			throw new InvalidOperationException("Unable to execute SQL tables.\n" + ex.Message);
		}
		
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
            throw new InvalidOperationException("Unable to open database.");
        }

        // checks that the provided specId exists
        bool specExists = IsValidSpecId(connection, specId);
		if (!specExists)
		{
			throw new InvalidOperationException($"The selected spec ID '{specId}' does not exist in the tokenspec table.");
		}

		// prepares for insertion
		using var command = connection.CreateCommand();
		command.CommandText = @"INSERT INTO ft_tokeninfo (serialNumber, seed, specId) " +
                            "VALUES (@serialNumber, @seed, @specId)";

		int numberEntries = 0;
        // inserts entries
        foreach (var entry in entries)
		{
			numberEntries++;
			command.Parameters.Clear();
            command.Parameters.AddWithValue("@serialNumber", entry.GetSerialNumber());
            command.Parameters.AddWithValue("@seed", entry.GetSeed());
            command.Parameters.AddWithValue("@specId", specId);

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
		command.CommandText = "SELECT serialNumber FROM ft_tokeninfo WHERE serialNumber = @serialNumber";
		var tokenParam = command.Parameters.Add("@serialNumber", System.Data.DbType.String);

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
}
