using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace AMS.Models
{
    public class AccountContext : DbContext
    {
        public DbSet<Users> usrdet { get; set; }
    }
}