using StudentAttendanceSystem.Core.DataAccess;
using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.Entities.Concrete;
using StudentAttendanceSystem.Entities.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.DataAccess.Abstract
{
    public interface ILectureDal:IEntityRepository<Lecture>
    {
    }
}
