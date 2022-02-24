using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
namespace AMS.Models
{
    public class ProcessContext:DbContext
    {
        public DbSet<ProcessGrp> prsgrp { get; set; }
        public DbSet<ProcessList> prslist { get; set; }
        public DbSet<PrsUserread> prsusrread { get; set; }
        public DbSet<PrsUsersug> prsusrsug { get; set; }
    }
}