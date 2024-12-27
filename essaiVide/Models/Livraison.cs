using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class Livraison
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Adresse { get; set; }

        // Relation
        public Livreur? Livreur { get; set; }
        public int? LivreurId { get; set; }
    }
}