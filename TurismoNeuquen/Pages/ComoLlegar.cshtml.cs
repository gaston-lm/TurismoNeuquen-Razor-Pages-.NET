using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoNeuquen.Models;
using TurismoNeuquen.Services;

namespace TurismoNeuquen.Pages
{
    public class ComoLlegarModel : PageModel
    {
        private readonly IPoiService _poiService;

        // Define the Points of Interest
        public PointOfInterest StartPoint { get; set; }
        public PointOfInterest EndPoint { get; set; }

        public ComoLlegarModel(IPoiService poiService)
        {
            _poiService = poiService;
        }

        public void OnGet(int id)
        {
            // You would likely retrieve these from a database or API, but for now, I'm using hardcoded values
            StartPoint = _poiService.GetPOI(id);
            EndPoint = _poiService.GetPOI(id);
        }
    }
}
