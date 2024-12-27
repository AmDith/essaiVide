using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class LigneCommande
    {
        public int Id { get; set; }
        public int QteCommande {  get; set; }
        public Double Somme {  get; set; }

        // Relation
        public Produit? Produit { get; set; }
        public int? ProduitId { get; set; }
        public Commande? Commande { get; set; }
        public int? CommandeId { get; set; }
    }
}