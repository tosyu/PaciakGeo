using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaciakGeo.Common.Services;
using PaciakGeo.WebApi.Models.ViewModels;

namespace PaciakGeo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userService.GetUsers();
            return Ok(mapper.Map<IEnumerable<UserViewModel>>(users));
        }
    }
}