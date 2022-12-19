using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.DataAccess.Concrete.EntityFramework
{
    public class EfFacultyDal : EfEntityRepositoryBase<Faculty, StudentAttendanceSystemAppDbContext>, IFacultyDal
    {
        public List<Faculty> GetByDetail()
        {
            throw new NotImplementedException();
        }

        public Task<List<Faculty>> GetByDetailAsync()
        {
            throw new NotImplementedException();
        }

        public Faculty GetByIdDetail(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Faculty> GetByIdDetailAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
