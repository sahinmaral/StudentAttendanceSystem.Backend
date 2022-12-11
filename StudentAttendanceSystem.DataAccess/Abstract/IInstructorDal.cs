using StudentAttendanceSystem.Core.DataAccess;
using StudentAttendanceSystem.Entities.Concrete;

namespace StudentAttendanceSystem.DataAccess.Abstract
{
    public interface IInstructorDal:IEntityRepository<Instructor>
    {
    }
}
