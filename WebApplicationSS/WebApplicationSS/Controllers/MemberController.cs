using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationSS.Models;

namespace WebApplicationSS.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert()
        {
            Member _member = new Member();
            _member.MemberName = Request.Form["MemberName"];
            _member.UserName = Request.Form["Username"];
            _member.Password = Request.Form["Password"];
            _member.Email = Request.Form["Email"];
            MemberDataContext.InsertMember(_member);
            return RedirectToAction("Add");
        }
    }
}