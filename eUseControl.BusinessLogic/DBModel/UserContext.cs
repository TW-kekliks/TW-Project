using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.Entity;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() : base("eUseControl")
        {

        }
        public virtual DbSet<UDbTable> Users { get; set; }
    }
}
