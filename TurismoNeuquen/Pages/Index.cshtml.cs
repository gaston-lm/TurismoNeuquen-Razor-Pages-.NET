using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TurismoNeuquen.Services;
using TurismoNeuquen.Models;
using System.Collections.Generic;

namespace TurismoNeuquen.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPoiService _poiService;

        public IndexModel(ILogger<IndexModel> logger, IPoiService poiService)
        {
            _logger = logger;
            _poiService = poiService;
        }

        public List<PointOfInterest> POIs { get; private set; } = new List<PointOfInterest>();

        public void OnGet()
        {
            _logger.LogInformation("Map page loaded.");
            POIs = new List<PointOfInterest>(_poiService.GetPOIs());
        }
    }
}
