using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    [Table("ASTASGH")]
    public class AstHeader
    {
        [Key]
        public string ASSETTAG { get; set; }
        public string CATGNAME { get; set; }
        public string BRAND { get; set; }
        public string MDLNAME { get; set; }
        public string SLNO { get; set; }
        public int ASGDET1 { get; set; }
        public int ASGDET2 { get; set; }
        public int ASGDET3 { get; set; }
        public int ASTSTS { get; set; }
        public string AUDTUSER { get; set; }
        
    }
}