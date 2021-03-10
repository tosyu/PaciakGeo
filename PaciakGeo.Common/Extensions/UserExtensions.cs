using Microsoft.Extensions.DependencyInjection;
using PaciakGeo.Common.Repositories;
using PaciakGeo.Common.Services;
using PaciakGeo.WebApi.Services;

namespace PaciakGeo.Common.Extensions
{
    public static class UserExtensions
    {
        public static IServiceCollection RegisterUserExtensions(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            serviceCollection.AddTransient<IUserService, UserService>();
            
            return serviceCollection;
        }
    }
}