using hotel_reservation.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hotel_reservation.Models
{
    public class RoomsView
    {
        public int id { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public bool smoke { get; set; }
        public Nullable<int> room_type_id { get; set; }

        public string room_type { get; set; }
        public string url { get; set; }
    }
}