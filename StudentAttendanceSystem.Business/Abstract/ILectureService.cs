using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.Entities.Concrete;
using StudentAttendanceSystem.Entities.DTOs;

namespace StudentAttendanceSystem.Business.Abstract
{
    public interface ILectureService:IGenericService<Lecture>
    {
        IResult Add(LectureAddDto dto);
        Task<IResult> AddAsync(LectureAddDto dto);
        IResult Update(LectureUpdateDto dto);
        Task<IResult> UpdateAsync(LectureUpdateDto dto);
        IDataResult<List<Lecture>> GetByDetail();
        Task<IDataResult<List<Lecture>>> GetByDetailAsync();
        IDataResult<Lecture> GetByIdDetail(Guid id);
        Task<IDataResult<Lecture>> GetByIdDetailAsync(Guid id);
    }
}
