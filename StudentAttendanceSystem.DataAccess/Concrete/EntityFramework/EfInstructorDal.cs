using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

namespace StudentAttendanceSystem.DataAccess.Concrete.EntityFramework
{
    public class EfInstructorDal : EfEntityRepositoryBase<Instructor, StudentAttendanceSystemAppDbContext>,IInstructorDal
    {
    }
}
