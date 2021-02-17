using Microsoft.AspNetCore.Mvc;
using PaciakGeo.Common.Models.Dto;

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