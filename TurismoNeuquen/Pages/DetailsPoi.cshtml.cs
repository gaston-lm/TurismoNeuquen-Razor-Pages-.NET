using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoNeuquen.Models;
using TurismoNeuquen.Services;
using System.Linq;

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

        public IActionResult OnGet(int id)
        {
            PointOfInterest = _poiService.GetPOI(id);

            if (PointOfInterest == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
