using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AMS.Models
{
    public class ContractContext :DbContext
    {
        public DbSet<CntDetails> cntdetail { get; set; }
        public DbSet<CntHistory> cnthist { get; set; }

        public System.Data.Entity.DbSet<AMS.Models.CntFileInfo> CntFileInfoes { get; set; }
    }
}