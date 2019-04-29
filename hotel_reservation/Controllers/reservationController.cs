﻿using System;
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
        private hotel_reservationEntities3 db = new hotel_reservationEntities3();

       // GET: reservation
        public ActionResult Index()
        {
            var reservations = db.reservation.Include(r => r.guest);
            return View(reservations.ToList());
        }

       // GET: reservation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservation.Find(id);
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
                

                Random rnd = new Random();
                int num = rnd.Next(1, 10000);
                misafir.id = num;
               
               
                misafir.e_mail = reservation.e_mail;
                misafir.first_name = reservation.first_name;
                misafir.last_name = reservation.last_name;
                misafir.phone_number = reservation.phone_number;
                db.guest.Add(misafir);
                db.SaveChanges();

                var rezervasyon = new reservation();
                int generated = rezervasyon.GetHashCode();
                rezervasyon.id = generated;
                rezervasyon.guest_id = num;
                rezervasyon.date_in = DateTime.Now;
                rezervasyon.date_out = DateTime.Now.AddDays(10);
                rezervasyon.status = "true";
                rezervasyon.made_by = reservation.first_name + " " + reservation.last_name;
       

                db.reservation.Add(rezervasyon);
                db.SaveChanges();

                //Database kayıt  işlemi
                //db.Entry(reservation).State = EntityState.Modified;
                //oda durumunun değiştiği yer
                var room = db.room.Find(id);
                room.status = "false";



                db.SaveChanges();
                return RedirectToAction("Create", "CreditCards" , new { id = id });
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
            reservation reservation = db.reservation.Find(id);
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
            ViewBag.guest_id = new SelectList(db.guest, "id", "first_name", reservation.guest_id);
            return View(reservation);
        }

        // GET: reservation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservation.Find(id);
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
            reservation reservation = db.reservation.Find(id);
            db.reservation.Remove(reservation);
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
