using System;
using System.Collections.Generic;

namespace E_Marche.Models
{
    public partial class Sm
    {
        public Sm()
        {
            Clients = new HashSet<Client>();
            Commercants = new HashSet<Commercant>();
        }

        public int Smsid { get; set; }
        public double? SommeVerse { get; set; }
        public int? Cantite { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Commercant> Commercants { get; set; }
    }
}
