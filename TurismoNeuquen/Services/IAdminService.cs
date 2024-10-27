using TurismoNeuquen.Models;

namespace TurismoNeuquen.Services
{
    public interface IAdminService
    {
        IEnumerable<PointOfInterest> GetPOIs();
        void UpdatePOI(PointOfInterest poi);
        void DeletePOI(PointOfInterest poi);
    }
}
