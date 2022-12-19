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
    public class EfLectureHourDal : EfEntityRepositoryBase<LectureHour, StudentAttendanceSystemAppDbContext>, ILectureHourDal
    {
        public List<LectureHour> GetByDetail()
        {
            throw new NotImplementedException();
        }

        public Task<List<LectureHour>> GetByDetailAsync()
        {
            throw new NotImplementedException();
        }

        public LectureHour GetByIdDetail(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<LectureHour> GetByIdDetailAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
