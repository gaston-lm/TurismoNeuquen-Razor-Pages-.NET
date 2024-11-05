using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoNeuquen.Models;
using TurismoNeuquen.Services;

namespace TurismoNeuquen.Pages
{
    public class AddPoiModel : PageModel
    {
        private readonly IPoiService _poiService;

        public AddPoiModel(IPoiService poiService)
        {
            _poiService = poiService;
        }

        [BindProperty] public string PoiType { get; set; }
        [BindProperty] public string Name { get; set; }
        [BindProperty] public string Description { get; set; }
        [BindProperty] public double Latitude { get; set; }
        [BindProperty] public double Longitude { get; set; }

        // Fields specific to Event
        [BindProperty] public DateTime? EventDate { get; set; }
        [BindProperty] public string? Location { get; set; }

        // Fields specific to Attraction
        [BindProperty] public string OpenDays { get; set; } // Changed to string for binary representation
        [BindProperty] public TimeOnly? OpeningTime { get; set; }
        [BindProperty] public TimeOnly? ClosingTime { get; set; }

        public IActionResult OnPostAddPOI()
        {
            // Here, you can store the OpenDays string as needed.
            _poiService.AddPoi(PoiType, Name, Description, Latitude, Longitude, EventDate, Location, OpenDays, OpeningTime, ClosingTime);

            return RedirectToPage("/Index"); // Redirect to a success page or another appropriate action
        }
    }
}
