using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurismoNeuquen.Data;
using TurismoNeuquen.Models;
using TurismoNeuquen.Repositories;

namespace TurismoNeuquen.Services
{
    public class AdminService : IAdminService
    {
        private readonly IPoiRepository _poiRepository;

        public AdminService(IPoiRepository poiRepository)
        {
            _poiRepository = poiRepository;
        }
        public PointOfInterest GetPOI(int id)
        {
            return _poiRepository.GetPOI(id);
        }

        public IEnumerable<PointOfInterest> GetUnconfirmedPOIs()
        {
            return _poiRepository.GetPOIs(false);
        }

        public void Confirm(int poiId)
        {
            _poiRepository.Confirm(poiId);
        }
        public void DeletePOI(int poiId)
        {
            _poiRepository.DeletePOI(poiId);
        }

    }
}