using eUseControl.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace eUseControl.Models
{
    public class AppointmentRegistration
    {
        [Required]
        public Doctors Doctor { get; set; }
        [Required]
        public Services Service { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        [Required]
        public Rooms Room { get; set; }
        [Required]
        public string Notes { get; set; }

    }

    
}