using System.Threading.Tasks;
using PaciakGeo.Common.Models;

namespace PaciakGeo.Common.Services
{
    public interface INodeBBUserService
    {
        Task<PaciakUser> GetUserBySessionId(string sessionId);
    }
}