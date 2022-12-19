namespace StudentAttendanceSystem.Entities.DTOs
{
    public class LectureUpdateDto:LectureDto
    {
        public List<Guid> StudentIds { get; set; }
    }
}
