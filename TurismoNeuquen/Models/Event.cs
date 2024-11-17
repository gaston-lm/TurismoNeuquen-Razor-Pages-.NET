namespace TurismoNeuquen.Models
{
    public class Event : PointOfInterest
    {
        public DateTime EventDate { get; set; }

        public static Event Create(string name, string description, double latitude, double longitude, string imagename, DateTime eventDate, int? UserId)
        {
            return new Event
            {
                Name = name,
                Description = description,
                Latitude = latitude,
                Longitude = longitude,
                State = false,
                ImageName = imagename,
                UserId = UserId,
                EventDate = eventDate,
            };
        }
    }
}
