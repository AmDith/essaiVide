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
    
    public partial class Versement
    {
        public int Versementid { get; set; }
        public string numeroV { get; set; }
        public Nullable<System.DateTime> dateVers { get; set; }
        public Nullable<double> montantVers { get; set; }
        public int Clientid { get; set; }
    
        public virtual Client Client { get; set; }
    }
}
