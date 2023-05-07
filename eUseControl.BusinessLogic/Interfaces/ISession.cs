using eUseControl.Domain.Entities.Responces;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface ISession
    {
        
        RequestResponceAction UserLogin(ULoginData data);

        HttpCookie GenCookie(string loginCredential);

        UserMinimal GetUserByCookies(string apiCookieValue);
    }
}