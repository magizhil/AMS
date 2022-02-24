using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    [Table("CNTDET")]
    public class CntDetails
    {
        [Key]
        public int ID { get; set; }
        public string CNTNUMBER { get; set; }
        public string CNTNAME { get; set; }
        public string VENDID { get; set; }
        public string VENDNAME { get; set; }
        public string EMAIL { get; set; }
        public string PHNO { get; set; }
        public string VENDADDR { get; set; }
        public string SIGNLOC { get; set; }
        public string EXECLOC { get; set; }
        public string CNTTYPE { get; set; }
        public string CNTPURPOSE { get; set; }
        public string CNTINFO { get; set; }
        public decimal CNTVALUE { get; set; }
        public string CNTSTARTDT { get; set; }
        public string CNTENDDT { get; set; }
        public string CNTFILE { get; set; }
        public string CNTYEAR { get; set; }
        public int CNTSTATUS { get; set; }
        public int CNTPRD { get; set; }
        public int RENEWTYPE { get; set; }
        public string CNTGRP { get; set; }       
        public string AUDTUSER { get; set; }
        public string DATELASTMN { get; set; }

        public virtual MsCnttype cnttypedet { get; set; }
    }
}