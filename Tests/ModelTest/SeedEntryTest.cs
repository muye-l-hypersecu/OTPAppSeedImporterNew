using Model;

namespace ModelTest;

// Represents the test class for the seed entry class
public class SeedEntryTest
{
    public SeedEntry seedEntry;

    // Sets up a seed entry
    [SetUp]
    public void SetUp()
    {
        seedEntry = new SeedEntry("2345823858", "AFECD15568716589DF7279865");
    }

    // Tests to make sure the instances are set up properly
    [Test]
    public void SetUpTest()
    {
        Assert.That(seedEntry.GetSerialNumber(), Is.EqualTo("2345823858"));
        Assert.That(seedEntry.GetSeed(), Is.EqualTo("AFECD15568716589DF7279865"));
    }
}

