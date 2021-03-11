namespace PaciakGeo.WebApi.Models.ViewModels
{
    public class UserViewModel
    {
        public int Uid { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public double? LocationLongitude { get; set; }
        public double? LocationLatitude { get; set; }
    }
}