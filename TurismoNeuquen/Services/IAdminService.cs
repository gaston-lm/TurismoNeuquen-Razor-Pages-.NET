using TurismoNeuquen.Models;

namespace TurismoNeuquen.Services
{
    public interface IAdminService
    {
        IEnumerable<PointOfInterest> GetPOIs();
        void Confirm(int poiId);
        void DeletePOI(PointOfInterest poi);
    }
}
