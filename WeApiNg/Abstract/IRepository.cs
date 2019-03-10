using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeApiNg.Models;

namespace WeApiNg.Abstract
{
    public interface IRepository
    {
        IEnumerable<StudentMaster> StudentMasters { get; }       
    }
}