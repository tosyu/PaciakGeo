namespace PaciakGeo.WebApi.Models.ViewModels
{
    public class LoginResult
    {
        public string Token { get; set; }
        public PaciakUser User { get; set; }
    }
}