namespace ModelTest;

using Model;
using NUnit.Framework;

public class PairTest
{
    public Pair<string, int> testPair1;
    public Pair<List<string>, int> testPair2;

    // Sets up the 2 pairs that we want to test each time
    [SetUp]
    public void Setup()
    {
        testPair1 = new Pair<string, int>("test string", 1);
        testPair2 = new Pair<List<string>, int>(new List<string>(), 1);
    }

    // Reference test, makes sure the values are instantiated properly
    [Test]
    public void ReferenceTest()
    {
        Assert.That(testPair1.First, Is.EqualTo("test string"));
        Assert.That(testPair1.Second, Is.EqualTo(1));
        Assert.That(testPair2.First.Count, Is.EqualTo(0));
        Assert.That(testPair2.Second, Is.EqualTo(1));
    }

    // Modify test, makes sure the values are modifiable
    [Test]
    public void ModifyTest()
    {
        // Modify
        testPair1.First = "test string modified";
        testPair1.Second = 0;
        for (int i = 0; i < 5; i++) testPair2.First.Add("item");
        testPair2.Second = 0;

        // Check
        Assert.That(testPair1.First, Is.EqualTo("test string modified"));
        Assert.That(testPair1.Second, Is.EqualTo(0));
        Assert.That(testPair2.First.Count, Is.EqualTo(5));
        Assert.That(testPair2.Second, Is.EqualTo(0));
    }
}
