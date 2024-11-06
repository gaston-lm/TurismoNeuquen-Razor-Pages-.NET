using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoNeuquen.Models;
using TurismoNeuquen.Services;
using System.Linq;
using System.Drawing.Drawing2D;

namespace TurismoNeuquen.Pages
{
    public class DetailsPoiModel : PageModel
    {
        private readonly IPoiService _poiService;

        public PointOfInterest PointOfInterest { get; set; } = new Attraction();

        public Attraction Attraction { get; set; } = new Attraction();

        public Event Event { get; set; } = new Event();

        public int Type { get; set; }

        public DetailsPoiModel(IPoiService poiService)
        {
            _poiService = poiService;
        }

        public IActionResult OnGet(int id)
        {
            // Retrieve the PointOfInterest object
            PointOfInterest = _poiService.GetPOI(id);

            // Check if the PointOfInterest was not found
            if (PointOfInterest == null)
            {
                return NotFound();
            }

            // Now that we know PointOfInterest is not null, determine its type
            if (PointOfInterest is Attraction attraction)
            {
                Type = 1;
                Attraction = (Attraction)PointOfInterest;
                Console.Write(Attraction.Name);
            }
            else if (PointOfInterest is Event eventObj)
            {
                Type = 0;
                Event = (Event)PointOfInterest;
            }
            else
            {
                // Handle the case where PointOfInterest is neither an Attraction nor an Event
                return NotFound();
            }

            return Page();
        }
    }
}
