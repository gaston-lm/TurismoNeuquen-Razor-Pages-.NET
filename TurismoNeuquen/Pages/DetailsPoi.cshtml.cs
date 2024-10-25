using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoNeuquen.Models;
using TurismoNeuquen.Services;

namespace TurismoNeuquen.Pages
{
    public class DetailsPoiModel : PageModel
    {
        private readonly IPoiService _poiService;

        public PointOfInterest PointOfInterest { get; set; }


        public DetailsPoiModel(IPoiService poiService)
        {
            _poiService = poiService;
        }

        public void OnGet(string name)
        {
            PointOfInterest = _poiService.GetPOIs().SingleOrDefault(x => x.Name == name);
        }
    }
  
}
