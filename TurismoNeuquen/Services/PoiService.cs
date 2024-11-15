using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TurismoNeuquen.Data;
using TurismoNeuquen.Models;
using TurismoNeuquen.Repositories;

namespace TurismoNeuquen.Services
{
    public class PoiService : IPoiService
    {
        private readonly IPoiRepository _poiRepository;

        public PoiService(IPoiRepository poiRepository)
        {
            _poiRepository = poiRepository;
        }

        public PointOfInterest GetPOI(int id)
        {
            return _poiRepository.GetPOI(id);
        }

        public IEnumerable<PointOfInterest> GetConfirmedPOIs()
        {
            return _poiRepository.GetPOIs(true);
        }

        public void AddPoi(string poiType, string name, string description, double latitude, double longitude, string imagename, DateTime? eventDate = null, string? openDays = null, TimeOnly? openingTime = null, TimeOnly? closingTime = null)
        {
            _poiRepository.AddPoi(poiType, name, description, latitude, longitude, imagename, eventDate, openDays, openingTime, closingTime);
        }


    }
}