using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hotel_reservation.Models;
using hotel_reservation.Models.EntityFramework;

namespace hotel_reservation.Controllers
{
    public class reservationController : Controller
    {
        private hotel_reservationEntities db = new hotel_reservationEntities();

        // GET: reservation
        //public ActionResult Index()
        //{
        //    var reservations = db.reservations.Include(r => r.guest);
        //    return View(reservations.ToList());
        //}

        // GET: reservation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: reservation/Create
        public ActionResult Create(int? id)
        {
            return View();
        }

        // POST: reservation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(CreateView reservation, int? id)
        {
            if (ModelState.IsValid)
            {
                var misafir = new guest();
                misafir.id = 45;
                misafir.e_mail = reservation.e_mail;
                misafir.first_name = reservation.first_name;
                misafir.last_name = reservation.last_name;
                misafir.phone_number = reservation.phone_number;
                db.guests.Add(misafir);
                db.SaveChanges();

                var rezervasyon = new reservation();
                rezervasyon.date_in = DateTime.Now;
                rezervasyon.date_out = DateTime.Now.AddDays(10);
                rezervasyon.guest_id = misafir.id;
                rezervasyon.status = "true";
                rezervasyon.made_by = reservation.first_name + " " + reservation.last_name;
       
                db.reservations.Add(rezervasyon);
                db.SaveChanges();
                //Database kayıt  işlemi
                //db.Entry(reservation).State = EntityState.Modified;

                //oda durumunun değiştiği yer

                var room = db.rooms.Find(id);
                room.status = "false";

                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // GET: reservation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: reservation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(reservation reservation)
        {
            if (ModelState.IsValid)
            {
                //Database kayıt  işlemi
                db.Entry(reservation).State = EntityState.Modified;

                //oda durumunun değiştiği yer

                db.SaveChanges();


                return RedirectToAction("Index");
            }
            ViewBag.guest_id = new SelectList(db.guests, "id", "first_name", reservation.guest_id);
            return View(reservation);
        }

        // GET: reservation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reservation reservation = db.reservations.Find(id);
            db.reservations.Remove(reservation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
