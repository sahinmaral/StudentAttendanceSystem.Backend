using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.Entities.Concrete;

namespace StudentAttendanceSystem.Business.Abstract
{
    public interface IStudentService : IGenericService<Student>
    {
        IDataResult<List<Student>> GetByDetail();
        Task<IDataResult<List<Student>>> GetByDetailAsync();
        IDataResult<Student> GetByIdDetail(Guid id);
        Task<IDataResult<Student>> GetByIdDetailAsync(Guid id);
    }

}
