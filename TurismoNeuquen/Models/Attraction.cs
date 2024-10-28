namespace TurismoNeuquen.Models;

//public class Attraction : PointOfInterest
//{
//    public List<string>? OpenDays { get; set; }
//    public TimeOnly? OpeningTime { get; set; }
//    public TimeOnly? ClosingTime { get; set; }

//    // Parameterless constructor required by the model binder
//    public Attraction()
//    {
//    }

//    // Parameterized constructor
//    public Attraction(
//        string name,
//        string description,
//        double latitude,
//        double longitude,
//        List<string>? openDays = null,
//        TimeOnly? openingTime = null,
//        TimeOnly? closingTime = null
//    ) : base(name, description, latitude, longitude)
//    {
//        OpenDays = openDays;
//        OpeningTime = openingTime;
//        ClosingTime = closingTime;
//    }
//}

public class Attraction : PointOfInterest
{
    public List<string>? OpenDays { get; set; }
    public TimeOnly? OpeningTime { get; set; }
    public TimeOnly? ClosingTime { get; set; }
}