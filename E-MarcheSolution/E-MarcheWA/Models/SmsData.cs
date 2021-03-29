using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_MarcheWA.Models
{
    public class SmsData
    {
        public SmsData()
        {
            Client = new HashSet<ClientData>();
            Commercant = new HashSet<CommercantData>();
        }

        public int Smsid { get; set; }
        public double? SommeVerse { get; set; }
        public int? Cantite { get; set; }

        public virtual ICollection<ClientData> Client { get; set; }
        public virtual ICollection<CommercantData> Commercant { get; set; }
    }
}
