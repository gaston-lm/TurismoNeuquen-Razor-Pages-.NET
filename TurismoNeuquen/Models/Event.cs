namespace TurismoNeuquen.Models
{
    public class Event : PointOfInterest
    {
        public DateTime EventDate { get; set; }
        public string Location { get; set; } = string.Empty;

        public static Event Create(string name, string description, double latitude, double longitude,string imagename, DateTime eventDate)
        {
            return new Event
            {
                Name = name,
                Description = description,
                Latitude = latitude,
                Longitude = longitude,
                ImageName = imagename,
                State = false,
                EventDate = eventDate
            };
        }
    }
}
