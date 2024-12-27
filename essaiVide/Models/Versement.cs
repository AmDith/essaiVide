using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class Versement
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime Date {  get; set; }
        public Double Montant { get; set; }

        // Relation
        public Client? Client { get; set; }
        public int? ClientId { get; set; }

    }
}