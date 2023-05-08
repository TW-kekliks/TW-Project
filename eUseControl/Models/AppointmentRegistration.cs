using eUseControl.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace eUseControl.Models
{
    public class AppointmentRegistration
    {
        
        public string Doctor { get; set; }
        public string Service { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Room { get; set; }

        public string Notes { get; set; }

    }

    
}