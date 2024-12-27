using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Application.Validator;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Le nom doit avoir au moins 5 caractères et inférieur à 20 caractères")]
        [UniqueSurnom(ErrorMessage = "Ce nom existe déja")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Le prenom est obligatoire")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Le prenom doit avoir au moins 5 caractères et inférieur à 20 caractères")]
        [UniquePrenom(ErrorMessage = "Ce prenom existe déja")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Le téléphone est obligatoire")]
        [RegularExpression(@"^(77|78|76)[0-9]{7}$", ErrorMessage = "Le téléphone doit commencer par 77 ou 78 ou 76 et doit avoir au 9 chiffres")]
        public string Tel { get; set; }
        public string? Adresse { get; set; }
        public Double Solde { get; set; }



        // Relation
        public User? User { get; set; }
        public int? UserId { get; set; }
        public virtual ICollection<Commande>? Commandes { get; set; }
        public virtual ICollection<Versement> Versements { get; set; }

    }
}