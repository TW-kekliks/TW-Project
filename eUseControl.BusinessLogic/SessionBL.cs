using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Responces;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace eUseControl.BusinessLogic
{
    public class SessionBL:UserApi, ISession
    {
        public System.Web.HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }

        public UserMinimal GetUserByCookies(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }

        public RequestResponceAction UserLogin(ULoginData data) 
        {
            return UserLoginAction(data);
        }
    }
}
