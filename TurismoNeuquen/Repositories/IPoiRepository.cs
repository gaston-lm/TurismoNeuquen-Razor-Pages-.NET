using TurismoNeuquen.Models;

namespace TurismoNeuquen.Repositories
{
    public interface IPoiRepository
    {
        IEnumerable<PointOfInterest> GetPOIs(bool state);
        PointOfInterest GetPOI(int id);
        void Confirm(int poiId);
        void DeletePOI(int poiId);
        void AddPoi(
            string poiType, 
            string name, 
            string description, 
            double latitude, 
            double longitude, 
            string imagename,
            string UserId,
            DateTime? eventDate = null, 
            string? openDays = null, 
            TimeOnly? openingTime = null, 
            TimeOnly? closingTime = null
        );
    }
}
