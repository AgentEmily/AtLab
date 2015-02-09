using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationRoute.Controllers
{
    [RoutePrefix("Books")]
    [Route("{action=About}")]//Books 跑哪一個action
    public class test01Controller : Controller
    {
        // GET: test01
        
        
        [Route("Book")]
        public ActionResult Index()
        {
            ViewBag.header = "header";
            return View();
        }
   
        public ActionResult About()
        {
            
            return View();
        }
    }
}