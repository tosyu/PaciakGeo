using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaciakGeo.Common.Models
{
    public class User
    {
        [Column("uid")]
        public int Uid { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("avatar_url")]
        public string AvatarUrl { get; set; }
        [Column("location")]
        public string Location { get; set; }
        [Column("tracking_enabled")]
        public bool TrackingEnabled { get; set; }
        [Column("last_updated_location")]
        public DateTime LastUpdatedLocation { get; set; }
        [Column("location_longitue")]
        public double? LocationLongitude { get; set; }
        [Column("location_latitude")]
        public double? LocationLatitude { get; set; }
    }
}