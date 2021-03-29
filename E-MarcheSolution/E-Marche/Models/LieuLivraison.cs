using System;
using System.Collections.Generic;

namespace E_Marche.Models
{
    public partial class LieuLivraison
    {
        public LieuLivraison()
        {
            Commandes = new HashSet<Commande>();
        }

        public int LieuLivraisonId { get; set; }
        public string Pointderegroupement { get; set; }
        public string Ville { get; set; }
        public string Ad { get; set; }
        public string Arrondissement { get; set; }

        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
