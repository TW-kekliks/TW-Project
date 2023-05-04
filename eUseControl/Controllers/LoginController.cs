using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using eUseControl.BusinessLogic.DBModel;
using System.Web.Security;

namespace eUseControl.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;
        public LoginController()
        {
            var bl = new BusinessLogic.BusinessLogic();
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
                UDbTable user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                }
                if (user != null) 
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Такого пользователя не существует");
                }
            }
            return View(model);
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
                        //ADD COOKIE

                        return RedirectToAction("user", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("", userLogin.StatusMsg);
                        return View();
                    }
                }
                else
                {
                    return RedirectToAction("SignUp", "Login");
                }
            }
            return View();
        } 
    }
}