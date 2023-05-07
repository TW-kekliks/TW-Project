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
using eUseControl.BusinessLogic.DBModel;

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

                    using (UserContext db = new UserContext())
                    {
                        data.Level = db.Users.FirstOrDefault(u => u.Email == data.Email).Level;
                    }
                    if (data.Level == Domain.Entities.Enums.URole.DOCTOR)
                        return RedirectToAction("doctor", "User");
                    else
                        return RedirectToAction("user", "User");
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
        public ActionResult SignUp(UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                using (UserContext db = new UserContext())
                {
                    if (db.Users.Any(u => u.Email == model.Email))
                    {
                        ModelState.AddModelError("Email", "Email уже занят");
                        return View(model);
                    }
                    if (model.Password != model.ConfirmPassword)
                    {
                        ModelState.AddModelError("ConfirmPassword", "Не правильно повторили пароль ");
                        return View(model);
                    }

                    var user = new UDbTable
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Number = model.Number,
                        Email = model.Email,
                        Password = model.Password,
                        Level = Domain.Entities.Enums.URole.USER,
                        LastLogin = DateTime.Now
                        
                    };
                    db.Users.Add(user);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

    }
}