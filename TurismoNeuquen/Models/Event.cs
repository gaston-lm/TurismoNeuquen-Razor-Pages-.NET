namespace TurismoNeuquen.Models;

public class Event(
    string name,
    string description,
    double latitude,
    double longitude,
    DateTime eventDateBegin,
    DateTime eventDateEnd)
    : Attraction(name, description, latitude, longitude)
{
    public DateTime EventDateBegin { get; set; } = eventDateBegin;
    public DateTime EventDateEnd { get; set; } = eventDateEnd;
}
