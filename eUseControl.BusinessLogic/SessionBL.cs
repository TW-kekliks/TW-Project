using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Responces;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace eUseControl.BusinessLogic
{
    public class SessionBL:UserApi, ISession
    {
        public RequestResponceAction UserLogin(ULoginData data) 
        {
            return UserLoginAction(data);
        }
    }
}
