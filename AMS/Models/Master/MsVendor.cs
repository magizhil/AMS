using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    [Table("MSVENDOR")]
    public class MsVendor
    {
        [Key]
        public string VENDID { get; set; }
        public string VENDNAME { get; set; }
        public string VENDADDR { get; set; }
        public string VENDPHNO { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        ErrorMessage = "Please Enter Correct Email Address")]
        public string VENDEMAIL { get; set; }
        public string COMMENTS { get; set; }
        public int INACTIVE { get; set; }
        public string DATELASTMN { get; set; }

        public virtual ICollection<SwAsset> swassets { get; set; }
    }
}