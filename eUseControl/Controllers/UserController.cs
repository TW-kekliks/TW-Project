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
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.User;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI;

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
                
                
                return View(u);
        }

        [HttpGet]

        public ActionResult doctor()
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
            
            
            return View(u);
        }

        public ActionResult appointment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult appointment(AppointmentRegistration model)
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
            if (ModelState.IsValid)
            {
                using (var db = new AppointmentContext())
                {
                    if (db.Users.Any(u => u.Time == model.Time && u.Doctor == model.Doctor && u.Date == model.Date))
                    {
                        ModelState.AddModelError("Notes", "Этот врач занят в это время");
                        return View(model);
                    }

                    var user = new ADbTable
                    {
                        Email = profile.Email,
                        Doctor= model.Doctor,
                        Service = model.Service,
                        Date = model.Date,
                        Time = model.Time,
                        Notes = model.Notes,
                    };
                    switch (model.Doctor)
                    {
                        case Domain.Entities.Enums.Doctors.SomovOleg:
                            user.DEmail = "somov675@gmail.com";
                            user.Room = Domain.Entities.Enums.Rooms.Room1;
                            break;
                        case Domain.Entities.Enums.Doctors.ShatiloAlexandr:
                            user.DEmail = "shatilo@mail.ru";
                            user.Room = Domain.Entities.Enums.Rooms.Room2;
                            break;
                    }
                    db.Users.Add(user);
                    db.SaveChanges();

                    
                    return RedirectToAction("user", "User");
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Comment(string text)
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
            if (text!=null)
            {
                using (var db = new CommentContext())
                {
                    if (db.Comment.Any(u => u.Email == profile.Email && u.Status!= Domain.Entities.Enums.ARole.REJECTED ))
                    {
                        ModelState.AddModelError("Notes", "Вы уже оставили отзыв, дождитесь пока он будет рассмотрен");
                        return RedirectToAction("user", "User");
                    }

                    var comment = new CDbTable
                    {
                        Email = profile.Email,
                        Text= text,
                        Status = Domain.Entities.Enums.ARole.NOTSELECTED
                    };
             
                    db.Comment.Add(comment);
                    db.SaveChanges();

                    
                    return RedirectToAction("user", "User");
                }
            }
            else
            {
                ModelState.AddModelError("Notes", "Поле пустое");
                return RedirectToAction("user", "User");
            }

        }

    }
}