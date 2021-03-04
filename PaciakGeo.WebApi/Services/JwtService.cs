using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PaciakGeo.Common.Models;
using PaciakGeo.WebApi.Models.Configuration;
using PaciakGeo.WebApi.Models.ViewModels;

namespace PaciakGeo.WebApi.Services
{
    public class JwtService : IJwtService
    {
        private readonly IOptions<JwtTokenConfig> tokenOptions;

        public JwtService(IOptions<JwtTokenConfig> tokenOptions)
        {
            this.tokenOptions = tokenOptions;
        }

        public string CreateJwtToken(PaciakUser paciakUser)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, paciakUser.Slug),
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