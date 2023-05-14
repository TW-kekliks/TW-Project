using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.DBModel
{
    public class CommentContext : DbContext
    {
        public CommentContext() :
            base("eUseControl")
        { }
        public virtual DbSet<CDbTable> Comment { get; set; }
    }
}
