using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.Entity;
using eUseControl.Domain.Entities.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.BusinessLogic.DBModel
{
    class UserContext : DbContext
    {
        public UserContext() :
            base("eUseControl")
        { }
        public virtual DbSet<UDbTable> Users { get; set; }
    }
}
