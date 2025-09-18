using System;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.Threading.Tasks;
using Model;

namespace Utility;

// Manages imports and connections to database. 
public static class DatabaseManager
{

	// EFFECT: Initializes database
	public static void InitializeDatabase(string dbPath)
	{
		// check if dbPath exists
		if (!File.Exists(dbPath))
		{
			throw new FileNotFoundException($"Database file not found: {dbPath}");
		}

		// connect to database
		using var connection = new SQLiteConnection($"Data Source={dbPath}");
		connection.Open();

		//check if the required tables exist
		string[] requiredTables = { "tokeninfo", "tokenspec" };

		foreach (string table in requiredTables) {
			// sqlite_master is a system table in SQLite that holds information about all objects in the database.
			// @tableName is a parameter you'll pass.
			string sql = "SELECT name FROM sqlite_master WHERE type='table' AND name=@tableName";
			using var cmd = new SQLiteCommand(sql, connection);
			cmd.Parameters.AddWithValue("@tableName", table);
			// runs the SQL and returns the first column of the first row in the result set.
			object result = cmd.ExecuteScalar();
			if (result == null || result == DBNull.Value)
			{
				throw new InvalidOperationException($"Databse is missing required table: {table}");
			}
		}
	}

	// EFFECT: Inserts the seed entries into database
	// RETURNS: a number of seed entries inserted
	public static int InsertSeedEntries(string dbPath, List<SeedEntry> entries, string specId)
	{
		InitializeDatabase(dbPath);

		using var connection = new SQLiteConnection($"Data Source={dbPath}");
		connection.Open();

		// checks that the provided specId exists
        bool specExists = IsValidSpecId(connection, specId);
		if (!specExists)
		{
			throw new InvalidOperationException($"The selected spec ID '{specId}' does not exist in the tokenspec table.");
		}

		// prepares for insertion
		using var command = connection.CreateCommand();
		command.CommandText = @"INSERT INTO tokeninfo (tokenId, serialNumber, seed, specId, importTime) " +
                            "VALUES (@tokenId, @serialNumber, @seed, @specId, @importTime)";

		int tokenId = 1;
		string importTime = DateTime.UtcNow.ToString("o");
        // inserts entries
        foreach (var entry in entries)
		{
			command.Parameters.Clear();
            command.Parameters.AddWithValue("@tokenId", tokenId++);
            command.Parameters.AddWithValue("@serialNumber", entry.GetSerialNumber());
            command.Parameters.AddWithValue("@serialNumber", entry.GetSeed());
            command.Parameters.AddWithValue("@serialNumber", specId);
            command.Parameters.AddWithValue("@serialNumber", importTime);

            // executes SQL commands that do not return a result but modifies data in the database.
            command.ExecuteNonQuery();
			
        }
		return tokenId;
	}


	// EFFECT: Checks for duplicates in serial numbers
	// RETURNS: a list of duplicate serial numbers
	public static List<string> CheckForDuplicates(string dbPath, List<SeedEntry> entries)
	{
		InitializeDatabase(dbPath);
        using var connection = new SQLiteConnection($"Data Source={dbPath}");
        connection.Open();

		var duplicates = new List<string>();

		// A query to check the existing serialNumber
		using var command = connection.CreateCommand();
		command.CommandText = "SELECT serialNumber FROM tokeninfo WHERE serialNumber = @serialNumber";
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
	public static bool IsValidSpecId(SQLiteConnection connection, string specId)
	{
		try
		{
			var cmd = connection.CreateCommand();
			cmd.CommandText = "SELECT COUNT(*) FROM tokenspec WHERE specid = @specid";
			cmd.Parameters.AddWithValue("@specid", specId);

			var count = Convert.ToInt32(cmd.ExecuteScalar());
			return count > 0;
		}
		catch (Exception ex)
		{
            return false;
        }
	}
}
