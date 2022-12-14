using StudentAttendanceSystem.Core.DataAccess;
using StudentAttendanceSystem.Entities.Concrete;

namespace StudentAttendanceSystem.DataAccess.Abstract
{
    public interface ILectureHourDal:IEntityRepository<LectureHour>
    {
    }
}
