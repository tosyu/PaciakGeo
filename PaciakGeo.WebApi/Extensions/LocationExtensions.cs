using Microsoft.Extensions.DependencyInjection;
using PaciakGeo.WebApi.Repositories;

namespace PaciakGeo.WebApi.Extensions
{
    public static class LocationExtensions
    {
        public static IServiceCollection RegisterLocationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ILocationRepository, LocationRepostory>();
            
            return serviceCollection;
        }
    }
}