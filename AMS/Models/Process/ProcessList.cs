using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AMS.Models
{
    [Table("PRSCHKLIST")]
    public class ProcessList
    {
        [Key]
        public int CHKLISTID { get; set; }
        public int CHKGRPID { get; set; }
        public string CHKLISTTIT { get; set; }
        public string CHKLISTDESC { get; set; }
        public int SORTORD { get; set; }
        public string AUDTUSER { get; set; }
        public string DATELASTMN { get; set; }

        public virtual ProcessGrp prsgrp { get; set; }
    }
}