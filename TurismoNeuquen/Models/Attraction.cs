namespace TurismoNeuquen.Models
{
    public class Attraction : PointOfInterest
    {
        public string? OpenDays { get; set; }
        public TimeOnly? OpeningTime { get; set; }
        public TimeOnly? ClosingTime { get; set; }

        public static Attraction Create(string name, string description, double latitude, double longitude, string imagename, string? openDays = null, TimeOnly? openingTime = null, TimeOnly? closingTime = null)
        {
            return new Attraction
            {
                Name = name,
                Description = description,
                Latitude = latitude,
                Longitude = longitude,
                ImageName = imagename,
                State = false,
                OpenDays = openDays,
                OpeningTime = openingTime,
                ClosingTime = closingTime
            };
        }
    }
}
