using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PaciakGeo.WebApi.Models.Configuration;

namespace PaciakGeo.WebApi.Extensions
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection RegisterAuthenticationExtensions(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<JwtTokenConfig>(configuration.GetSection(nameof(JwtTokenConfig)));
            serviceCollection.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var jwtOptions = serviceCollection.BuildServiceProvider().GetRequiredService<IOptions<JwtTokenConfig>>();
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Value.Issuer,
                    ValidAudience = jwtOptions.Value.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey)),
                };
            });

            return serviceCollection;
        }
    }
}