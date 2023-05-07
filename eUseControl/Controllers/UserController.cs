using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.Models;
using Microsoft.Ajax.Utilities;
using eUseControl.Helpers;
using eUseControl.Web.Extension;

namespace eUseControl.Controllers
{
    public class UserController : Controller
    {
        private readonly ISession _session;

        public UserController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        [HttpGet]

        public ActionResult user()
        {
            var apiCookie = Request.Cookies["X-KEY"];
                var profile = _session.GetUserByCookie(apiCookie.Value);
            if (profile != null)
            {
                System.Web.HttpContext.Current.SetMySessionObject(profile);
                System.Web.HttpContext.Current.Session["LoginStatus"] = "login";
            }
            else
            {
                System.Web.HttpContext.Current.Session.Clear();
                if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("X-KEY"))
                {
                    var cookie = ControllerContext.HttpContext.Request.Cookies["X-KEY"];
                    if (cookie != null)
                    {
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    }
                }
            }
                UserData u = new UserData();
                u.FirstName = profile.FirstName;
                u.LastName = profile.LastName;
                u.PhoneNumber = profile.Number;
                u.Email = profile.Email;
                u.Appointment = new List<List<string>>();
                u.Appointment.Add(new List<string> { "Март", "Пятница", "10.00", "409" });
                u.Appointment.Add(new List<string> { "Март", "Cуббота", "12.00", "429" });
                u.Appointment.Add(new List<string> { "Март", "Пятница", "10.00", "409" });
                u.Notes = "Принесите карточку";
                return View(u);
        }
    }
}