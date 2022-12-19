namespace StudentAttendanceSystem.Entities.DTOs
{
    public class FacultyUpdateDto:FacultyDto
    {
        public List<Guid> DepartmentIds { get; set; }
    }
}
