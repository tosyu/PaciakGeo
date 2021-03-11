using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaciakGeo.Common.Models
{
    public class User
    {
        public int Uid { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public string Location { get; set; }
        public bool TrackingEnabled { get; set; }
        public DateTime LastUpdatedLocation { get; set; }
        public double? LocationLongitude { get; set; }
        public double? LocationLatitude { get; set; }
    }
}