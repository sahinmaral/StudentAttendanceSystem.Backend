using StudentAttendanceSystem.Core.DataAccess;
using StudentAttendanceSystem.Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.DataAccess.Abstract
{
    public interface IFacultyDal:IEntityRepository<Faculty>
    {
    }
}
