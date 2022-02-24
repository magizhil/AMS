using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    [Table("ASTASGD1")]
    
    public class AstAsgDet1
    {
        [Key]
        public int ID { get; set; }
        public string MASSETTAG { get; set; }
        public int LINENO { get; set; }
        public string ASSETTAG { get; set; }
        public string CATGNAME { get; set; }
        public string BRAND { get; set; }
        public string MDLNAME { get; set; }
        public string SLNO { get; set; }
        public int SERIALIZED { get; set; }
        public int QTY { get; set; }
        public int ASTSTS { get; set; }
        public string ASGDATE { get; set; }
        public string RETDATE { get; set; }
        public string RECDATE { get; set; }
        public string AUDTUSER { get; set; }
    }
}