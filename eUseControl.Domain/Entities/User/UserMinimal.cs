using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.Enums;

namespace eUseControl.Domain.Entities.User
{
    public class UserMinimal
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public DateTime LastLogin { get; set; }
        public string LasIp { get; set; }
        public URole Level { get; set; }
    }
}
