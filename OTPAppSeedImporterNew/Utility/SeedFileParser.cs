using Model;
using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Utility;

/// <summary>
/// Static seed file parser class that cannot be instantiated, but is used as a tool
/// </summary>
public static class SeedFileParser
{
    /// <summary>
    /// Parses the seed file, and returns a list of seed entries and the number of invalid entries
    /// Potentially throws the following exceptions:
    /// - IO Exception: the file cannot be read
    /// - FileNotFoundException: the filepath cannot be found
    /// </summary>
    /// <returns>List of seed entries</returns>
    public static async Task<Pair<List<SeedEntry>, Pair<int, int>>> ParseSeedFile(string filePath) 
    {
        // Instantiate the seed entry array list and invalid entries accumulator, then get all lines of the filepath
        List<SeedEntry> seedEntries = new List<SeedEntry>();

        string[] lines = await File.ReadAllLinesAsync(filePath);
        int noInvalid = 0;
        int noDuplicates = 0;
        foreach (string line in lines)
        {
            string[] value = line.Split(',');

            // Only parse valid entries with valid serial number and seed formats. If the line is invalid, then skip it. 
            // Valid: - Two entries (Serial Number, Seed)
            //        - Serial Number must be 0-9
            //        - Seed must be 0-9a-fA-F
            //        - Seed must be between 20-64 characters long
            //        - Seed must be an even number
            bool valid = value.Length == 2 && Regex.IsMatch(value[0], @"^\d+$") && Regex.IsMatch(value[1], @"^[0-9a-f]+$", RegexOptions.IgnoreCase) &&
                value[1].Length >= 20 && value[1].Length <= 64 && value[1].Length % 2 == 0;
            if (!valid)
            {
                noInvalid++;
                continue;
            }

            // Checks if there are duplicate serial numbers.
            bool isDuplicate = false;
            foreach (SeedEntry seedEntry in seedEntries)
            {
                if (seedEntry.GetSerialNumber() == value[0])
                {
                    isDuplicate = true;
                    noDuplicates++;
                    break;
                }
            }

            if (!isDuplicate) seedEntries.Add(new SeedEntry(value[0], value[1]));

        }
        return new Pair<List<SeedEntry>, Pair<int, int>>(seedEntries, new Pair<int, int>(noInvalid, noDuplicates));
    }
}

