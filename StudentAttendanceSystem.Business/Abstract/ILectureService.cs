using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.Entities.Concrete;
using StudentAttendanceSystem.Entities.DTOs;

namespace StudentAttendanceSystem.Business.Abstract
{
    public interface ILectureService:IGenericService<Lecture>
    {
        IDataResult<List<Lecture>> GetByDetail();
        Task<IDataResult<List<Lecture>>> GetByDetailAsync();
        IDataResult<Lecture> GetByIdDetail(Guid id);
        Task<IDataResult<Lecture>> GetByIdDetailAsync(Guid id);
    }
}
