namespace TurismoNeuquen.Models;

public class Attraction(string name, string description, double latitude, double longitude)
{
    public int Id { get; set; }
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public double Latitude { get; set; } = latitude;
    public double Longitude { get; set; } = longitude;
    public bool State { get; set; } = false; // Default value
}