using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeApiNg.Models;

namespace WeApiNg.Concrete
{
    public class StudentMasterContext : DbContext
    {
        public DbSet<StudentMaster> StudentMasters { get; set; }
       
    }
}