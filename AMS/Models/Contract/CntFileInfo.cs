using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
namespace AMS.Models
{
    public class CntFileInfo
    {
        [Key]
        public int fileId { get; set; }
        public string filename { get; set; }
        public string filepath { get; set; }
    }
}