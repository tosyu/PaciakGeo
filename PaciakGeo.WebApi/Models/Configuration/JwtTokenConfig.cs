namespace PaciakGeo.WebApi.Models.Configuration
{
    public class JwtTokenConfig
    {
        public string Issuer { get; set; }
        public string IssuerLoginUrl { get; set; }
        public string SecretKey { get; set; }
        public int TimeToExpire { get; set; }
    }
}