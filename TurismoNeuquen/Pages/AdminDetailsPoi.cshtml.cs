using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoNeuquen.Models;
using TurismoNeuquen.Services;
using System.Linq;
using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Authorization;

namespace TurismoNeuquen.Pages
{
    [Authorize] // Ensure only authenticated users can access this page

    public class AdminDetailsPoiModel : PageModel
    {
        private readonly AdminService _adminService;
        private readonly ILogger<AdminModel> _logger;

        private readonly IPoiService _poiService;

        public PointOfInterest PointOfInterest { get; set; } = new Attraction();

        public Attraction Attraction { get; set; } = new Attraction();

        public Event Event { get; set; } = new Event();

        public int Type { get; set; }

        public AdminDetailsPoiModel(IPoiService poiService, AdminService adminService, ILogger<AdminModel> logger)
        {
            _poiService = poiService;
            _adminService = adminService;
            _logger = logger;
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

        public IActionResult OnPostConfirm(int id)
        {
            _adminService.Confirm(id);
            return RedirectToPage("/Admin");
        }

        public IActionResult OnPostDelete(int id)
        {
            _adminService.DeletePOI(id);
            return RedirectToPage("/Admin");
        }
    }
}