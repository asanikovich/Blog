using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogik.Controllers
{
    public class TagsController : Controller
    {
        //
        // GET: /Tags/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NTags(string id = null)
        {
            if (id == null)
            {
                @ViewBag.idpost = 0;
                return RedirectToAction("Index","Home");
            }
            else
            {
                @ViewBag.idpost = id;
                //return View(); TODO
                return RedirectToAction("Index","Post");
            }
        }

    }
}
