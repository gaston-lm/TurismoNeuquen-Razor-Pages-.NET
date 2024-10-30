namespace TurismoNeuquen.Models;

public class Event : PointOfInterest
{
    public DateTime EventDate { get; set; }
    public string Location { get; set; } = string.Empty;
}