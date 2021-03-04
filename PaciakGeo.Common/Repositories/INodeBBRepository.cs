using System.Collections.Generic;
using System.Threading.Tasks;
using PaciakGeo.Common.Models;

namespace PaciakGeo.Common.Repositories
{
    public interface INodeBBRepository
    {
        Task<PaciakUser> GetUserBySessionId(string sessionId);
        Task<IEnumerable<PaciakUser>> GetUsers();
        Task<IEnumerable<PaciakUser>> GetUsers(string[] usernames);
        Task<PaciakUser> GetUser(string username);
    }
}