using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public string Name { get; set; }
        public string Roles { get; set; }
    }
}