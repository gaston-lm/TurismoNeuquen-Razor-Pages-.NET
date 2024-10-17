using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoNeuquen.Models;
using TurismoNeuquen.Services;

namespace TurismoNeuquen.Pages
{
    public class PoisModel : PageModel
    {
        private readonly IPoiService _poiService;
        private readonly ILogger _logger;

        public IEnumerable<PointOfInterest> Pois { get; set; }

        public PoisModel(IPoiService poiService, ILogger<PoisModel> logger)
        {
            _poiService = poiService;
            _logger = logger;
        }

        public void OnGet()
        {
            try
            {
                Pois = _poiService.GetPOIs();
                throw new ApplicationException("Sample exception.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on getting books.", ex);
            }
        }

        public IActionResult OnPostDelete(int id)
        {
            var book = _poiService.GetPOI(id);
            if (book == null)
            {
                return NotFound();
            }

            _poiService.DeletePOI(book);
            return RedirectToPage("Books");
        }
    }
}
