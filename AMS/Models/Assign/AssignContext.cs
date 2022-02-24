using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace AMS.Models
{
    public class AssignContext : DbContext
    {
        public DbSet<AstHeader> asthdr { get; set; }
        public DbSet<AstAsgDet1> astdet1 { get; set; }
        public DbSet<AstAsgDet2> astdet2 { get; set; }
        public DbSet<AstAsgDet3> astdet3 { get; set; }
        public DbSet<HwAsset> hwdet { get; set; }
        public DbSet<SwAsset> swdet { get; set; }
        public DbSet<MsCategory> MsCategories { get; set; }
        public DbSet<MsVendor> MsVendors { get; set; }
    }
}