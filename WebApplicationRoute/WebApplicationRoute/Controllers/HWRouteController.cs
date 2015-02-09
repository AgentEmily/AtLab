using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationRoute.Controllers
{
    [RoutePrefix("blog")]
    public class HWRouteController : Controller
    {
        // GET: HWRoute
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult BlogByYear(string year)
        {
            ViewBag.message =  year;
            return View();
        }

        public ActionResult BlogByMonth(string year, string month)
        {
            ViewBag.message = year+"/"+month;
            return View();
        }

        [Route(@"{year:regex(\d{4})}/{month:regex(\d{2})}/{day:regex(\d{2})}")] 
        public ActionResult BlogByDay(string year, string month, string day)
        {
            ViewBag.message = year + "/" + month+"/"+day;
            return View();
        }

        [Route(@"{tag:regex([A-Za-z]+)}")]
        public ActionResult BlogByTag(string tag)
        {
            ViewBag.message = tag;
            return View();
        }
    }
}