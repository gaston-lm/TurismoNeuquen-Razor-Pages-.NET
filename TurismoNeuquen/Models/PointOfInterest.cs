namespace TurismoNeuquen.Models;
public class PointOfInterest(
    string name,
    string description,
    double latitude,
    double longitude,
    List<string>? openDays,
    TimeOnly? openingTime,
    TimeOnly? closingTime)
    : Attraction(name, description, latitude, longitude)
{
    public List<string>? OpenDays { get; set; } = openDays;
    public TimeOnly? OpeningTime { get; set; } = openingTime;
    public TimeOnly? ClosingTime { get; set; } = closingTime;
}