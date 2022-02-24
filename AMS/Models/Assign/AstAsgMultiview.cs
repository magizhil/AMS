using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
namespace AMS.Models
{
    public class AstAsgMultiview
    {
        public AstHeader AssetHeader { get; set;}
        public AstAsgDet1 AssetDet1 { get; set; }
        public AstAsgDet2 AssetDet2 { get; set; }
        public AstAsgDet3 AssetDet3 { get; set; }
        public HwAsset HwAssetDet { get; set; }
    }
}