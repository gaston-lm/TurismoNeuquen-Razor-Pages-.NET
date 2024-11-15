using TurismoNeuquen.Data;
using TurismoNeuquen.Models;

namespace TurismoNeuquen.Repositories
{
    public class PoiRepository : IPoiRepository
    {
        private readonly PoiContext _poiContext;
        public PoiRepository(PoiContext poiContext)
        {
            _poiContext = poiContext;
            _poiContext.Database.EnsureCreated();
        }
        public void AddPoi(string poiType, string name, string description, double latitude, double longitude, string imagename, DateTime? eventDate = null, string? openDays = null, TimeOnly? openingTime = null, TimeOnly? closingTime = null)
        {
            PointOfInterest poi;

            if (poiType == "attraction")
            {
                poi = Attraction.Create(name, description, latitude, longitude, imagename, openDays, openingTime, closingTime);
            }
            else if (poiType == "event" && eventDate.HasValue)
            {
                poi = Event.Create(name, description, latitude, longitude, imagename, eventDate.Value);
            }
            else
            {
                throw new ArgumentException("Invalid POI type or missing required fields for the type");
            }

            _poiContext.PointsOfInterest.Add(poi);
            _poiContext.SaveChanges();
        }

        public void Confirm(int poiId)
        {
            var existingPOI = _poiContext.PointsOfInterest.Find(poiId);

            if (existingPOI != null)
            {
                // Update the properties you want to change
                existingPOI.State = true;

                // Save the changes to the database
                _poiContext.SaveChanges();
            }
            else
            {
                throw new Exception("Point of Interest not found.");
            }
        }

        public void DeletePOI(int poiId)
        {
            var poiToDelete = _poiContext.PointsOfInterest.Find(poiId);

            if (poiToDelete != null)
            {
                // Remove the object from the context
                _poiContext.PointsOfInterest.Remove(poiToDelete);

                // Save changes to commit the deletion
                _poiContext.SaveChanges();
            }
            else
            {
                throw new Exception("Point of Interest not found.");
            }
        }

        public PointOfInterest GetPOI(int id)
        {
            return _poiContext.PointsOfInterest.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<PointOfInterest> GetPOIs(bool state)
        {
            return _poiContext.PointsOfInterest.Where(x => x.State == state);
        }
    }
}
