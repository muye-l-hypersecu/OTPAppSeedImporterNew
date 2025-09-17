using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;

// Represents the class that stores the spec information
public enum SpecType
{
    TOTP30,
    TOTP60,
    HOTP
}

public static class SpecTypeExtensions
{
    public static string ToSpecId(this SpecType specType)
    {
        return specType.ToString();
    }
}


