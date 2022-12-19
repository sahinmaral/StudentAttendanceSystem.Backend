using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

namespace StudentAttendanceSystem.DataAccess.Concrete.EntityFramework
{
    public class EfInstructorDal : EfEntityRepositoryBase<Instructor, StudentAttendanceSystemAppDbContext>, IInstructorDal
    {
        public List<Instructor> GetByDetail()
        {
            throw new NotImplementedException();
        }

        public Task<List<Instructor>> GetByDetailAsync()
        {
            throw new NotImplementedException();
        }

        public Instructor GetByIdDetail(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Instructor> GetByIdDetailAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
