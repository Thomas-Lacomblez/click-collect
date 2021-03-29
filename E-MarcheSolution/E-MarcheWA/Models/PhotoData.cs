using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_MarcheWA.Models
{
    public class PhotoData
    {
        public int PhotoId { get; set; }
        public string Chemin { get; set; }
        public int? ArticleId { get; set; }

        public virtual ArticleData Article { get; set; }
    }
}
