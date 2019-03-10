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

        public void SaveStudentMaster(StudentMaster product)
        {
            if (product.StdID == 0)
            {
                eFDbContext.StudentMasters.Add(product);
            }
            else
            {
                StudentMaster dbEntry = eFDbContext.StudentMasters.Find(product.StdID);
                if (dbEntry != null)
                {
                    dbEntry.StdName = product.StdName;
                    dbEntry.Address = product.Address;
                    dbEntry.Email = product.Email;
                    dbEntry.Phone = product.Phone;
                }
            }
            eFDbContext.SaveChanges();
        }


        public StudentMaster DeleteStudentMaster(int studentMasterId)
        {
            StudentMaster dbEntry = eFDbContext.StudentMasters.Find(studentMasterId);
            if (dbEntry != null)
            {
                eFDbContext.StudentMasters.Remove(dbEntry);
                eFDbContext.SaveChanges();
            }
            return dbEntry;
        }

       
    }
}
