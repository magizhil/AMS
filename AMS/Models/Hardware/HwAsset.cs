using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    [Table("HWASSET")]
    public class HwAsset
    {
        [Key]
        public string ASSETTAG { get; set; }
        public string CATGNAME { get; set; }
        public string BRAND { get; set; }
        public string MDLNO { get; set; }
        public string MDLNAME { get; set; }
        public string SLNO { get; set; }
        public string SERTTAG { get; set; }
        public string HDD { get; set; }
        public string RAM { get; set; }
        public string PROCESSOR { get; set; }
        public string CONFIGURATION { get; set; }
        public string ACCESSORIES { get; set; }
        public string GEOLOC { get; set; }
        public string PHLOC { get; set; }
        public string ASSTNO { get; set; }
        public string ASSTSTS { get; set; }
        public string VENDID { get; set; }
        public string INVOICENUMBER { get; set; }
        public string PODATE { get; set; }
        public decimal ASSETVAL { get; set; }
        public int HWSTS { get; set; }
        public string PRTMDCYC { get; set; }
        public string PRTLTDCYC { get; set; }
        public string AUDTDATE { get; set; }
        public string AUDTTIME { get; set; }
        public string AUDTUSER { get; set; }
        public string DATELASTMN { get; set; }
        public int ASSETTYPE { get; set; }
        public int SERIALIZED { get; set; }
        public int QTY { get; set; }
        public string WARINFO { get; set; }
        public string WAREXP { get; set; }
        public virtual MsCategory mscatsw { get; set; }
        public virtual MsVendor msvendsw { get; set; }
    }
}