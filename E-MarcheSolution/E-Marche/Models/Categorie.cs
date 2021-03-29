using System;
using System.Collections.Generic;

namespace E_Marche.Models
{
    public partial class Categorie
    {
        public Categorie()
        {
            Articles = new HashSet<Article>();
            CategorieCommercants = new HashSet<CategorieCommercant>();
            Clients = new HashSet<Client>();
        }

        public int CategorieId { get; set; }
        public string Libelle { get; set; }
        public string Photo { get; set; }
        public string Nom { get; set; }
        public string Discription { get; set; }
        public int? ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<CategorieCommercant> CategorieCommercants { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
