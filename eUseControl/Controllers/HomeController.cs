using eUseControl.Models;
using eUseControl.Web.Controllers;
using eUseControl.Web.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace eUseControl.Controllers
{
    public class HomeController :BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"]!="login")
            {
                return RedirectToAction("SignIn", "Login");
            }
            var user = System.Web.HttpContext.Current.GetMySessionObject();
            UserData u = new UserData()
            {
                UserName = user.Name,
                UserSurname = user.Surname,
                Appointment = new List<List<string>>
                { new List<string> { }

                }
            };
            return View(u);
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
        public ActionResult User()
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

        public ActionResult Doctor_page()
        {
            return View();

        }

        public ActionResult team()
        {
            return View();
        }


    }
}