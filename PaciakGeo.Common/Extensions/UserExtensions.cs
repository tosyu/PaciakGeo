using Microsoft.Extensions.DependencyInjection;
using PaciakGeo.Common.Services;
using PaciakGeo.WebApi.Services;

namespace PaciakGeo.Common.Extensions
{
    public static class UserExtensions
    {
        public static IServiceCollection RegisterUserExtensions(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IUsersService, UsersService>();

            return serviceCollection;
        }
    }
}