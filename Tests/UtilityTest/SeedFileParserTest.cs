using System;

using Utility;
using Model;

namespace UtilityTest;

/// <summary>
/// Represents the test class the ensures the seed file parser is working properly.
/// Also includes sample seed files with both valid and invalid entries for testing purposes.
/// </summary>
public class SeedFileParserTest
{
    // Initialize the file paths and return values;
    public readonly string allValidSeedFilePath = "../../../SampleSeedFiles/sample_seeds_all_valid.txt";
    public readonly string someInvalidSeedFilePath = "../../../SampleSeedFiles/sample_seeds_some_invalid.txt";
    public readonly string someDuplicatesSeedFilePath = "../../../SampleSeedFiles/sample_seeds_has_duplicate.txt";
    public readonly string nonExistentFilePath = "../../../SampleSeedFiles/not_exists.txt";
    public Pair<List<SeedEntry>, Pair<int, int>> allValidReturn;
    public Pair<List<SeedEntry>, Pair<int, int>> someInvalidReturn;
    public Pair<List<SeedEntry>, Pair<int, int>> someDuplicatesReturn;

    // Tests the fully valid sample seed  seeds file
    [Test]
    public async Task FullyValidParseTest()
    {
        allValidReturn = await SeedFileParser.ParseSeedFile(allValidSeedFilePath);

        Assert.That(allValidReturn.Second.First, Is.EqualTo(0));
        Assert.That(allValidReturn.Second.Second, Is.EqualTo(0));
        Assert.That(allValidReturn.First.Count, Is.EqualTo(4));
        Assert.That(allValidReturn.First[0].GetSerialNumber(), Is.EqualTo("862503025416"));
        Assert.That(allValidReturn.First[0].GetSeed(), Is.EqualTo("AE7AB67157F90B1935B8E7979BAE30FB8C6EA5E5"));
        Assert.That(allValidReturn.First[1].GetSerialNumber(), Is.EqualTo("123456789012"));
        Assert.That(allValidReturn.First[1].GetSeed(), Is.EqualTo("1234567890ABCDEF1234567890ABCDEF12345678"));
        Assert.That(allValidReturn.First[2].GetSerialNumber(), Is.EqualTo("987654321098"));
        Assert.That(allValidReturn.First[2].GetSeed(), Is.EqualTo("FEDCBA0987654321FEDCBA0987654321FEDCBA09"));
        Assert.That(allValidReturn.First[3].GetSerialNumber(), Is.EqualTo("FTK21041KN07"));
        Assert.That(allValidReturn.First[3].GetSeed(), Is.EqualTo("A7C3F9D2084E6B1A9D5F27C0E38B64F1C5A0D972BE4168FA3C7E1B5D9024F6A8A7C3F9D2084E6B1A9D5F27C0E38B64F1C5A0D972BE4168FA3C7E1B5D9024F6A8"));
    }

    // Tests the partially 
    [Test]
    public async Task SomeInvalidParseTest()
    {
        someInvalidReturn = await SeedFileParser.ParseSeedFile(someInvalidSeedFilePath); 

        Assert.That(someInvalidReturn.Second.First, Is.EqualTo(8));
        Assert.That(someInvalidReturn.Second.Second, Is.EqualTo(0));
        Assert.That(someInvalidReturn.First.Count, Is.EqualTo(3));

        Assert.That(someInvalidReturn.First[0].GetSerialNumber(), Is.EqualTo("862503025416"));
        Assert.That(someInvalidReturn.First[0].GetSeed(), Is.EqualTo("AE7AB67157F90B1935B8E7979BAE30FB8C6EA5E5"));
        Assert.That(someInvalidReturn.First[1].GetSerialNumber(), Is.EqualTo("111111111111"));
        Assert.That(someInvalidReturn.First[1].GetSeed(), Is.EqualTo("1111111111ABCDEF1234567890ABCDEF12345678"));
        Assert.That(someInvalidReturn.First[2].GetSerialNumber(), Is.EqualTo("FTK21041KN07"));
        Assert.That(someInvalidReturn.First[2].GetSeed(), Is.EqualTo("A7C3F9D2084E6B1A9D5F27C0E38B64F1C5A0D972BE4168FA3C7E1B5D9024F6A8A7C3F9D2084E6B1A9D5F27C0E38B64F1C5A0D972BE4168FA3C7E1B5D9024F6A8"));
    }

    // Tests a file with a bunch of duplicates
    [Test]
    public async Task SomeDuplicatesTest()
    {
        someDuplicatesReturn = await SeedFileParser.ParseSeedFile(someDuplicatesSeedFilePath);

        Assert.That(someDuplicatesReturn.Second.First, Is.EqualTo(0));
        Assert.That(someDuplicatesReturn.Second.Second, Is.EqualTo(2));
        Assert.That(someDuplicatesReturn.First.Count, Is.EqualTo(2));

        Assert.That(someDuplicatesReturn.First[0].GetSerialNumber(), Is.EqualTo("862503025416"));
        Assert.That(someDuplicatesReturn.First[0].GetSeed(), Is.EqualTo("AE7AB67157F90B1935B8E7979BAE30FB8C6EA5E5"));
        Assert.That(someDuplicatesReturn.First[1].GetSerialNumber(), Is.EqualTo("223456789012"));
        Assert.That(someDuplicatesReturn.First[1].GetSeed(), Is.EqualTo("1234567890ABC3EF1234567890ABCDEF12345678"));

    }

    // Tests a seed files that does not exists to make sure it throws exception
    [Test]
    public async Task FileDoesNotExistTest()
    {
        try
        {
            await SeedFileParser.ParseSeedFile(nonExistentFilePath);
            Assert.Fail();
        } catch (FileNotFoundException)
        {

        }
    }
    
}
