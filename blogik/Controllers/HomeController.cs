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

        [HttpPost]
        public ActionResult AddComm()
        {
            string name = Request.Form["author"];
            string comm = Request.Form["comment"];
            string id1 = Request.Form["comment_post_ID"];
            string url = Request.Form["url_now"];
            var model = new AddComm(name, comm, id1);
            
            //if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(comm)) ; // TODO ADD DO TB
            return RedirectToAction("NPost", "Post", new { id = url });
        }


    }
}

//<a href="@Url.RouteUrl("Post", new { Controller = "Post", action = "NPost", id = @item.url } )">@item.name</a>