using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiGps.Models
{
    public partial class Cacamba
    {
        public Cacamba()
        {
            Localizacaos = new HashSet<Localizacao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Localizacao> Localizacaos { get; set; }
    }
}
