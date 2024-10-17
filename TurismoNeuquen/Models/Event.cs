namespace TurismoNeuquen.Models;

public class Event : PointOfInterest
{
    public DateTime EventDateBegin { get; set; }
    public DateTime EventDateEnd { get; set; }

    // Constructor
    public Event(
        string name,
        string description,
        double latitude,
        double longitude,
        DateTime eventDateBegin,
        DateTime eventDateEnd
    ) : base(name, description, latitude, longitude)
    {
        EventDateBegin = eventDateBegin;
        EventDateEnd = eventDateEnd;
    }
}