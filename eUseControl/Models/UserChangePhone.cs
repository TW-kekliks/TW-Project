﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eUseControl.Models
{
    public class UserChangePhone
    {
        public string Email { get; set; }
        public string NewPhone { get; set; }
        public string Password { get; set; }

    }
}