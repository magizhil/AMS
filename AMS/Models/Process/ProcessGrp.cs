using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AMS.Models
{
    [Table("PRSCHKGRP")]
    public class ProcessGrp
    {
        [Key]
        public int CHKGRPID { get; set; }
        public string CHKGRPNAME { get; set; }
        public string CHKGRPDESC { get; set; }
        public int INACTIVE { get; set; }
        public int SORTORD { get; set; }
        public string AUDTUSER { get; set; }
        public string DATELASTMN { get; set; }
    }
}