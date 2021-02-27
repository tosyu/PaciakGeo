using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.Net.Http.Headers;
using PaciakGeo.WebApi.Models.Configuration;
using PaciakGeo.WebApi.Models.ViewModels;
using PaciakGeo.WebApi.Services;

namespace PaciakGeo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IOptions<JwtTokenConfig> tokenConfig;

        public UserController(IUserService userService, IOptions<JwtTokenConfig> tokenConfig)
        {
            this.userService = userService;
            this.tokenConfig = tokenConfig;
        }
        
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login()
        {
            if (Request.Cookies.TryGetValue("express.sid", out string sessionId))
            {
                var user = await userService.GetUserBySessionId(sessionId);
                if (user != null)
                {
                    return Ok(new LoginResultDto {Token = userService.CreateJwtToken(user)});
                }
            }

            return StatusCode(403, new LoginFailedResultDto {RedirectUrl = tokenConfig.Value.IssuerLoginUrl});
        }
        
        [HttpGet]
        [Authorize]
        [Route("me")]
        public async Task<IActionResult> GetMe()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var claims = identity.Claims;
                var uid = claims.Where(c => c.Type == JwtRegisteredClaimNames.Jti).FirstOrDefault()?.Value;
                var username = claims.Where(c => c.Type == JwtRegisteredClaimNames.Sub).FirstOrDefault()?.Value;

                return Ok($"{uid}/{username}");
            }
            return NotFound();
        }
    }
}