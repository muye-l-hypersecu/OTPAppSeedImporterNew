using System;
using Model;

namespace ModelTest;

// Tests out the Spec Type Enum Function
public class SpecTypeTest
{

    // Tests out the enum to string converter function.
    [Test]
    public void ToSpecIdTest()
    {
        Assert.That(SpecTypeExtensions.ToSpecId(SpecType.TOTP30), Is.EqualTo("TOTP30"));
        Assert.That(SpecTypeExtensions.ToSpecId(SpecType.TOTP60), Is.EqualTo("TOTP60"));
        Assert.That(SpecTypeExtensions.ToSpecId(SpecType.HOTP), Is.EqualTo("HOTP"));
    }
}