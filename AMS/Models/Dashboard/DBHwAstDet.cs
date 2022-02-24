using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AMS.Models
{
    [Table("TBL_HWASTDET")]
    public class DBHwAstDet
    {
        [Key]
        public string CATGNAME { get; set; }
        public int CHENNAI { get; set; }
        public int PUNE { get; set; }
        public int ODISHA { get; set; }
        public int VIJAYAWADA { get; set; }
        public int FIELD { get; set; }
    }
}