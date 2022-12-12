using StudentAttendanceSystem.Core.DataAccess;
using StudentAttendanceSystem.Entities.Concrete;

namespace StudentAttendanceSystem.DataAccess.Abstract
{
    public interface IDepartmentDal:IEntityRepository<Department>
    {
        List<Department> GetByDetail();
        Task<List<Department>> GetByDetailAsync();
        Department GetByIdDetail(Guid id);
        Task<Department> GetByIdDetailAsync(Guid id);
    }
}
