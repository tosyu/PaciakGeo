using System.Threading.Tasks;
using PaciakGeo.Common.Models;

namespace PaciakGeo.Common.Repositories
{
    public interface ILocationRepository
    {
        Task<LocationCoordinates> FindLocationCoordinates(string location);
    }
}