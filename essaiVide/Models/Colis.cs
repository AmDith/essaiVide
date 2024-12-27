using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class Colis
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        // Relation
        public Commande? Commande { get; set; }
        public int? CommandeId { get; set; }

    }
}