using System;
using System.Collections.Generic;

namespace E_Marche.Models
{
    public partial class Sms
    {
        public Sms()
        {
            Client = new HashSet<Client>();
            Commercant = new HashSet<Commercant>();
        }

        public int Smsid { get; set; }
        public double? SommeVerse { get; set; }
        public int? Cantite { get; set; }

        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<Commercant> Commercant { get; set; }
    }
}
