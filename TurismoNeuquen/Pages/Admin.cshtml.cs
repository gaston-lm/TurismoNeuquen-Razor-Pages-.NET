using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoNeuquen.Models;
using TurismoNeuquen.Services;

namespace TurismoNeuquen.Pages
{
    public class AdminModel(IPoiService poiService, ILogger<PoisModel> logger) : PageModel
    {
        private readonly IPoiService _poiService = poiService;
        private readonly ILogger _logger = logger;

        public IEnumerable<PointOfInterest> Pois { get; set; }

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
    }
}