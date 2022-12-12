using StudentAttendanceSystem.Core.Entities.Abstract;

namespace StudentAttendanceSystem.Entities.DTOs
{
    public class StudentAttendanceAddByInstructorDto:IDto
    {
        public DateTime StudentAttendanceEnteredDateTime { get; set; }
        public Guid StudentId { get; set; }
        public Guid InstructorId { get; set; }
        public Guid LectureId { get; set; }
    }
}
