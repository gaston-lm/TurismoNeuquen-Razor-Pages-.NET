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

        [BindProperty]
        public PointOfInterest PointOfInterest { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _poiService.CreatePOI(PointOfInterest);
            return RedirectToPage("Index");
        }
    }
}
