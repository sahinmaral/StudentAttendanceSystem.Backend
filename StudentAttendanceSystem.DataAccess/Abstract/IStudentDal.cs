using StudentAttendanceSystem.Core.DataAccess;
using StudentAttendanceSystem.Entities.Concrete;

namespace StudentAttendanceSystem.DataAccess.Abstract
{
    public interface IStudentDal:IEntityRepository<Student>
    {
        List<Student> GetByDetail();
        Task<List<Student>> GetByDetailAsync();
        Student GetByIdDetail(Guid id);
        Task<Student> GetByIdDetailAsync(Guid id);
    }
}
