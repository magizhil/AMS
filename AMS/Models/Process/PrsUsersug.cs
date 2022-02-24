using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AMS.Models
{
    [Table("PRSUSERSUGG")]
    public class PrsUsersug
    {
        [Key]
        public int SUGGID { get; set; }
        public string USERNAME { get; set;}
        public string SUGGESTION { get; set; }
        public string AUDTUSER { get; set; }
        public string DATELASTMN { get; set; }
        public int READED { get; set; }
    }
}