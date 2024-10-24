using System;
using System.Collections.Generic;
using System.Linq;
using TurismoNeuquen.Data;
using TurismoNeuquen.Models;

namespace TurismoNeuquen.Services
{
    public class PoiService : IPoiService
    {
        private readonly PoiContext _poiContext;

        public PoiService(PoiContext poiContext)
        {
            _poiContext = poiContext;
            _poiContext.Database.EnsureCreated();
        }

        public PointOfInterest GetPOI(int id)
        {
            return _poiContext.PointsOfInterest.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<PointOfInterest> GetPOIs()
        {
            return _poiContext.PointsOfInterest;
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
        public void CreatePOI(PointOfInterest poi)
        {
            _poiContext.Add(poi);
            _poiContext.SaveChanges();
        }
    }
}