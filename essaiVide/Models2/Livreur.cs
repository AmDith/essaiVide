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
    
    public partial class Livreur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Livreur()
        {
            this.Livraisons = new HashSet<Livraison>();
        }
    
        public int Livreurid { get; set; }
        public string nomLivreur { get; set; }
        public string prenomLivreur { get; set; }
        public string telLivreur { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Livraison> Livraisons { get; set; }
    }
}
