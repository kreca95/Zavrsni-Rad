//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zavrsni2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kosara
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kosara()
        {
            this.KosaraProizvod = new HashSet<KosaraProizvod>();
        }
    
        public int ID { get; set; }
        public Nullable<System.DateTime> Datum { get; set; }
        public string Cookie { get; set; }
        public string JeLiKupljeno { get; set; }
        public string Email { get; set; }
        public Nullable<bool> JeLiIsporuceno { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KosaraProizvod> KosaraProizvod { get; set; }
    }
}
