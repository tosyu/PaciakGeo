using System.Threading.Tasks;
using PaciakGeo.Common.Models;

namespace PaciakGeo.WebApi.Services
{
    public interface IUserService
    {
        Task<PaciakUser> GetUserBySessionId(string sessionId);
    }
}