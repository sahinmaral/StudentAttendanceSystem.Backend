using StudentAttendanceSystem.Core.Entities.Abstract;

namespace StudentAttendanceSystem.Entities.DTOs
{
    public class StudentAttendanceAddByStudentDto:IDto
    {
        public DateTime LectureEnteredDateTime { get; set; } = DateTime.Now;
        public string StudentCardUID { get; set; }
    }
}
