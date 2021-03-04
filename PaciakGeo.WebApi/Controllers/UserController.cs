using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
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
        private readonly IJwtService jwtService;
        private readonly IOptions<JwtTokenConfig> tokenConfig;

        public UserController(IUserService userService, IJwtService jwtService, IOptions<JwtTokenConfig> tokenConfig)
        {
            this.userService = userService;
            this.jwtService = jwtService;
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
                    return Ok(new LoginResult
                    {
                        Token = jwtService.CreateJwtToken(user),
                        User = user
                    });
                }
            }

            return StatusCode(403, new LoginFailedResult {RedirectUrl = tokenConfig.Value.IssuerLoginUrl});
        }
        
        [HttpGet]
        [Authorize]
        [Route("me")]
        public IActionResult GetMe()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var claims = identity.Claims.ToList();
                var uid = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value;
                var username = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;

                return Ok($"{uid}/{username}");
            }
            return NotFound();
        }
    }
}