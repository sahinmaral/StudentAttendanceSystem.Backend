using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.Entities.Concrete;

namespace StudentAttendanceSystem.Business.Abstract
{
    public interface IDepartmentService:IGenericService<Department>
    {
        IDataResult<List<Department>> GetByDetail();
        Task<IDataResult<List<Department>>> GetByDetailAsync();
        IDataResult<Department> GetByIdDetail(Guid id);
        Task<IDataResult<Department>> GetByIdDetailAsync(Guid id);
    }
}
