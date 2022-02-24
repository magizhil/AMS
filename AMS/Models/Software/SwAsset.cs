using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    [Table("SWASSET")]
    public class SwAsset
    {
        [Key]
        public string ASSETTAG { get; set; }
        public string CATGNAME { get; set; }
        public string BRAND { get; set; }
        public string MDLNAME { get; set; }
        public string MDLNO { get; set; }
        public string SLNO { get; set; }
        public int LICTYPE { get; set; }
        public int USRLIC { get; set; }
        public int MACLIC { get; set; }
        public string VENDID { get; set; }
        public string ASSTNO { get; set; }
        public string INVOICENUMBER { get; set; }
        public string PODATE { get; set; }
        public string ACTDATE { get; set; }
        public string RENEWALDATE { get; set; }
        public decimal ASSETVAL { get; set; }
        public int SWSTS { get; set; }
        public string AUDTDATE { get; set; }
        public string AUDTTIME { get; set; }
        public string AUDTUSER { get; set; }
        public string DATELASTMN { get; set; }

        public virtual MsCategory mscatsw { get; set; }
        public virtual MsVendor msvendsw { get; set; }
    }
}