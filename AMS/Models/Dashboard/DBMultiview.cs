using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AMS.Models
{
    public class DBMultiview
    {
        [Key]
        public int keyval { get; set; }
        public IEnumerable<DBHwAstDet> dbhwastdet { get; set; }
        public IEnumerable<DBSwAstDet> dbswastdet { get; set; }
    }
}