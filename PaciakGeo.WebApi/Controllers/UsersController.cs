using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaciakGeo.WebApi.Services;

namespace PaciakGeo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        [Route("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await usersService.GetUsers());
        }
    }
}