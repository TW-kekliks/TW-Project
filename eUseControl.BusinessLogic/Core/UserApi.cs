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
                user = db.Users.FirstOrDefault(u => u.Username == data.Email);
            }
            if (user ==null)
            {
                throw new Exception();
            }
            using (var db = new UserContext())
            {
                var users = db.Users.Where(u => u.Level == Domain.Entities.Enums.URole.DOCTOR).ToList();
            }
            return new RequestResponceAction();
        }
    }
}
