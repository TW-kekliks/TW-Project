﻿using eUseControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace eUseControl.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult about()
        {
            return View();
        }
        public ActionResult Price()
        {
            return View();
        }

        public ActionResult testimonial()
        {
            return View();
        }
        public ActionResult appointment()
        {
            return View();
        }
        public ActionResult service()
        {
            return View();
        }

        public ActionResult team()
        {
            return View();
        }
        public ActionResult sign_in()
        {
            return View();
        }
        public ActionResult sign_up()
        {
            return View();
        }

    }
}