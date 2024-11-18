using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using TurismoNeuquen.Models;
using TurismoNeuquen.Services;

namespace TurismoNeuquen.Pages
{
    [Authorize(AuthenticationSchemes = "UserCookie")]
    public class AddPoiModel : PageModel
    {
        private readonly IPoiService _poiService;
        private readonly IUploadImageAPIService _uploadImage;

        public AddPoiModel(IPoiService poiService, IUploadImageAPIService uploadImage)
        {
            _poiService = poiService;
            _uploadImage = uploadImage;
        }

        [BindProperty] public string PoiType { get; set; }
        [BindProperty] public string Name { get; set; }
        [BindProperty] public string Description { get; set; }
        [BindProperty] public double Latitude { get; set; }
        [BindProperty] public double Longitude { get; set; }

        [BindProperty] public IFormFile ImageFile { get; set; }

        public string ImageName { get; set; }

        // Fields specific to Event
        [BindProperty] public DateTime? EventDate { get; set; }

        // Fields specific to Attraction
        [BindProperty] public string OpenDays { get; set; } // Changed to string for binary representation
        [BindProperty] public TimeOnly? OpeningTime { get; set; }
        [BindProperty] public TimeOnly? ClosingTime { get; set; }
        public string UserId { get; private set; } // Property to store the UserId

        public async Task<IActionResult> OnPostAddPOI()
        {
            UserId = User.FindFirst("UserId")?.Value;

            if (string.IsNullOrEmpty(UserId))
            {
                // Handle the case where the claim is not found
                ModelState.AddModelError(string.Empty, "UserId claim is missing.");
                return Page();
            }

            ImageName = "";

            // Check if ImageFile is null or empty
            if (ImageFile != null)
            {
                ImageName = await _uploadImage.UploadFile(ImageFile);
            }            

            // Store the OpenDays string and other data as needed.
            _poiService.AddPoi(
                PoiType, 
                Name, 
                Description, 
                Latitude, 
                Longitude, 
                ImageName,
                UserId,
                EventDate, 
                OpenDays, 
                OpeningTime, 
                ClosingTime
                );

            return RedirectToPage("/Index"); // Redirect to a success page or another appropriate action
        }

    }
}
