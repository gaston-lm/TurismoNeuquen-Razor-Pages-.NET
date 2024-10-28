using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoNeuquen.Models;
using TurismoNeuquen.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TurismoNeuquen.Pages
{
    public class AdminModel : PageModel
    {
        private readonly AdminService _adminService;
        private readonly ILogger<AdminModel> _logger;

        public IEnumerable<PointOfInterest> Pois { get; set; }

        public AdminModel(AdminService adminService, ILogger<AdminModel> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public void OnGet()
        {
            try
            {
                Pois = _adminService.GetPOIs();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on getting POIs.", ex);
            }
        }

        public async Task<IActionResult> OnPostConfirmAsync(int id)
        {
            try
            {
                _adminService.Confirm(id);
                _logger.LogInformation($"POI with ID {id} has been confirmed.");

                Pois = _adminService.GetPOIs(); // Refresh list
            }
            catch (Exception ex)
            {
                _logger.LogError("Error confirming POI.", ex);
            }

            return Page();
        }
    }
}
