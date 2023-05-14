using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Responces;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace eUseControl.BusinessLogic
{
    public class SessionBL:UserApi, ISession
    {
        public ULoginResp UserLogin(ULoginData data) 
        {
            return UserLoginAction(data);
        }
        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }

        public UserMinimal GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }
    }
}
