using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_MarcheWA.Models
{
    public class CommandeData
    {
        public CommandeData()
        {
            Paniers = new HashSet<PanierData>();
            Paymments = new HashSet<PaymmentData>();
        }

        public int CommandeId { get; set; }
        public DateTime? DateCommande { get; set; }
        public DateTime? DateLaivraison { get; set; }
        public string LieuLaivraison { get; set; }
        public int? CategorieId { get; set; }
        public int? ClientId { get; set; }
        public double? SommeT { get; set; }
        public int? CommercantId { get; set; }
        public int? LieuLivraisonId { get; set; }

        public virtual ClientData Client { get; set; }
        public virtual CommercantData Commercant { get; set; }
        public virtual LieuLivraisonData LieuLivraison { get; set; }
        public virtual ICollection<PanierData> Paniers { get; set; }
        public virtual ICollection<PaymmentData> Paymments { get; set; }
    }
}
