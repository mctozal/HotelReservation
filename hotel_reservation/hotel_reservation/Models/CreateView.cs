using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotel_reservation.Models
{
    public class CreateView
    {
        // Bu kısım rezevasyona gelicek
        public string date_in { get; set; }
        public string date_out { get; set; }
        public string first_name { get; set; }
        //Bu kısım gueste gidicek
        public string last_name { get; set; }
        public string e_mail { get; set; }
        public string phone_number { get; set; }

    }
}