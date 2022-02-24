using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    [Table("MSCNTTYPE")]
    public class MsCnttype
    {
        
        public int CNTID { get; set; }
        public string AUDTDATE { get; set; }
        public string AUDTTIME { get; set; }
        public string AUDTUSER { get; set; }
        [Key]
        public string CNTTYPE { get; set; }
        public string CNTDESC { get; set; }
        public int INACTIVE { get; set; }
        public string DATELASTMN { get; set; }
    }
}