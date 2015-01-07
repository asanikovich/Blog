using blogik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogik.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult First()
        {
            return View();
        }


        //public ActionResult Post()
        //{
        //    int id = Convert.ToInt32(Request["id"]);
        //    Console.Write(id);
        //    ViewData["DetailInfo"] = id;
        //    return View();
        //}

        //public ActionResult Last()
        //{
        //    var model = new PostModel();
        //    return View(model);
        //}

    }
}
