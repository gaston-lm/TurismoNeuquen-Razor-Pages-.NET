namespace TurismoNeuquen.Models;
public abstract class PointOfInterest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool State { get; set; }
    public string ImageName { get; set; } = string.Empty;
    public int? UserId { get; set; }
}