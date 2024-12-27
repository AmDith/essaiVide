using essaiVide.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class Paiement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Double Montant { get; set; }
        public string Reference { get; set; }
        public TypePaiement Type { get; set; }
    }
}