using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    [Table("MSCATG")]
    public class MsCategory
    {
        [Key]
        public string CATGNAME { get; set; }
        public string CATGDESC { get; set; }
        public int CATGTYPE { get; set; }
        public int INACTIVE { get; set; }
        public string DATELASTMN { get; set; }

        public virtual ICollection<SwAsset> swassets { get; set; }
    }
}