using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nominatim.API.Geocoders;
using Nominatim.API.Models;
using PaciakGeo.Common.Models;

namespace PaciakGeo.Common.Repositories
{
    public class LocationRepostory : ILocationRepository
    {
        private readonly ILogger<LocationRepostory> logger;

        public LocationRepostory(ILogger<LocationRepostory> logger)
        {
            this.logger = logger;
        }
        
        public async Task<LocationCoordinates> FindLocationCoordinates(string location)
        {
            var geocoder = new ForwardGeocoder();
            var request = new ForwardGeocodeRequest
            {
                queryString = location,
                BreakdownAddressElements = true,
                ShowExtraTags = false,
                ShowAlternativeNames = false,
                ShowGeoJSON = false
            };
            
            logger.LogDebug($"fetching coords for {location}");
            var result = await geocoder.Geocode(request);
            var response = result.FirstOrDefault();

            if (result.Length > 0 && response != null)
            {
                return new LocationCoordinates
                {
                    Latitude = response.Latitude,
                    Longitude = response.Longitude
                };
            }
            
            Thread.Sleep(1000);

            return null;
        }
    }
}