using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_MarcheWA.Models
{
    public class CategorieData
    {
        public CategorieData()
        {
            Articles = new HashSet<ArticleData>();
            CategorieCommercants = new HashSet<CategorieCommercantData>();
            Clients = new HashSet<ClientData>();
        }

        public int CategorieId { get; set; }
        public string Libelle { get; set; }
        public string Photo { get; set; }
        public string Nom { get; set; }
        public string Discription { get; set; }
        public int? ClientId { get; set; }

        public virtual ClientData Client { get; set; }
        public virtual ICollection<ArticleData> Articles { get; set; }
        public virtual ICollection<CategorieCommercantData> CategorieCommercants { get; set; }
        public virtual ICollection<ClientData> Clients { get; set; }
    }
}
