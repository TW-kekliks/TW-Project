using eUseControl.Models;
using eUseControl.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace eUseControl.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            SessionStatus();
            return View();
        }
        public ActionResult Contact()
        {
            SessionStatus();
            return View();
        }
        public ActionResult about()
        {
            SessionStatus();
            return View();
        }
        public ActionResult Price()
        {
            SessionStatus();
            return View();
        }

        public ActionResult testimonial()
        {
            SessionStatus();
            return View();
        }

        public ActionResult service()
        {
            SessionStatus();
            return View();
        }

        public ActionResult team()
        {
            SessionStatus();
            return View();
        }
  

    }
}