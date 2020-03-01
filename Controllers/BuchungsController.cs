using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchwimmbadLib;

namespace SchwimmbadWebApplication.Controllers
{
    public class BuchungsController : BaseController
    {
        // GET: Buchungs
        public ActionResult Index()
        {
            var buchungSet = db.BuchungSet.Include(b => b.GehörtZu);
            return View(buchungSet.ToList());
        }

        public ActionResult IndexVerein()
        {
            var buchungSet = db.BuchungSet.Include(b => b.GehörtZu);
            return View(buchungSet.ToList());
        }

        public ActionResult IndexMitarbeiter()
        {
            var buchungSet = db.BuchungSet.Include(b => b.GehörtZu);
            return View(buchungSet.ToList());
        }

        // GET: Buchungs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buchung buchung = db.BuchungSet.Find(id);
            if (buchung == null)
            {
                return HttpNotFound();
            }
            return View(buchung);
        }

        // GET: Buchungs/Create
        public ActionResult Create()
        {
            ViewBag.GastId = new[] {new SelectListItem()
            {Text ="keiner", Value = "" } }.Union(new SelectList(db.GastSet, "Id", "Name"));
            return View();
        }

        // POST: Buchungs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Wochentag,Beginn,Ende,Starttermin,Endtermin,GastId,Schwimmbahnanzahl")] Buchung buchung)
        {
            if (ModelState.IsValid)
            {
                db.BuchungSet.Add(buchung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GastId = new SelectList(db.GastSet, "Id", "Name", buchung.GastId);
            return View(buchung);
        }


        public ActionResult CreateVerein()
        {
            ViewBag.GastId = new[] {new SelectListItem()
            {Text ="keiner", Value = "" } }.Union(new SelectList(db.GastSet, "Id", "Name"));
            return View();
        }

        // POST: Buchungs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVerein([Bind(Include = "Id,Wochentag,Beginn,Ende,Starttermin,Endtermin,GastId,Schwimmbahnanzahl")] Buchung buchung)
        {
            if (ModelState.IsValid)
            {
                db.BuchungSet.Add(buchung);
                db.SaveChanges();
                return RedirectToAction("Verein", "Home");
            }

            ViewBag.GastId = new SelectList(db.GastSet, "Id", "Name", buchung.GastId);
            return View(buchung);
        }


        public ActionResult CreateMitarbeiter()
        {
            ViewBag.GastId = new[] {new SelectListItem()
            {Text ="keiner", Value = "" } }.Union(new SelectList(db.GastSet, "Id", "Name"));
            return View();
        }

        // POST: Buchungs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMitarbeiter([Bind(Include = "Id,Wochentag,Beginn,Ende,Starttermin,Endtermin,GastId,Schwimmbahnanzahl")] Buchung buchung)
        {
            if (ModelState.IsValid)
            {
                db.BuchungSet.Add(buchung);
                db.SaveChanges();
                return RedirectToAction("Mitarbeiter", "Home");
            }

            ViewBag.GastId = new SelectList(db.GastSet, "Id", "Name", buchung.GastId);
            return View(buchung);
        }


        // GET: Buchungs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buchung buchung = db.BuchungSet.Find(id);
            if (buchung == null)
            {
                return HttpNotFound();
            }
            ViewBag.GastId = new SelectList(db.GastSet, "Id", "Name", buchung.GastId);
            return View(buchung);
        }

        // POST: Buchungs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Wochentag,Beginn,Ende,Starttermin,Endtermin,GastId,Schwimmbahnanzahl")] Buchung buchung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buchung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexMitarbeiter");
            }
            ViewBag.GastId = new SelectList(db.GastSet, "Id", "Name", buchung.GastId);
            return View(buchung);
        }

        // GET: Buchungs/Edit/5
        public ActionResult EditVerein(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buchung buchung = db.BuchungSet.Find(id);
            if (buchung == null)
            {
                return HttpNotFound();
            }
            ViewBag.GastId = new SelectList(db.GastSet, "Id", "Name", buchung.GastId);
            return View(buchung);
        }

        // POST: Buchungs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditVerein([Bind(Include = "Id,Wochentag,Beginn,Ende,Starttermin,Endtermin,GastId,Schwimmbahnanzahl")] Buchung buchung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buchung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexVerein");
            }
            ViewBag.GastId = new SelectList(db.GastSet, "Id", "Name", buchung.GastId);
            return View(buchung);
        }

        // GET: Buchungs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buchung buchung = db.BuchungSet.Find(id);
            if (buchung == null)
            {
                return HttpNotFound();
            }
            return View(buchung);
        }

        // POST: Buchungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Buchung buchung = db.BuchungSet.Find(id);
            db.BuchungSet.Remove(buchung);
            db.SaveChanges();
            return RedirectToAction("IndexMitarbeiter");
        }

        // GET: Buchungs/Delete/5
        public ActionResult DeleteVerein(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buchung buchung = db.BuchungSet.Find(id);
            if (buchung == null)
            {
                return HttpNotFound();
            }
            return View(buchung);
        }

        // POST: Buchungs/Delete/5
        [HttpPost, ActionName("DeleteVerein")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVereinConfirmed(int id)
        {
            Buchung buchung = db.BuchungSet.Find(id);
            db.BuchungSet.Remove(buchung);
            db.SaveChanges();
            return RedirectToAction("IndexVerein");
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
