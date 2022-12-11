using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.Entities.Concrete;
using StudentAttendanceSystem.Entities.DTOs;

namespace StudentAttendanceSystem.Business.Abstract
{
    public interface IStudentAttendanceService:IGenericService<StudentAttendance>
    {
        IResult AddByStudent(StudentAttendanceAddByStudentDto dto);
        Task<IResult> AddByStudentAsync(StudentAttendanceAddByStudentDto dto);
        //IResult Update(StudentAttendanceUpdateDto dto);
        //Task<IResult> UpdateAsync(StudentAttendanceUpdateDto dto);
    }
}
