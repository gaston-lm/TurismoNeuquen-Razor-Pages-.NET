namespace TurismoNeuquen.Models;

public class PointOfInterest
{
    private static int _nextId = 1; // Static counter

    public int Id { get; private set; } // Make Id read-only outside the class
    public string Name { get; set; }
    public string Description { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool State { get; set; } = false; // Default value

    // Parameterless constructor required for model binding
    public PointOfInterest()
    {
        Id = _nextId++;
    }

    // Main constructor
    public PointOfInterest(string name, string description, double latitude, double longitude) : this()
    {
        Name = name;
        Description = description;
        Latitude = latitude;
        Longitude = longitude;
    }
}
