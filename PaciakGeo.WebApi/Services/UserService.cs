using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PaciakGeo.WebApi.Models.Configuration;
using PaciakGeo.WebApi.Models.ViewModels;
using PaciakGeo.WebApi.Repositories;

namespace PaciakGeo.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly INodeBBRepository nodeBbRepository;
        private readonly IOptions<JwtTokenConfig> tokenOptions;

        public UserService(INodeBBRepository nodeBbRepository, IOptions<JwtTokenConfig> tokenOptions)
        {
            this.nodeBbRepository = nodeBbRepository;
            this.tokenOptions = tokenOptions;
        }

        public async Task<PaciakUserDto> GetUserBySessionId(string sessionId)
        {
            return await nodeBbRepository.GetUserBySessionId(sessionId);
        }

        public string CreateJwtToken(PaciakUserDto paciakUser)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, paciakUser.Name),
                new Claim(JwtRegisteredClaimNames.Jti, paciakUser.Uid.ToString())
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.Value.SecretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                tokenOptions.Value.Issuer,
                tokenOptions.Value.Issuer,
                claims,
                expires: DateTime.UtcNow.AddMinutes(tokenOptions.Value.TimeToExpire),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}