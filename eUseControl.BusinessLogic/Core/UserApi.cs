using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.Responces;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.Enums;
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
                    Username = data.Username,
                    Password = data.Password,
                    LastLogin = DateTime.Now,
                    Level = Domain.Entities.Enums.URole.USER,
                    Email = data.Email
                };
                db.Users.Add(user);
                db.SaveChanges();
            }

            using (var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.Username == data.Username);
            }
            /*if (user ==null)
            {
                throw new Exception();
            } */
            return new RequestResponceAction();
        }
    }
}
