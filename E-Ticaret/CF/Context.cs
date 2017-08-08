using E_Ticaret.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_Ticaret.CF
{
    public class Context:DbContext
    {
        public Context()
        {
            Database.Connection.ConnectionString = "server=.;database=DbCommerce; user id=sa; password=123456789?";
        }
        public DbSet<BaseUser> Users { get; set; }

    }
}