using System.Collections.Generic;
using TurismoNeuquen.Models;

namespace TurismoNeuquen.Services
{
    public interface IPoiService
    {
        IEnumerable<PointOfInterest> GetPOIs();
        PointOfInterest GetPOI(int id);
        void UpdatePOI(PointOfInterest poi);
        void DeletePOI(PointOfInterest poi);
        void AddPoi(string poiType, string name, string description, double latitude, double longitude, string ImageName,
            DateTime? eventDate = null, string? location = null,
            string? openDays = null, TimeOnly? openingTime = null, TimeOnly? closingTime = null);
    }
}