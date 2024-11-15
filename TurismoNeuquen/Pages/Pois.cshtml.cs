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
            {
                Pois = _poiService.GetConfirmedPOIs();
                throw new ApplicationException("Sample exception.");
            }

        }
    }
}
