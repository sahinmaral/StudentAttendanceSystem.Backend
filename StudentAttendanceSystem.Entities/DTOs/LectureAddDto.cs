using StudentAttendanceSystem.Core.Entities.Abstract;

namespace StudentAttendanceSystem.Entities.DTOs
{
    public class LectureAddDto:IDto
    {
        public string LectureName { get; set; }
        public string LectureCode { get; set; }
        public string LectureLanguage { get; set; }
        public string LectureClassCode { get; set; }
        public List<string> LectureHourIds { get; set; }
        public List<string> DepartmentIds { get; set; }
        public List<string> InstructorIds { get; set; }
    }
}
