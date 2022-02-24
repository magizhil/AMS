using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace AMS.Models
{
    public class MasterContext :DbContext
    {
        public DbSet<MsVendor> VendorDet { get; set; }
        public DbSet<MsCategory> CatgDet { get; set; }
        public DbSet<AstInvoice> astinv { get; set; }
        public DbSet<MsCnttype> CntDet { get; set; }
    }
}