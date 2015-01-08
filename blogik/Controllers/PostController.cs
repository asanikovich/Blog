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

        public ActionResult Index(int id=1)
        {
            var model = new AllPostModel(id);
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
        }

        [HttpPost]
        public ActionResult Search()
        {
            string s_zapros = Request.Form["search"];
            //string s_zapros = Request.QueryString["search"];
            var model = new AllPostModel(s_zapros);
            return View(model);
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
