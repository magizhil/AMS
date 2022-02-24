using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AMS.Models
{
    [Table("PRSUSERACK")]
    public class PrsUserread
    {
        [Key]
        public int READKEY { get; set; }   
        public string USERNAME { get; set; }
        public string CHKGRPNAME { get; set; }
        public int READCOUNT { get; set; }
        public string AUDTUSER { get; set; }
        public string DATELASTMN { get; set; }
    }
}