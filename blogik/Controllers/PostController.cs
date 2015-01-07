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

        public ActionResult Index()
        {
            var model = new AllPostModel();
            return View(model);
        }

        public ActionResult NPost(string id=null)
        {
            if(id == null) {
                return RedirectToAction("Index");
            }
            else
            {
                var model = new PostModel(id);
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

    }
}
