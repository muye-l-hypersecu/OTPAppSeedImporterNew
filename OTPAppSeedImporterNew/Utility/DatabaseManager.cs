using System;

namespace Utility;

// Manages imports and connections to database. 
public class DatabaseManager
{

	// EFFECT: Initializes database
	public static void InitializeDatabase(string dbPath)
	{

	}

	// EFFECT: Inserts the seed entries into database
	// RETURNS: a number of seed entries inserted
	public static int InsertSeedEntries(string dbPath, List<SeedEntry> entries, string specId)
	{
		return 0;
	}


	// EFFECT: Checks for duplicates in serial numbers
	// RETURNS: a list of duplicate serial numbers
	public static List<string> CheckForDuplicates(string dbPath, List<seedEntry> entries)
	{
		return new List<string>();
	}
}
