using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiGps.Models
{
    public partial class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
