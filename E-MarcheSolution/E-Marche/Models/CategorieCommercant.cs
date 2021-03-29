using System;
using System.Collections.Generic;

namespace E_Marche.Models
{
    public partial class CategorieCommercant
    {
        public int CategorieCommercantId { get; set; }
        public int CommercantId { get; set; }
        public int CategorieId { get; set; }

        public virtual Categorie Categorie { get; set; }
    }
}
