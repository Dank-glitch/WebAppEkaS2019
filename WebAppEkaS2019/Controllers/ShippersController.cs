using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using WebAppEkaS2019.Models;

namespace WebAppEkaS2019.Controllers
{
    public class ShippersController : Controller
    {
        northwindEntities1 db = new northwindEntities1();
        // GET: Shippers
        public ActionResult Index()
        {
            var shipperit = db.Shippers.Include(s => s.Region);
            return View(shipperit.ToList());
        }


        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Shippers shipperi = db.Shippers.Find(id);
            if (shipperi == null) return HttpNotFound();
            ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription", shipperi.RegionID);
            return View(shipperi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipperID, CompanyName, Phone, RegionID")] Shippers shipperi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipperi).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription", shipperi.RegionID);
                return RedirectToAction("Index");
            }
            return View(shipperi);
        }

        public ActionResult Create()
        {
            ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription", null);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipperID, CompanyName, Phone, RegionID")] Shippers shipperi)
        {
            if (ModelState.IsValid)
            {
                db.Shippers.Add(shipperi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipperi);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Shippers shipperi = db.Shippers.Find(id);
            if (shipperi == null) return HttpNotFound();


            return View(shipperi);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Shippers shipperi = db.Shippers.Find(id);
            db.Shippers.Remove(shipperi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}