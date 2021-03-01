using System.Collections.Generic;
using System.Threading.Tasks;
using PaciakGeo.WebApi.Models.ViewModels;

namespace PaciakGeo.WebApi.Repositories
{
    public interface INodeBBRepository
    {
        Task<PaciakUser> GetUserBySessionId(string sessionId);
        Task<IEnumerable<PaciakUser>> GetUsers();
        Task<IEnumerable<PaciakUser>> GetUsers(string[] usernames);
        Task<PaciakUser> GetUser(string username);
    }
}