using TurismoNeuquen.Models;

namespace TurismoNeuquen.Services
{
    public interface IAdminService
    {
        IEnumerable<PointOfInterest> GetUnconfirmedPOIs();

        PointOfInterest GetPOI(int id);

        void Confirm(int poiId);
        void DeletePOI(int poiId);
    }
}
