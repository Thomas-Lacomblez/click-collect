using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_MarcheWA.Models
{
    public class PanierData
    {
        public int PanierId { get; set; }
        public double? PrixArticle { get; set; }
        public int? Cantite { get; set; }
        public string Nom { get; set; }
        public string Photo { get; set; }
        public int? CommandeId { get; set; }
        public int? ArticleId { get; set; }
        public int? ClientId { get; set; }

        public virtual ArticleData Article { get; set; }
        public virtual ClientData Client { get; set; }
        public virtual CommandeData Commande { get; set; }
    }
}
