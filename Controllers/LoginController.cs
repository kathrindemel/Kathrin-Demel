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
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View(db.GastSet.ToList());
        }

        // GET: Login/Select-Funktion
        public ActionResult Select(int? id)
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
            setGastId(id.Value);
            if (LoggedInGast.Verein == true)
            {
                return RedirectToAction("Verein", "Home");
            }
            if (LoggedInGast.Mitarbeiter == true)
            {
                return RedirectToAction("Mitarbeiter", "Home");
            }

            return RedirectToAction("Index");
        }
 
    }
}
