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
            var model = new AllPostModel();
            return View(model);
        }

        public ActionResult NPost(string id=null)
        {
            if(id == null) {
                @ViewBag.idpost = 0;
                return RedirectToAction("Index");
                //return View(Index);
            }
            else
            {
                var model = new PostModel();
                @ViewBag.idpost = id;
                return View(model);
            }
            //var model = new PostModel();
            //return View();
            
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
