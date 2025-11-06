using Utility;
using Model;
using System.Data.SQLite;
using System.Data;

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

    // Deletes all the tuples from the tokenInfo table to ensure that the tests are re-runnable
    [SetUp]
    public void SetUp()
    {
        ClearTokenInfoTable();
    }
    
    // Tests the initialization of the database, including whether or not to throw error
    [Test]
    public void InitializeDatabaseTest()
    {
        // Should successfully initialize an empty table
        try
        {
            DatabaseManager.InitializeDatabase(sampleDbWithoutTablesFilePath);
            Assert.IsTrue(DatabaseProperlyInstantiated(sampleDbWithoutTablesFilePath));

            // Check to see that the ft_tokenspec table is initialized properly
            using var connCheck = new SQLiteConnection($"Data Source={sampleDbWithoutTablesFilePath}");
            connCheck.Open();
            string sqlCheck = "SELECT COUNT(*) FROM ft_tokenspec;";
            using var cmdCheck = new SQLiteCommand(sqlCheck, connCheck);

            Assert.That(Convert.ToInt32(cmdCheck.ExecuteScalar()), Is.EqualTo(3));

            // Delete the tables to ensure that the test can run consecutively

            using var connDelete = new SQLiteConnection($"Data Source={sampleDbWithoutTablesFilePath}");
            connDelete.Open();
            string sqlTokenSpecDelete = "DROP TABLE ft_tokenspec;";
            using var tokenSpecDelete = new SQLiteCommand(sqlTokenSpecDelete, connDelete);
            tokenSpecDelete.ExecuteNonQuery();
            string sqlTokenInfoDelete = "DROP TABLE ft_tokeninfo;";
            using var tokenInfoDelete = new SQLiteCommand(sqlTokenInfoDelete, connDelete);
            tokenInfoDelete.ExecuteNonQuery();
            
        } catch (FileNotFoundException)
        {
            Assert.Fail();
        }

        // Should successfully keep database untouched since the tables already exist
        try
        {
            DatabaseManager.InitializeDatabase(sampleDBWithTablesFilePath);
            Assert.IsTrue(DatabaseProperlyInstantiated(sampleDBWithTablesFilePath));

            using var connCheck = new SQLiteConnection($"Data Source={sampleDBWithTablesFilePath}");
            connCheck.Open();
            string sqlCheck = "SELECT COUNT(*) FROM ft_tokenspec;";
            using var cmdCheck = new SQLiteCommand(sqlCheck, connCheck);

            Assert.That(Convert.ToInt32(cmdCheck.ExecuteScalar()), Is.EqualTo(3));
        }
        catch (FileNotFoundException)
        {
            Assert.Fail();
        }

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

    // Tests the function that inserts the seed entries into the database
    [Test]
    public async Task InsertSeedEntriesTest()
    {
        string seedFilePath = "../../../SampleSeedFiles/sample_seeds_all_valid.txt";
        Pair<List<SeedEntry>, Pair<int, int>> entries = await SeedFileParser.ParseSeedFile(seedFilePath);

        // Should successfully insert 4 rows into the tokenInfo table
        try
        {
            int numberInserted = DatabaseManager.InsertSeedEntries(sampleDBWithTablesFilePath, entries.First, SpecTypeExtensions.ToSpecId(SpecType.TOTP30));
            Assert.That(numberInserted, Is.EqualTo(4));
        }
        catch (InvalidOperationException)
        {
            Assert.Fail();
        }

        // Should fail because specType does not exist
        try
        {
            DatabaseManager.InsertSeedEntries(sampleDBWithTablesFilePath, entries.First, "TOTP15");
            Assert.Fail();
        }
        catch (InvalidOperationException e)
        {
            Assert.That(e.Message, Is.EqualTo($"The selected spec ID 'TOTP15' does not exist in the tokenspec table."));
        }


    }

    // Tests the function that checks for duplicates
    [Test] 
    public async Task CheckForDuplicatesTest()
    {
        // There should be one duplicate
        string seedFilePath = "../../../SampleSeedFiles/sample_seeds_all_valid.txt";
        string duplicateSeedFilePath = "../../../SampleSeedFiles/sample_seeds_has_duplicate.txt";
        Pair <List<SeedEntry>, Pair<int, int>> originalEntries = await SeedFileParser.ParseSeedFile(seedFilePath);
        Pair<List<SeedEntry>, Pair<int, int>> newEntries = await SeedFileParser.ParseSeedFile(duplicateSeedFilePath);

        DatabaseManager.InsertSeedEntries(sampleDBWithTablesFilePath, originalEntries.First, SpecTypeExtensions.ToSpecId(SpecType.TOTP30));
        List<string> duplicateList = DatabaseManager.CheckForDuplicates(sampleDBWithTablesFilePath, newEntries.First);
        Assert.That(duplicateList.Count, Is.EqualTo(1));
        Assert.That(duplicateList[0], Is.EqualTo("862503025416"));
    }

    ///// HELPER FUNCTIONS /////

    /// <summary>
    /// Verifies .db file to ensure that tables are properly initialized
    /// </summary>
    private bool DatabaseProperlyInstantiated(string dbPath)
    {
        using var connection = new SQLiteConnection($"Data Source={dbPath}");
        connection.Open();

        string[] requiredTables = { "ft_tokenspec", "ft_tokeninfo" };

        foreach (string requiredTable in requiredTables)
        {
            string sql = "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name=@tableName";

            using var cmd = new SQLiteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@tableName", requiredTable);

            object result = cmd.ExecuteScalar();

            if (Convert.ToInt32(result) != 1) return false;

        }

        return true;
        
    }

    /// <summary>
    /// Clears the tokenInfo table so that the tests are re-runnable
    /// </summary>
    private void ClearTokenInfoTable()
    {
        string sqlDelete = "DELETE FROM ft_tokeninfo;";
        using var connDelete = new SQLiteConnection($"Data Source={sampleDBWithTablesFilePath}");
        connDelete.Open();
        using var cmdDelete = connDelete.CreateCommand();
        cmdDelete.CommandText = sqlDelete;
        cmdDelete.ExecuteNonQuery();
    }
}