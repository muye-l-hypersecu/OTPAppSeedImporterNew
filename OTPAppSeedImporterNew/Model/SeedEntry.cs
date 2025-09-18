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
}
