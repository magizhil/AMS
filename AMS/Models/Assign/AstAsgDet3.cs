using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AMS.Models
{
    [Table("ASTASGD3")]
    public class AstAsgDet3
    {
        [Key]
        public int ID { get; set; }
        public string MASSETTAG { get; set; }
        public int LINENO { get; set; }
        public string EMPCODE { get; set; }
        public string EMPNAME { get; set; }
        public string DESG { get; set; }
        public string DEPT { get; set; }
        public string DOJ { get; set; }
        public string RPTMANAGER { get; set; }
        public string EMPLOC { get; set; }
        public string EMPCONT1 { get; set; }
        public string EMPCONT2 { get; set; }
        public string EMPEMAIL { get; set; }
        public string GEOLOC { get; set; }
        public string PHLOC { get; set; }
        public int ASTSTS { get; set; }
        public string ASGDATE { get; set; }
        public string RETDATE { get; set; }
        public string RECDATE { get; set; }
        public string AUDTUSER { get; set; }
        
    }
}