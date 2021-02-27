using Microsoft.AspNetCore.Mvc;
using PaciakGeo.WebApi.Models.ViewModels;

namespace PaciakGeo.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrackingController : ControllerBase
    {
        [HttpPost]
        public ActionResult Track([FromBody] UserTrackingDataDto userTrackingDataDto)
        {
            return Ok();
        }
    }
}