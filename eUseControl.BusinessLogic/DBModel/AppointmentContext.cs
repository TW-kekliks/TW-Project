using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.DBModel
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext() :
            base("eUseControl")
        { }
        public virtual DbSet<ADbTable> Users { get; set; }
    }
}
