using System;
using System.Collections.Generic;

namespace E_Marche.Models
{
    public partial class Commercant
    {
        public Commercant()
        {
            Articles = new HashSet<Article>();
            Commandes = new HashSet<Commande>();
            Paymments = new HashSet<Paymment>();
        }

        public int CommercantId { get; set; }
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
        public string Siren { get; set; }
        public string Ville { get; set; }
        public string Arrondissement { get; set; }
        public int? Smsid { get; set; }

        public virtual Sms Sms { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Commande> Commandes { get; set; }
        public virtual ICollection<Paymment> Paymments { get; set; }
    }
}
