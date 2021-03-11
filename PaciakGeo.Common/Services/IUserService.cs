using System.Collections.Generic;
using System.Threading.Tasks;
using PaciakGeo.Common.Models;

namespace PaciakGeo.Common.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetUsersForLocationUpdate(int? limit);
        Task<bool> UpdateUserLocationCoordinates(User user);
    }
}