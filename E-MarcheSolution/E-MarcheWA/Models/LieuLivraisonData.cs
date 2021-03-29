using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_MarcheWA.Models
{
    public class LieuLivraisonData
    {
        public LieuLivraisonData()
        {
            Commandes = new HashSet<CommandeData>();
        }

        public int LieuLivraisonId { get; set; }
        public string Pointderegroupement { get; set; }
        public string Ville { get; set; }
        public string Ad { get; set; }
        public string Arrondissement { get; set; }

        public virtual ICollection<CommandeData> Commandes { get; set; }
    }
}
