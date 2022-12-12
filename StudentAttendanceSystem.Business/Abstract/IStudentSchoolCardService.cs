using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.Entities.Concrete;

namespace StudentAttendanceSystem.Business.Abstract
{
    public interface IStudentSchoolCardService:IGenericService<StudentSchoolCard>
    {
        //IResult Add(LectureAddDto dto);
        //Task<IResult> AddAsync(LectureAddDto dto);
        //IResult Update(LectureUpdateDto dto);
        //Task<IResult> UpdateAsync(LectureUpdateDto dto);
        IDataResult<List<StudentSchoolCard>> GetByDetail();
        Task<IDataResult<List<StudentSchoolCard>>> GetByDetailAsync();
        IDataResult<StudentSchoolCard> GetByIdDetail(Guid id);
        Task<IDataResult<StudentSchoolCard>> GetByIdDetailAsync(Guid id);
    }
}
