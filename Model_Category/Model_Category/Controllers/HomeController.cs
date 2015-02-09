using Model_Category.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Model_Category.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home 
        NorthwindModel db = new NorthwindModel();
        public ActionResult Index()
        {
           
            return View(db.Categories.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]//接收USER輸入的新增資料
        public ActionResult Insert()
        {
            Categories _category = new Categories();
            _category.CategoryName = Request.Form["CategoryName"];
            _category.Description = Request.Form["Description"];
            db.Entry(_category).State = EntityState.Added;
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id = 1) //去要該id的資料 id這個名字要跟route的對應
        {

            
            return View(db.Categories.Where(c=>c.CategoryID==id).First());

        }
        [HttpPost]
        public ActionResult Edit()//接收user修改的內容
        {
            Categories _category = new Categories();
            _category.CategoryID = Convert.ToInt32(Request.Form["CategoryID"]);
            _category.CategoryName = Request.Form["CategoryName"];
            _category.Description = Request.Form["Description"];

            db.Entry(_category).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {

            Categories _category = (from c in db.Categories
                                    where c.CategoryID == id
                                    select c).First();
            db.Entry(_category).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}