using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaciakGeo.Common.Services;
using PaciakGeo.WebApi.Services;

namespace PaciakGeo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly INodeBBUsersService nodeBbUsersService;

        public UsersController(INodeBBUsersService nodeBbUsersService)
        {
            this.nodeBbUsersService = nodeBbUsersService;
        }

        [HttpGet]
        [Route("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await nodeBbUsersService.GetUsers());
        }
    }
}