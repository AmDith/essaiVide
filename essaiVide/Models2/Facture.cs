//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Examen.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Facture
    {
        public int Factureid { get; set; }
        public string numero { get; set; }
        public Nullable<System.DateTime> dateF { get; set; }
    
        public virtual Commande Commande { get; set; }
    }
}
