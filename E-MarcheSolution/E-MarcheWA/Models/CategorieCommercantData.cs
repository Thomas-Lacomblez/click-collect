using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_MarcheWA.Models
{
    public class CategorieCommercantData
    {
        public int CategorieCommercantId { get; set; }
        public int CommercantId { get; set; }
        public int CategorieId { get; set; }

        public virtual CategorieData Categorie { get; set; }
    }
}
