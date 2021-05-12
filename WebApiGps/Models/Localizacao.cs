using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiGps.Models
{
    public partial class Localizacao
    {
        public int Id { get; set; }
        public int? CodCacamba { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime? CriadoEm { get; set; }

        public virtual Cacamba CodCacambaNavigation { get; set; }
    }
}
