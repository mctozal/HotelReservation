using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hotel_reservation.Models.EntityFramework;

namespace hotel_reservation.Controllers
{
    public class roomsController : Controller
    {
        private hotel_reservationEntities db = new hotel_reservationEntities();

        // GET: rooms
        public ActionResult Index()
        {
            var rooms = db.rooms.Include(r => r.room_type);
            return View(rooms.ToList());
        }

        // GET: rooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            room room = db.rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: rooms/Create
        public ActionResult Create()
        {
            ViewBag.room_type_id = new SelectList(db.room_type, "id", "description");
            return View();
        }

        // POST: rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,number,name,status,smoke,room_type_id")] room room)
        {
            if (ModelState.IsValid)
            {
                db.rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.room_type_id = new SelectList(db.room_type, "id", "description", room.room_type_id);
            return View(room);
        }

        // GET: rooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            room room = db.rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.room_type_id = new SelectList(db.room_type, "id", "description", room.room_type_id);
            return View(room);
        }

        // POST: rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,number,name,status,smoke,room_type_id")] room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.room_type_id = new SelectList(db.room_type, "id", "description", room.room_type_id);
            return View(room);
        }

        // GET: rooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            room room = db.rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            room room = db.rooms.Find(id);
            db.rooms.Remove(room);
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
