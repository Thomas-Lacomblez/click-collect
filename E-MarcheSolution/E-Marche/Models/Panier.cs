using System;
using System.Collections.Generic;

namespace E_Marche.Models
{
    public partial class Panier
    {
        public int PanierId { get; set; }
        public double? PrixArticle { get; set; }
        public int? Cantite { get; set; }
        public string Nom { get; set; }
        public string Photo { get; set; }
        public int? CommandeId { get; set; }
        public int? ArticleId { get; set; }
        public int? ClientId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Client Client { get; set; }
        public virtual Commande Commande { get; set; }
    }
}
