using Utility;
using Model;
using System.Security.Cryptography.X509Certificates;
using System.Data.SQLite;
using System.Reflection.Metadata.Ecma335;

namespace UtilityTest;

/// <summary>
/// Test class to ensure that the database manager works as intended. Also includes a sample .db file
/// </summary>
public class DatabaseManagerTest
{
    // Load the both an existent and non-existent test.db file
    public string sampleDbWithoutTablesFilePath = "../../../SampleDatabase/sample_db_no_tables.db";
    public string sampleDBWithTablesFilePath = "../../../SampleDatabase/sample_db_with_tables.db";
    public string nonExistentDbFilePath = "../../../SampleDatabase/non_sample_db.db";
    
    // Tests the initialization of the database, including whether or not to throw error
    [Test]
    public void InitializeDatabaseTest()
    {
        // Should successfully initialize an empty table
        try
        {
            DatabaseManager.InitializeDatabase(sampleDbWithoutTablesFilePath);
            Assert.IsTrue(DatabaseProperlyInstantiated(sampleDbWithoutTablesFilePath));
        } catch (FileNotFoundException)
        {
            Assert.Fail();
        }

        // Should successfully handle the process of not modifying a table that has already been initialized

        // Should fail and throw the FileNotFoundException
        try
        {
            DatabaseManager.InitializeDatabase(nonExistentDbFilePath);
            Assert.Fail();
        } catch (FileNotFoundException e)
        {
            Assert.That(e.Message, Is.EqualTo($"Database file not found: {nonExistentDbFilePath}"));
        }
    }

    /// <summary>
    /// Verifies .db file to ensure that tables are properly initialized
    /// </summary>
    private bool DatabaseProperlyInstantiated(string dbPath)
    {
        using var connection = new SQLiteConnection($"Data Source={dbPath}");
        connection.Open();

        string[] requiredTables = { "tokenInfo", "tokenSpec" };

        foreach (string requiredTable in requiredTables)
        {
            string sql = "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name=@tableName";

            using var cmd = new SQLiteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@tableName", requiredTable);

            object result = cmd.ExecuteScalar();

            if (result == null || result == DBNull.Value) return false;

        }

        return true;
        
    }
}