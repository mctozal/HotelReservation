using hotel_reservation.Models;
using hotel_reservation.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace hotel_reservation.Controllers
{

    public class HomeController : Controller
    {
        hotel_reservationEntities3 db = new hotel_reservationEntities3();

        
        // GET: Home

        public ActionResult Index()
        {
            
            
            return View();

        }


        public ActionResult Rooms()
        {
            var rooms = db.room.ToList();


            List<RoomsView> model = new List<RoomsView>();
            rooms.ForEach(item =>
            {

                var roomsView = new RoomsView();
                roomsView.id = item.id;
                roomsView.name = item.name;
                roomsView.number = item.number;
                roomsView.room_type = item.room_type.description;
                roomsView.smoke = item.smoke;
                roomsView.status = item.status;

                string adres = "/Content/img/" + item.id + ".jpg";
                roomsView.url = adres;

                model.Add(roomsView);
            });

            //List<room> odalar = new List<room>();

            //List<string> url = new List<string>();

            //odalar.Add(room1);
            //odalar.Add(room2);
            return View(model);
        }




        [HttpPost]
        public ActionResult HotelReservation(int? id, string name)
        {

            return View();
        }
        public ActionResult About()
        {
            return View();
        }

       
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin(AdminLogin admin)
        {

            if (admin.username == "admin" && admin.password == "password")
            {

                return RedirectToAction("Index","Admin");
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }
    }
}