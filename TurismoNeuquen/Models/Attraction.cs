namespace TurismoNeuquen.Models;

public class Attraction : PointOfInterest
{
    public List<string>? OpenDays { get; set; }
    public TimeOnly? OpeningTime { get; set; }
    public TimeOnly? ClosingTime { get; set; }
}