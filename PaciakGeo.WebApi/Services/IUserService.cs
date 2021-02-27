using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using PaciakGeo.WebApi.Models.ViewModels;

namespace PaciakGeo.WebApi.Services
{
    public interface IUserService
    {
        Task<PaciakUserDto> GetUserBySessionId(string sessionId);
        string CreateJwtToken(PaciakUserDto paciakUser);
    }
}