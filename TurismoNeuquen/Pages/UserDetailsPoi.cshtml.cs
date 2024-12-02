using Microsoft.AspNetCore.Authorization;
using TurismoNeuquen.Models;
using TurismoNeuquen.Services;

namespace TurismoNeuquen.Pages
{
    [AllowAnonymous]
    [Authorize(AuthenticationSchemes = "UserCookie")]
    public class UserDetailsPoiModel : BaseDetailsPoiModel
    {
        private readonly IPoiService _poiService;

        public UserDetailsPoiModel(IPoiService poiService)
        {
            _poiService = poiService;
        }

        protected override PointOfInterest GetPointOfInterest(int id)
        {
            return _poiService.GetPOI(id);
        }
    }
}