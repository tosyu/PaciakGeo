using System.Threading.Tasks;
using PaciakGeo.WebApi.Models;
using PaciakGeo.WebApi.Models.ViewModels;

namespace PaciakGeo.WebApi.Repositories
{
    public interface ILocationRepository
    {
        Task<LocationCoordinates> FindLocationCoordinates(string location);
    }
}