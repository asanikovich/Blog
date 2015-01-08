using blogik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogik.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            if (1 == 1) return RedirectToAction("LogIn");
            //return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            return View();
        }

        //[HttpGet] TODO
        public ActionResult Edit()
        {
            string url = Request.QueryString["url"];
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPost(string name, string post, string url)
        {
            var model = new AddPost(name, post, url);
            return RedirectToAction("Index","Home");
        }

        public ActionResult Add()
        {
            return View();
        }
    }
}
