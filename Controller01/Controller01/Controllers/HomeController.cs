using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Controller01.Models;

namespace Controller01.Controllers
{
    public class HomeController : Controller
    {
        private northwindEntities db = new northwindEntities();
        // GET: Home
        public ActionResult Index(int id=1)
        {

            return View(db.Products.Where(p=> p.CategoryID==id).ToList());
        }

        [ChildActionOnly]
        public ActionResult Categories()
        {
            return PartialView(db.Categories.ToList());

        }

        public ActionResult CategoriesList()
        {
            var q = from c in db.Categories
                    select new { c.CategoryID, c.CategoryName };
            return Json(q, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductList(int id=1)
        {
            var q = from c in db.Products
                    where c.CategoryID == id
                    select new { c.ProductID, c.ProductName, c.UnitPrice, c.UnitsInStock };//一定要select new才成功
            return Json(q, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Browse()
        {
            return View();
        }
    }
}