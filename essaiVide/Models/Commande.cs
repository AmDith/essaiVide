using essaiVide.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Models
{
    public class Commande
    {
        public int Id { get; set; }
        public DateTime Datde { get; set; }
        public Double Montant { get; set; }
        public EtatCommande EtatCommande { get; set; }
        public EtatSolde EtatSolde { get; set; }

        //Relation
        public Facture? Facture { get; set; }
        public int? FactureId { get; set; }
        public Livraison? Livraison { get; set; }
        public int? LivraisonId { get; set; }
        public Paiement? Paiement { get; set; }
        public int? PaiementId { get; set; }
        public Colis Colis { get; set; }
        public virtual ICollection<LigneCommande>? Lignes { get; set; }
    }
}