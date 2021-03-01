using System.Threading.Tasks;
using PaciakGeo.WebApi.Models.ViewModels;

namespace PaciakGeo.WebApi.Services
{
    public interface IUserService
    {
        Task<PaciakUser> GetUserBySessionId(string sessionId);
        string CreateJwtToken(PaciakUser paciakUser);
    }
}