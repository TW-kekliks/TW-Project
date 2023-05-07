using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace eUseControl.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;
        public LoginController()
        {
            var bl = new BusinessLogic.BussinesLogic();
            _session = bl.GetSessionBL(); 
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<UserLogin, ULoginData>());
                var data = Mapper.Map<ULoginData>(model);

                data.LoginIp = Request.UserHostAddress;
                data.LoginDateTime = DateTime.Now;

                var userLogin = _session.UserLogin(data);
                if (userLogin.Status)
                {
                    HttpCookie cookie = _session.GenCookie(model.Email);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    return RedirectToAction("user", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View();
                }
            }

            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserRegistration login)
        {

            if (ModelState.IsValid) 
            {
                ULoginData data = new ULoginData
                {
                    Username = login.Username,
                    Email = login.Email,
                    Password = login.Password,
                    LoginIp = Request.UserHostAddress,
                    LoginDateTime= DateTime.Now
                };
                if (data.Password == login.ConfirmPassword)
                {
                    var userLogin = _session.UserLogin(data);
                    if (userLogin.Status)
                    {
                       HttpCookie cookie = _session.GenCookie(login.Email);
                       ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                        return RedirectToAction("user", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("", userLogin.StatusMsg);
                        return View();
                    }
                }
            }
            return View();
        } 
    }
}