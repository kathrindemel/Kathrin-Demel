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
    public class GastsController : BaseController
    {
        // GET: Gasts
        public ActionResult Index()
        {
            return View(db.GastSet.ToList());
        }

        // GET: Gasts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gast gast = db.GastSet.Find(id);
            if (gast == null)
            {
                return HttpNotFound();
            }
            return View(gast);
        }

        // GET: Gasts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gasts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Verein,Mitarbeiter")] Gast gast)
        {
            if (ModelState.IsValid)
            {
                db.GastSet.Add(gast);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gast);
        }



        public ActionResult CreateHome()
        {
            return View();
        }

        // POST: Gasts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHome([Bind(Include = "Id,Name,Verein,Mitarbeiter")] Gast gast)
        {
            if (ModelState.IsValid)
            {
                db.GastSet.Add(gast);
                db.SaveChanges();
                return RedirectToAction("Index", "Login");
            }

            return View(gast);
        }

        // GET: Gasts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gast gast = db.GastSet.Find(id);
            if (gast == null)
            {
                return HttpNotFound();
            }
            return View(gast);
        }

        // POST: Gasts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Verein,Mitarbeiter")] Gast gast)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gast).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gast);
        }

        // GET: Gasts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gast gast = db.GastSet.Find(id);
            if (gast == null)
            {
                return HttpNotFound();
            }
            return View(gast);
        }

        // POST: Gasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gast gast = db.GastSet.Find(id);
            db.GastSet.Remove(gast);
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
