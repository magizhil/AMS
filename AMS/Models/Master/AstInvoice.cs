using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    [Table("ASTINVOICE")]
    public class AstInvoice
    {
        [Key]
        public int ID { get; set; }
        public string ASSETTAG { get; set; }
        public string INVOICENUMBER { get; set; }
        public string INVPATH { get; set; }
        public string DATELASTMN { get; set; }
        public string AUDTUSER { get; set; }
        public int ASSTTYPE { get; set; }
    }
}