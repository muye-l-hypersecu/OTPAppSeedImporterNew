using Model;
using System;
using System.Collections;

namespace Utility;

/// <summary>
/// Static seed file parser class that cannot be instantiated, but is used as a tool
/// </summary>
public static class SeedFileParser
{
    /// <summary>
    /// Parses the seed file, and returns a list of seed entries
    /// Potentially throws the following exceptions:
    /// - IO Exception: the file cannot be read
    /// - FileNotFoundException: the filepath cannot be found
    /// </summary>
    /// <returns>List of seed entries</returns>
    public static List<SeedEntry> ParseSeedFile() 
    {
        // Instantiate the seed entry array list, then get all lines of the filepath
        List<SeedEntry> seedEntries = new List<SeedEntry>();

        return seedEntries;
    }
}

