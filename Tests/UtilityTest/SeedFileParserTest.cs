using System;

using Utility;
using Model;

namespace UtilityTest;

// Represents the test class the ensures the seed file parser is working properly
public class SeedFileParserTest
{
    // Initialize the file paths and return values;
    public readonly string allValidSeedFilePath = "../../SampleSeedFiles/sample_seeds_all_valid.txt";
    public readonly string someInvalidSeedFilePath = "../../SampleSeedFiles/sample_seeds_some_invalid.txt";
    public readonly string nonExistentFilePath = "../../SampleSeedFiles/not_exists.txt";
    public Pair<List<SeedEntry>, int> allValidReturn;
    public Pair<List<SeedEntry>, int> someInvalidReturn;

    // Tests the fully valid samplewhat ha seeds file
    [Test]
    public async Task FullyValidParseTest()
    {
        allValidReturn = await SeedFileParser.ParseSeedFile(allValidSeedFilePath);

        Assert.That(allValidReturn.Second, Is.EqualTo(0));
        Assert.That(allValidReturn.First.Count, Is.EqualTo(3));
        Assert.That(allValidReturn.First[0].GetSerialNumber(), Is.EqualTo("862503025416"));
        Assert.That(allValidReturn.First[0].GetSeed(), Is.EqualTo("AE7AB67157F90B1935B8E7979BAE30FB8C6EA5E5"));
        Assert.That(allValidReturn.First[1].GetSerialNumber(), Is.EqualTo("123456789012"));
        Assert.That(allValidReturn.First[1].GetSeed(), Is.EqualTo("1234567890ABCDEF1234567890ABCDEF12345678"));
        Assert.That(allValidReturn.First[2].GetSerialNumber(), Is.EqualTo("987654321098"));
        Assert.That(allValidReturn.First[2].GetSeed(), Is.EqualTo("FEDCBA0987654321FEDCBA0987654321FEDCBA09"));
    }

    // Tests the partly invalid file path
    [Test]
    public async Task SomeInvalidParseTest()
    {
        someInvalidReturn = await SeedFileParser.ParseSeedFile(someInvalidSeedFilePath); 

        Assert.That(someInvalidReturn.Second, Is.EqualTo(4));
        Assert.That(someInvalidReturn.First.Count, Is.EqualTo(2));

        Assert.That(someInvalidReturn.First[0].GetSerialNumber(), Is.EqualTo("862503025416"));
        Assert.That(someInvalidReturn.First[0].GetSeed(), Is.EqualTo("AE7AB67157F90B1935B8E7979BAE30FB8C6EA5E5"));
        Assert.That(someInvalidReturn.First[1].GetSerialNumber(), Is.EqualTo("111111111111"));
        Assert.That(someInvalidReturn.First[1].GetSeed(), Is.EqualTo("1111111111ABCDEF1234567890ABCDEF12345678"));
    }
    
}
