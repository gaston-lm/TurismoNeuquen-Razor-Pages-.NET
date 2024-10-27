using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurismoNeuquen.Data;
using TurismoNeuquen.Models;

namespace TurismoNeuquen.Services
{
    public class AdminService : Controller
    {
        private readonly PoiContext _poiContext;

        public AdminService(PoiContext poiContext)
        {
            _poiContext = poiContext;
            _poiContext.Database.EnsureCreated();
        }

        public IEnumerable<PointOfInterest> GetPOIs()
        {
            yield return _poiContext.PointsOfInterest.SingleOrDefault(x => x.State == false);
        }

        public void UpdatePOI(PointOfInterest poi)
        {
            _poiContext.Update(poi);
            _poiContext.SaveChanges();
        }

        public void DeletePOI(PointOfInterest poi)
        {
            _poiContext.Remove(poi);
            _poiContext.SaveChanges();
        }
    }
}