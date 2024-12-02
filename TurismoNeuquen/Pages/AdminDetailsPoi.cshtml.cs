using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TurismoNeuquen.Models;
using TurismoNeuquen.Services;

namespace TurismoNeuquen.Pages
{
    [Authorize(AuthenticationSchemes = "AdminCookie")]
    public class AdminDetailsPoiModel : BaseDetailsPoiModel
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<AdminModel> _logger;

        public AdminDetailsPoiModel(IAdminService adminService, ILogger<AdminModel> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        protected override PointOfInterest GetPointOfInterest(int id)
        {
            return _adminService.GetPOI(id);
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