using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationRoute.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string p1, string p2)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string p1, string p2)
        {
            ViewBag.Message = "Your contact page"+p1;
            ViewBag.Title = p2;

            return View();
        }
    }
}