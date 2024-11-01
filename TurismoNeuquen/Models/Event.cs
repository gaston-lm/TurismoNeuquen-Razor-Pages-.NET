namespace TurismoNeuquen.Models
{
    public class Event : PointOfInterest
    {
        public DateTime EventDate { get; set; }
        public string Location { get; set; } = string.Empty;

        public static Event Create(string name, string description, double latitude, double longitude, DateTime eventDate, string location)
        {
            return new Event
            {
                Name = name,
                Description = description,
                Latitude = latitude,
                Longitude = longitude,
                State = false,
                EventDate = eventDate,
                Location = location
            };
        }
    }
}
