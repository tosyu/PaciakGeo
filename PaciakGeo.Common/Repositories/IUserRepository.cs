using System.Collections.Generic;
using System.Threading.Tasks;
using PaciakGeo.Common.Models;

namespace PaciakGeo.Common.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(int uid);
        Task<IEnumerable<User>> GetUsers();
        Task<bool> Exists(int uid);
        Task<bool> Upsert(User user);
        Task<bool> Delete(User user);
        Task<bool> DeleteByUid(int uid);
        Task<IEnumerable<User>> GetUsersForLocationUpdate(int? limit);
    }
}