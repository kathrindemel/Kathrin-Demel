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
    public class SchwimmbahnsController : BaseController
    {
        // GET: Schwimmbahns
        public ActionResult Index()
        {
            return View(db.SchwimmbahnSet.ToList());
        }

        public ActionResult Ansicht()
        {
            return View(db.SchwimmbahnSet.ToList());
        }

        public ActionResult AnsichtVerein()
        {
            return View(db.SchwimmbahnSet.ToList());
        }

        // GET: Schwimmbahns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schwimmbahn schwimmbahn = db.SchwimmbahnSet.Find(id);
            if (schwimmbahn == null)
            {
                return HttpNotFound();
            }
            return View(schwimmbahn);
        }

        // GET: Schwimmbahns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schwimmbahns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Schwimmbahnnummer")] Schwimmbahn schwimmbahn)
        {
            if (ModelState.IsValid)
            {
                db.SchwimmbahnSet.Add(schwimmbahn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schwimmbahn);
        }

        // GET: Schwimmbahns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schwimmbahn schwimmbahn = db.SchwimmbahnSet.Find(id);
            if (schwimmbahn == null)
            {
                return HttpNotFound();
            }
            return View(schwimmbahn);
        }

        // POST: Schwimmbahns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Schwimmbahnnummer")] Schwimmbahn schwimmbahn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schwimmbahn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schwimmbahn);
        }

        // GET: Schwimmbahns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schwimmbahn schwimmbahn = db.SchwimmbahnSet.Find(id);
            if (schwimmbahn == null)
            {
                return HttpNotFound();
            }
            return View(schwimmbahn);
        }

        // POST: Schwimmbahns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schwimmbahn schwimmbahn = db.SchwimmbahnSet.Find(id);
            db.SchwimmbahnSet.Remove(schwimmbahn);
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
