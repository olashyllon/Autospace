using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Myvehiclespazes.Models;

namespace Myvehiclespazes.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rentals
        public ActionResult Index()
        {
            var rentals = db.Rentals.Include(r => r.Customer).Include(r => r.Vehicle);
            return View(rentals.ToList());
        }

        // GET: Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // GET: Rentals/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Email");
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "ModelName");
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalId,RentalDate,ReturnDate,VehicleId,CustomerId,Returned,Available")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                rental.Returned = false;
                rental.Invoiced = true;

                var vehicles = db.Vehicles;


                foreach (var vehicle in vehicles)
                {
                    vehicle.Available = false;
                }

                
                db.Rentals.Add(rental);
                db.SaveChanges();
                return RedirectToAction("Index");

                
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Email", rental.CustomerId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "ModelName", rental.VehicleId);
            //ViewBag.RentalId = new SelectList(db.Rentals, "RentalId", "RentalAmount", rental.RentalId);
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Email", rental.CustomerId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "ModelName", rental.VehicleId);
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalId,RentalDate,ReturnDate,VehicleId,CustomerId,Returned,Invoiced")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                rental.Returned = true;
                
                db.Entry(rental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Email", rental.CustomerId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "ModelName", rental.VehicleId);
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rental rental = db.Rentals.Find(id);
            db.Rentals.Remove(rental);
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
