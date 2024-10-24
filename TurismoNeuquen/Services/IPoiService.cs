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

        void CreatePOI(PointOfInterest poi);
    }
}