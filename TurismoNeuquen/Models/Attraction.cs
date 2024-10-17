namespace TurismoNeuquen.Models;

public class Attraction : PointOfInterest
{
    public List<string>? OpenDays { get; set; }
    public TimeOnly? OpeningTime { get; set; }
    public TimeOnly? ClosingTime { get; set; }

    // Constructor
    public Attraction(
        string name,
        string description,
        double latitude,
        double longitude,
        List<string>? openDays = null,
        TimeOnly? openingTime = null,
        TimeOnly? closingTime = null
    ) : base(name, description, latitude, longitude)
    {
        OpenDays = openDays;
        OpeningTime = openingTime;
        ClosingTime = closingTime;
    }
}