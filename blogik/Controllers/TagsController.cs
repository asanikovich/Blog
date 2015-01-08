using blogik.Models;
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
            return RedirectToAction("Index", "Home");
        }

        public ActionResult NTags(string id = null)
        {
            if (id == null)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                var model = new TagNameModel(id);
                return View(model);
            }
        }

    }
}
