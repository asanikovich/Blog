﻿using blogik.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace blogik.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        //[Authorize]
        //public ActionResult Index()
        //{
        //    if (1 == 1) return RedirectToAction("LogIn");
        //    //return View();
        //}

        public ActionResult LogIn()
        {
            @ViewBag.url = Request.QueryString["ReturnUrl"];
            
            //string hash = "1";
            //var cookie = new HttpCookie("hash", hash);
            //cookie.Expires = DateTime.Now.AddDays(30);
            //Response.Cookies.Add(cookie);

            //if (Request.Cookies["hash"] != null) ;
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string login, string pass, string zap, string url)
        {
            using (var DB = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                var provider = new SHA1CryptoServiceProvider();
                byte[] bytes = Encoding.UTF8.GetBytes(pass);
                string result = Convert.ToBase64String(provider.ComputeHash(bytes));
                DB.Open();
                using (var query = new SqlCommand(String.Format(@"SELECT id_admin FROM admin
                                WHERE login=@login AND pass=@pass")))
                {
                    query.Connection = DB;
                    query.Parameters.Add(new SqlParameter("login", login));
                    query.Parameters.Add(new SqlParameter("pass", result));
                    using (var reader = query.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            FormsAuthentication.SetAuthCookie("AlSan", true);
                        }
                    }
                }
            }
            return RedirectPermanent(url);
        }

        public ActionResult LogOut()
        {
            Response.Cookies.Clear();
            return View();
        }

        //[HttpGet] TODO
        [Authorize(Users="AlSan")]
        public ActionResult Edit(int id)
        {
            var model = new AEditModel(id);    //string url = Request.QueryString["url"];
            return View(model);
        }

        [Authorize(Users = "AlSan")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPost(string name, string post, string url)
        {
            var model = new AddPost(name, post, url);
            return RedirectToAction("Index","Home");
        }

        [Authorize(Users = "AlSan")]
        public ActionResult Add()
        {
            return View();
        }

        [Authorize(Users = "AlSan")]
        public ActionResult DelComm()
        {
            return View();
        }

        [Authorize(Users = "AlSan")]
        public ActionResult DelPost()
        {
            return View();
        }
    }
}
