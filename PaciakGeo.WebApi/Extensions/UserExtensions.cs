using Microsoft.Extensions.DependencyInjection;
using PaciakGeo.WebApi.Services;

namespace PaciakGeo.WebApi.Extensions
{
    public static class UserExtensions
    {
        public static IServiceCollection RegisterUserExtensions(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();

            return serviceCollection;
        }
    }
}