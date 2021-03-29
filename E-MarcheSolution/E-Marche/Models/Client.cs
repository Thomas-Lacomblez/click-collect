using System;
using System.Collections.Generic;

namespace E_Marche.Models
{
    public partial class Client
    {
        public Client()
        {
            Articles = new HashSet<Article>();
            Categories = new HashSet<Categorie>();
            Commandes = new HashSet<Commande>();
            Paniers = new HashSet<Panier>();
            Paymments = new HashSet<Paymment>();
        }

        public int ClientId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string LoginUser { get; set; }
        public string MdpUser { get; set; }
        public int? UserRole { get; set; }
        public int? Typeprivilege { get; set; }
        public string DescriptionUser { get; set; }
        public string Ville { get; set; }
        public string Arrondissement { get; set; }
        public int? CategorieId { get; set; }
        public int? Smsid { get; set; }
        //public string LoginErrorMessage { get; set; }

        public virtual Categorie Categorie { get; set; }
        public virtual Sms Sms { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Categorie> Categories { get; set; }
        public virtual ICollection<Commande> Commandes { get; set; }
        public virtual ICollection<Panier> Paniers { get; set; }
        public virtual ICollection<Paymment> Paymments { get; set; }
    }
}
