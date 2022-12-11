using Microsoft.EntityFrameworkCore;

using StudentAttendanceSystem.Core.Entities.Abstract;
using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.DataAccess.Concrete.EntityFramework
{
    public class EfLectureHourDal:EfEntityRepositoryBase<LectureHour, StudentAttendanceSystemAppDbContext>, ILectureHourDal
    {
    }
}
