using System;
using System.Collections.Generic;

namespace E_Marche.Models
{
    public partial class Commande
    {
        public Commande()
        {
            Paniers = new HashSet<Panier>();
            Paymments = new HashSet<Paymment>();
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

        public virtual Client Client { get; set; }
        public virtual Commercant Commercant { get; set; }
        public virtual LieuLivraison LieuLivraison { get; set; }
        public virtual ICollection<Panier> Paniers { get; set; }
        public virtual ICollection<Paymment> Paymments { get; set; }
    }
}
