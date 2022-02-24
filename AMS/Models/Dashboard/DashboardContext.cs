using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace AMS.Models
{
    public class DashboardContext:DbContext
    {
        public DbSet<DBHwAstDet> dbhwastdetail { get; set; }
        public DbSet<DBSwAstDet> dbswastdetail { get; set; }
    }
}