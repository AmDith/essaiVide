using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Libelle { get; set; }
        public int QteStock { get; set; }
        public Double Prix { get; set; }
        public int QteSeuil { get; set; }
        public string image { get; set; }

        //Relation

       public virtual ICollection<LigneCommande>? Lignes { get; set; }
    }
}