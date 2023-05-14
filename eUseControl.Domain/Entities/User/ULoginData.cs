using eUseControl.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eUseControl.Domain.Entities.User
{
    public class ULoginData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Number { get; set; }
        public string LoginIp { get; set; }
        public DateTime LoginDateTime { get; set; }
        public URole Level { get; set; }

    }
}
