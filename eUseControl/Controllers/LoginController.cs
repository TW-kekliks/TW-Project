using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Models;
using eUseControl.BusinessLogic.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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

        [HttpGet]
        public ActionResult SignUp()
        {
            var model = new UserRegistration();
            return View(model);
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
                    if (model.Password!=model.ConfirmPassword)
                    {
                        ModelState.AddModelError("ConfirmPassword", "Не правильно повторили пароль ");
                        return View(model);
                    }

                    var user = new UDbTable
                    {
                        Name = model.FirstName,
                        Surname = model.LastName,
                        Phone = model.Phone,
                        Email = model.Email,
                        Password = model.Password,
                        LastLogin = DateTime.Now
                    };
                    db.Users.Add(user);
                    db.SaveChanges();

                    return RedirectToAction("Index","Home");
                }
            }
            return View(model);
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
                    ModelState.AddModelError("Email", "Нет такого пользователя");
                }
            }
            return View(model);
        }
    }
}
