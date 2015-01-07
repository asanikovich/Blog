using blogik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogik.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = new PostModel();
            @ViewBag.idpost = 0;
            return View(model);
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult AddComm()
        {
            string name = Request.Form["author"];
            string comm = Request.Form["comment"];

            return RedirectToAction("Index");
        }


    }
}
