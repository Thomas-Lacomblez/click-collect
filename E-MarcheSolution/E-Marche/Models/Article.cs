using System;
using System.Collections.Generic;

namespace E_Marche.Models
{
    public partial class Article
    {
        public Article()
        {
            Paniers = new HashSet<Panier>();
            Photoes = new HashSet<Photo>();
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

        public virtual Categorie Categorie { get; set; }
        public virtual Client Client { get; set; }
        public virtual Commercant Commercant { get; set; }
        public virtual ICollection<Panier> Paniers { get; set; }
        public virtual ICollection<Photo> Photoes { get; set; }
    }
}
