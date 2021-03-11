using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace PaciakGeo.WebApi.Extensions
{
    public static class AutomapperExtensions
    {
        public static IServiceCollection RegisterAutomapperProfiles(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(c => c.AddMaps(AppDomain.CurrentDomain.GetAssemblies()));
            
            return serviceCollection;
        }
    }
}