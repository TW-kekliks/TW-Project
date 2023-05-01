using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.Responces;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eUseControl.BusinessLogic.Core
{
    public class UserApi
    {
        public RequestResponceAction UserLoginAction(ULoginData data)
        {
            UDbTable user;
            using (var db = new UserContext())
            {
                user = new UDbTable
                {
                    Username = "OlegSomov",
                    Password = "qwerty1234",
                    LastLogin = DateTime.Now,
                    Level = Domain.Enums.URole.UNAUTHORIZED,
                    Email = "info2@mail.ru"
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
            using (var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.Username == data.Credential);
            }
            if (user ==null)
            {
                throw new Exception();
            }
            using (var db = new UserContext())
            {
                var users = db.Users.Where(u => u.Level == Domain.Enums.URole.DOCTOR).ToList();
            }
            return new RequestResponceAction();
        }
    }
}
