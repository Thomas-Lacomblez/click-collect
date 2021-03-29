using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_MarcheWA.Models
{
    public class ArticleData
    {
        public ArticleData()
        {
            Paniers = new HashSet<PanierData>();
            Photoes = new HashSet<PhotoData>();
        }

        public int ArticleId { get; set; }
        public string Libelle { get; set; }
        public int? Prix { get; set; }
        public int? Cantite { get; set; }
        public string ArticleDescreption { get; set; }
        public string Etat { get; set; }
        public string Photo { get; set; }
        public int? CategorieId { get; set; }
        public int? Clientid { get; set; }
        public int? Commercantid { get; set; }

        public virtual CategorieData Categorie { get; set; }
        public virtual ClientData Client { get; set; }
        public virtual CommercantData Commercant { get; set; }
        public virtual ICollection<PanierData> Paniers { get; set; }
        public virtual ICollection<PhotoData> Photoes { get; set; }
    }
}
