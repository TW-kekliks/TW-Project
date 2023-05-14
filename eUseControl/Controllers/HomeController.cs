using AutoMapper;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
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
        private readonly ISession _session;
        public HomeController()
        {
            var bl = new BusinessLogic.BussinesLogic();
            _session = bl.GetSessionBL();
        }
        public ActionResult Index()
        {
            SessionStatus();
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                return View(profile);
            }
            var empty = new UserMinimal();
            empty.Level = Domain.Entities.Enums.URole.UNAUTHORIZED;
            return View(empty);
        }
        public ActionResult Contact()
        {
            SessionStatus();
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                return View(profile);
            }
            var empty = new UserMinimal();
            empty.Level = Domain.Entities.Enums.URole.UNAUTHORIZED;
            return View(empty);
        }
        public ActionResult about()
        {
            SessionStatus();
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                return View(profile);
            }
            var empty = new UserMinimal();
            empty.Level = Domain.Entities.Enums.URole.UNAUTHORIZED;
            return View(empty);
        }
        public ActionResult Price()
        {
            SessionStatus();
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                return View(profile);
            }
            var empty = new UserMinimal();
            empty.Level = Domain.Entities.Enums.URole.UNAUTHORIZED;
            return View(empty);
        }

        public ActionResult testimonial()
        {
            SessionStatus();
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                return View(profile);
            }
            var empty = new UserMinimal();
            empty.Level = Domain.Entities.Enums.URole.UNAUTHORIZED;
            return View(empty);
        }

        public ActionResult service()
        {
            SessionStatus();
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                return View(profile);
            }
            var empty = new UserMinimal();
            empty.Level = Domain.Entities.Enums.URole.UNAUTHORIZED;
            return View(empty);
        }

        public ActionResult team()
        {
            SessionStatus();
            var apiCookie = Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                return View(profile);
            }
            var empty = new UserMinimal();
            empty.Level = Domain.Entities.Enums.URole.UNAUTHORIZED;
            return View(empty);
        }
  

    }
}