using StudentAttendanceSystem.Core.Entities.Abstract;

namespace StudentAttendanceSystem.Entities.DTOs
{
    public class LectureDto:IDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Language { get; set; }
        public string ClassCode { get; set; }
        public DayOfWeek Day { get; set; }
        public List<Guid> LectureHourIds { get; set; }
        public List<Guid> DepartmentIds { get; set; }
        public List<Guid> InstructorIds { get; set; }

    }
}
