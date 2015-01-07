﻿using blogik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogik.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/

        public ActionResult RPost()
        {
            var model = new RPostModel();
            return View(model);
        }

        public ActionResult RComm()
        {
            var model = new RCommModel();
            return View(model);
        }

        public ActionResult Tags()
        {
            var model = new TagModel();
            return View(model);
        }


    }
}
