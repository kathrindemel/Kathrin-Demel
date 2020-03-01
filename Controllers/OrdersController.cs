using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchwimmbadLib;
using SchwimmbadWebApplication.Models;

namespace SchwimmbadWebApplication.Controllers
{
    public class OrdersController : BaseController
    {
        private class OrderOrError
        {
            public ActionResult Error;
            public Order Order;
            public OrderOrError (ActionResult error)
            {
                Error = error;
            }
            public OrderOrError(HttpStatusCode errorStatus)
            {
                Error = new HttpStatusCodeResult(errorStatus);
            }
            public OrderOrError(Order order)
            {
                Order = order;
            }
        }
        private OrderOrError GetOrderOrError(int? buchungId, int? schwimmbahnId)
        {
           
            if (buchungId == null)
                return new OrderOrError(HttpStatusCode.BadRequest);
            if (schwimmbahnId == null)
                return new OrderOrError(HttpStatusCode.BadRequest);

            Schwimmbahn schwimmbahn = db.SchwimmbahnSet.Find(schwimmbahnId);
            if (schwimmbahn == null)
                return new OrderOrError(HttpStatusCode.BadRequest);
            Buchung buchung = db.BuchungSet.Find(buchungId);
            if (buchung == null)
                return new OrderOrError(HttpStatusCode.BadRequest);
            return new OrderOrError(new Order()
            { Buchung = buchung, Schwimmbahn = schwimmbahn });
        }


        // GET: Orders
        public ActionResult Index()
        {
            var orders =
                from buchung in db.BuchungSet
                from schwimmbahn in db.SchwimmbahnSet
                where buchung.belegt.Contains(schwimmbahn)
                select new Order()
                { Buchung = buchung, Schwimmbahn = schwimmbahn };
            return View(orders.ToList());
        }
        //var orders = db.Orders.Include(o => o.Buchung).Include(o => o.Schwimmbahn);
        //return View(orders.ToList());
        public ActionResult AnsichtVerein()
        {
            var orders =
                from buchung in db.BuchungSet
                from schwimmbahn in db.SchwimmbahnSet
                where buchung.belegt.Contains(schwimmbahn)
                select new Order()
                { Buchung = buchung, Schwimmbahn = schwimmbahn };
            return View(orders.ToList());
        }

        public ActionResult AnsichtHome()
        {
            var orders =
                from buchung in db.BuchungSet
                from schwimmbahn in db.SchwimmbahnSet
                where buchung.belegt.Contains(schwimmbahn)
                select new Order()
                { Buchung = buchung, Schwimmbahn = schwimmbahn };
            return View(orders.ToList());
        }

        public ActionResult AnsichtMitarbeiter()
        {
            var orders =
                from buchung in db.BuchungSet
                from schwimmbahn in db.SchwimmbahnSet
                where buchung.belegt.Contains(schwimmbahn)
                select new Order()
                { Buchung = buchung, Schwimmbahn = schwimmbahn };
            return View(orders.ToList());
        }


        // GET: Orders/Details/5
        public ActionResult Details(int? buchungId, int? schwimmbahnId)
        {
            var tmp = GetOrderOrError(buchungId, schwimmbahnId);
            if (tmp.Error != null) return tmp.Error;
            return View(tmp.Order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.BuchungId = new SelectList(db.BuchungSet, "Id", "GehörtZu.Name");
            ViewBag.SchwimmbahnId = new SelectList(db.SchwimmbahnSet, "Id", "Schwimmbahnnummer");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BuchungId,SchwimmbahnId")] Order order)
        {
            var tmp = GetOrderOrError(order.BuchungId, order.SchwimmbahnId);
            if (tmp.Error != null) return tmp.Error;
            if (ModelState.IsValid)
            {
                tmp.Order.Buchung.belegt.Add(tmp.Order.Schwimmbahn);
                db.SaveChanges();
                return RedirectToAction("Index", "Buchungs");
            }

            ViewBag.BuchungId = new SelectList(db.BuchungSet, "Id", "GehörtZu.Name", order.BuchungId);
            ViewBag.SchwimmbahnId = new SelectList(db.SchwimmbahnSet, "Id", "Schwimmbahnnummer", order.SchwimmbahnId);
            return View(order);
        }

     
        // GET: Orders/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //}
        //Order order = db.Orders.Find(id);
        //if (order == null)
        //{
        //  return HttpNotFound();
        //}
        //ViewBag.BuchungId = new SelectList(db.BuchungSet, "Id", "Wochentag", order.BuchungId);
        //ViewBag.SchwimmbahnId = new SelectList(db.SchwimmbahnSet, "Id", "Id", order.SchwimmbahnId);
        //return View(order);
        //}

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "BuchungId,SchwimmbahnId")] Order order)
        //{
        //if (ModelState.IsValid)
        //{
        //db.Entry(order).State = EntityState.Modified;
        //db.SaveChanges();
        //return RedirectToAction("Index");
        //}
        //ViewBag.BuchungId = new SelectList(db.BuchungSet, "Id", "GastId", order.BuchungId);
        //ViewBag.SchwimmbahnId = new SelectList(db.SchwimmbahnSet, "Id", "Id", order.SchwimmbahnId);
        //return View(order);
        //}

        // GET: Orders/Delete/5
        public ActionResult Delete(int? buchungId, int? schwimmbahnId)
        {
            var tmp = GetOrderOrError(buchungId, schwimmbahnId);
            if (tmp.Error != null) return tmp.Error;
            return View(tmp.Order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? buchungId, int? schwimmbahnId)
        {
            var tmp = GetOrderOrError(buchungId, schwimmbahnId);
            if (tmp.Error != null) return tmp.Error;
            tmp.Order.Buchung
                .belegt.Remove(tmp.Order.Schwimmbahn);
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
