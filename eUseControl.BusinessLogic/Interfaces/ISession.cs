using eUseControl.Domain.Entities.Responces;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface ISession
    {
        public RequestResponceAction UserLogin(ULoginData data);
    }
}
