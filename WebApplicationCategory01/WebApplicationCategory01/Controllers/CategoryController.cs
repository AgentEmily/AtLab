using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationCategory01.Models;

namespace WebApplicationCategory01.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            List<Category> categories = CategoryDataContext.LoadCategories();
            return View(categories);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]//接收USER輸入的新增資料
        public ActionResult Insert()
        {
            Category _category = new Category();
            _category.CategoryName = Request.Form["CategoryName"];
            _category.Description = Request.Form["Description"];
            CategoryDataContext.InsertCategory(_category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id = 1) //去要該id的資料 id這個名字要跟route的對應
        {

            Category _category = CategoryDataContext.LoadCategorieByID(id);
            return View(_category);

        }
        [HttpPost]
        public ActionResult Edit()//接收user修改的內容
        {
            Category _category = new Category();
            _category.CategoryID = Convert.ToInt32(Request.Form["CategoryID"]);
            _category.CategoryName = Request.Form["CategoryName"];
            _category.Description = Request.Form["Description"];

            CategoryDataContext.EditCategory(_category);
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            CategoryDataContext.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}