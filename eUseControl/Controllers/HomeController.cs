using eUseControl.Models;
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
        public ActionResult User()
        {
            UserData u = new UserData();
            u.Username = "customer";
            u.Surname = "customer's surname";
            u.PhoneNumber= "1234567890";
            u.Email = "exemple@utm.md";
            u.Appointment = new List<List<string>>();
            u.Appointment.Add(new List<string> {"Март","Пятница", "10.00","409"});
            u.Appointment.Add(new List<string> {"Март","Cуббота", "12.00","429"});
            u.Appointment.Add(new List<string> { "Март", "Пятница", "10.00", "409" });
            u.Notes = "Принесите карточку";
            return View(u);
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
            UserData d = new UserData();
            d.Username = "doctor";
            d.Surname = "dotors's surname";
            d.PhoneNumber = "1234567890";
            d.Email = "exemple@utm.md";
            d.Appointment = new List<List<string>>();
            d.Appointment.Add(new List<string> { "Март", "Пятница", "10.00", "409" });
            d.Appointment.Add(new List<string> { "Март", "Cуббота", "12.00", "429" });
            d.Appointment.Add(new List<string> { "Март", "Пятница", "10.00", "409" });
            d.Notes = "Принесите карточку";
            return View(d);

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