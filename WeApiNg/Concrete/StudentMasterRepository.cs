using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeApiNg.Abstract;
using WeApiNg.Models;

namespace WeApiNg.Concrete
{
    public class StudentMasterRepository : IRepository
    {
        private readonly StudentMasterContext eFDbContext;

        public StudentMasterRepository()
        {
            eFDbContext = new StudentMasterContext();
        }
        public IEnumerable<StudentMaster> StudentMasters
        {
            get { return eFDbContext.StudentMasters; }
        }        
    }
}
