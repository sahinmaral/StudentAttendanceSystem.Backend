using StudentAttendanceSystem.Core.Entities.Abstract;

namespace StudentAttendanceSystem.Entities.DTOs
{
    public class InstructorDto:IDto
    {
        public string SchoolNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
