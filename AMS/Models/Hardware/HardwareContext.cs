using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AMS.Models
{
    public class HardwareContext: DbContext
    {
        public DbSet<HwAsset> hwdet { get; set; }

        public System.Data.Entity.DbSet<AMS.Models.MsCategory> MsCategories { get; set; }

        public System.Data.Entity.DbSet<AMS.Models.MsVendor> MsVendors { get; set; }
    }
}