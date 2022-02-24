using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AMS.Models
{
    [Table("TBL_SWASTDET")]
    public class DBSwAstDet
    {
        [Key]
        public string CATGNAME { get; set; }
        public string MDLNAME { get; set; }
        public int USERLIC { get; set; }
        public int MACLIC { get; set; }
    }
}