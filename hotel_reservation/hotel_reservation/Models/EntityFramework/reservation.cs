//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hotel_reservation.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class reservation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public reservation()
        {
            this.reserved_room = new HashSet<reserved_room>();
        }
    
        public int id { get; set; }
        public System.DateTime date_in { get; set; }
        public System.DateTime date_out { get; set; }
        public string status { get; set; }
        public string made_by { get; set; }
        public Nullable<int> guest_id { get; set; }
    
        public virtual guest guest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reserved_room> reserved_room { get; set; }
    }
}
