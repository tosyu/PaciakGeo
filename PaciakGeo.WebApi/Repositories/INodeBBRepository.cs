using System.Threading.Tasks;
using PaciakGeo.WebApi.Models;
using PaciakGeo.WebApi.Models.ViewModels;

namespace PaciakGeo.WebApi.Repositories
{
    public interface INodeBBRepository
    {
        Task<PaciakUserDto> GetUserBySessionId(string sessionId);
    }
}