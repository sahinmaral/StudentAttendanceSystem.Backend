using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.DataAccess.Concrete.EntityFramework
{
    public class EfDepartmentDal:EfEntityRepositoryBase<Department, StudentAttendanceSystemAppDbContext>, IDepartmentDal
    {
    }
}
