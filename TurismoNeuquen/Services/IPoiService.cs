using System.Collections.Generic;
using TurismoNeuquen.Models;

namespace TurismoNeuquen.Services
{
    public interface IPoiService
    {
        IEnumerable<PointOfInterest> GetConfirmedPOIs();
        PointOfInterest GetPOI(int id);

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