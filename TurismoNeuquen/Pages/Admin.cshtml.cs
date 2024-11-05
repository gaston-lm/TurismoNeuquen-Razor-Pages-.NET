using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoNeuquen.Models;
using TurismoNeuquen.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace TurismoNeuquen.Pages
{
    [Authorize] // Ensure only authenticated users can access this page
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

        public IActionResult OnPostConfirm(int id)
        {
            _adminService.Confirm(id);
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            _adminService.DeletePOI(id);
            return RedirectToPage();
        }
    }
}