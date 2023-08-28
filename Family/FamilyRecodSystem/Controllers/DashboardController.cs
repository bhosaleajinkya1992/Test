using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyRecodSystem.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult CreateApplication()
        {
            return View();
        }
        public ActionResult SearchApplication()
        {
            return View();
        }
    }
}