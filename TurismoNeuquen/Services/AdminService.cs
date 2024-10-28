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
            return _poiContext.PointsOfInterest.Where(x => x.State == false);
        }

        public void Confirm(int poiId)
        {
            // Retrieve the existing PointOfInterest from the database using the ID
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


        public void DeletePOI(PointOfInterest poi)
        {
            _poiContext.Remove(poi);
            _poiContext.SaveChanges();
        }
    }
}