using StudentAttendanceSystem.Core.Entities.Abstract;

namespace StudentAttendanceSystem.Entities.Concrete
{
    public class StudentSchoolCard:IEntity
    {
        public Guid StudentSchoolCardId { get; set; }
        public string StudentSchoolCardPhysicalUID { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        
    }
}
