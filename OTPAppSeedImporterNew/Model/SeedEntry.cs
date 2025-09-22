using System;

namespace Model;

// Represents the class that stores the seed information
public class SeedEntry
{
    // Serial number and seed (public key) fields
    private readonly string serialNumber, seed;

    // Constructor with custom serial number and seed setters
    public SeedEntry(string serialNumber, string seed)
    {
        this.serialNumber = serialNumber;
        this.seed = seed;
    }

    // Getters

    public string GetSerialNumber() { return serialNumber; }
    public string GetSeed() { return seed; }

    public override bool Equals(object obj)
    {
        if (obj is SeedEntry other)
        {
            return this.serialNumber == other.serialNumber && this.seed == other.seed;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(serialNumber, seed);
    }
}
