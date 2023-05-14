using eUseControl.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace eUseControl.BusinessLogic
{
    public class BussinesLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
    }
}
