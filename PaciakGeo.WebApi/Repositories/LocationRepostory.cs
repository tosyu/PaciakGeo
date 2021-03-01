using System.Linq;
using System.Threading.Tasks;
using Nominatim.API.Geocoders;
using Nominatim.API.Models;
using PaciakGeo.WebApi.Models;
using PaciakGeo.WebApi.Models.ViewModels;

namespace PaciakGeo.WebApi.Repositories
{
    public class LocationRepostory : ILocationRepository
    {
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

            return null;
        }
    }
}