using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le login est obligatoire")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Le login doit avoir au moins 5 caractères et inférieur à 40 caractères")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Le password est obligatoire")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Le password doit avoir au moins 6 caractères")]
        public string Password { get; set; }

        // Relation
        public Role? Role { get; set; }
        public int? RoleId { get; set; }
        public virtual ICollection<Commande>? Commandes { get; set; }
        public virtual ICollection<Produit>? Produits { get; set; }
    }
}