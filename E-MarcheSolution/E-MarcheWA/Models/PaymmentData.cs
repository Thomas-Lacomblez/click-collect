using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_MarcheWA.Models
{
    public class PaymmentData
    {
        public int PaymmentId { get; set; }
        public DateTime? DatePaymment { get; set; }
        public string NumCompte { get; set; }
        public string TelAcommercant { get; set; }
        public string TelUtilisateur { get; set; }
        public int? ClientId { get; set; }
        public int? CommercantId { get; set; }
        public int? CommandeId { get; set; }

        public virtual ClientData Client { get; set; }
        public virtual CommandeData Commande { get; set; }
        public virtual CommercantData Commercant { get; set; }
    }
}
