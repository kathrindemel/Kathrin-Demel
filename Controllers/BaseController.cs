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
    public class BaseController : Controller
    {
        protected SchwimmbadModelContainer db = new SchwimmbadModelContainer();

        private static String GastIdKey = "GastId";
        public Gast setGast()
        {
            int? gastId = Session[GastIdKey] as int?;
            if (gastId == null) return null;
            Gast res = db.GastSet.Find(gastId);
            if (res == null) return null;
            ViewBag.Gast = res;
            _LoggedInGast = res;
            return res;
        }

    private Gast _LoggedInGast = null;
    protected Gast LoggedInGast => _LoggedInGast?? setGast();

    protected bool hasGast()
    {
        return LoggedInGast != null;
    }

    protected void setGastId(int gastId)
    {
        Session[GastIdKey] = gastId;
    }
    }
}
