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
    
    public partial class room
    {
        
        public int id { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public bool smoke { get; set; }
        public Nullable<int> room_type_id { get; set; }
    
        public virtual room_type room_type { get; set; }
    }
}