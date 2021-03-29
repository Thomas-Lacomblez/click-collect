using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_MarcheWA.Models
{
    public class ClientData
    {
        public ClientData()
        {
            Articles = new HashSet<ArticleData>();
            Categories = new HashSet<CategorieData>();
            Commandes = new HashSet<CommandeData>();
            Paniers = new HashSet<PanierData>();
            Paymments = new HashSet<PaymmentData>();
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
        public string LoginErrorMessage { get; set; }

        public virtual CategorieData Categorie { get; set; }
        public virtual SmsData Sms { get; set; }
        public virtual ICollection<ArticleData> Articles { get; set; }
        public virtual ICollection<CategorieData> Categories { get; set; }
        public virtual ICollection<CommandeData> Commandes { get; set; }
        public virtual ICollection<PanierData> Paniers { get; set; }
        public virtual ICollection<PaymmentData> Paymments { get; set; }
    }
}
