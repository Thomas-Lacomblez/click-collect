using System;
using System.Collections.Generic;

namespace E_Marche.Models
{
    public partial class Paymment
    {
        public int PaymmentId { get; set; }
        public DateTime? DatePaymment { get; set; }
        public string NumCompte { get; set; }
        public string TelAcommercant { get; set; }
        public string TelUtilisateur { get; set; }
        public int? ClientId { get; set; }
        public int? CommercantId { get; set; }
        public int? CommandeId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Commande Commande { get; set; }
        public virtual Commercant Commercant { get; set; }
    }
}
