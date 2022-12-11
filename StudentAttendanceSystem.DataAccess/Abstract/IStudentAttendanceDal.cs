using StudentAttendanceSystem.Core.DataAccess;
using StudentAttendanceSystem.Entities.Concrete;

namespace StudentAttendanceSystem.DataAccess.Abstract
{
    public interface IStudentAttendanceDal: IEntityRepository<StudentAttendance>
    {
        List<StudentAttendance> GetByDetail();
        Task<List<StudentAttendance>> GetByDetailAsync();
        StudentAttendance GetByIdDetail(Guid id);
        Task<StudentAttendance> GetByIdDetailAsync(Guid id);
    }
}
