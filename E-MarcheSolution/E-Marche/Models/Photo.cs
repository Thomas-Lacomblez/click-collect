using System;
using System.Collections.Generic;

namespace E_Marche.Models
{
    public partial class Photo
    {
        public int PhotoId { get; set; }
        public string Chemin { get; set; }
        public int? ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
