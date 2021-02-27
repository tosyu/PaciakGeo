namespace PaciakGeo.WebApi.Models.ViewModels
{
    public class LoginResultDto
    {
        public string Token { get; set; }
        public PaciakUserDto User { get; set; }
    }
}