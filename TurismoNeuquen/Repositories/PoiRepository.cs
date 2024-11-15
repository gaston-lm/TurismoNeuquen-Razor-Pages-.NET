using TurismoNeuquen.Data;
using TurismoNeuquen.Models;

namespace TurismoNeuquen.Repositories
{
    public class PoiRepository : IPoiRepository
    {
        private readonly dataContext _dataContext;
        public PoiRepository(dataContext dataContext)
        {
            _dataContext = dataContext;
            _dataContext.Database.EnsureCreated();
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

            _dataContext.PointsOfInterest.Add(poi);
            _dataContext.SaveChanges();
        }

        public void Confirm(int poiId)
        {
            var existingPOI = _dataContext.PointsOfInterest.Find(poiId);

            if (existingPOI != null)
            {
                // Update the properties you want to change
                existingPOI.State = true;

                // Save the changes to the database
                _dataContext.SaveChanges();
            }
            else
            {
                throw new Exception("Point of Interest not found.");
            }
        }

        public void DeletePOI(int poiId)
        {
            var poiToDelete = _dataContext.PointsOfInterest.Find(poiId);

            if (poiToDelete != null)
            {
                // Remove the object from the context
                _dataContext.PointsOfInterest.Remove(poiToDelete);

                // Save changes to commit the deletion
                _dataContext.SaveChanges();
            }
            else
            {
                throw new Exception("Point of Interest not found.");
            }
        }

        public PointOfInterest GetPOI(int id)
        {
            return _dataContext.PointsOfInterest.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<PointOfInterest> GetPOIs(bool state)
        {
            return _dataContext.PointsOfInterest.Where(x => x.State == state);
        }
    }
}
