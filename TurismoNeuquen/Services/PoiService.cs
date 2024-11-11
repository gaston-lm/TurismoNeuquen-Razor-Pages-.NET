using Microsoft.EntityFrameworkCore;
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
            return _poiContext.PointsOfInterest.Where(x => x.State == true);
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

        public void AddPoi(string poiType, string name, string description, double latitude, double longitude, string imagename, DateTime? eventDate = null, string? openDays = null, TimeOnly? openingTime = null, TimeOnly? closingTime = null)
        {
            PointOfInterest poi;

            if (poiType == "attraction")
            {
                poi = Attraction.Create(name, description, latitude, longitude, imagename, openDays, openingTime, closingTime);
            }
            else if (poiType == "event" && eventDate.HasValue)
            {
                poi = Event.Create(name, description, latitude, longitude, imagename, eventDate.Value);
            }
            else
            {
                throw new ArgumentException("Invalid POI type or missing required fields for the type");
            }

            _poiContext.PointsOfInterest.Add(poi);
            _poiContext.SaveChanges();
        }


    }
}