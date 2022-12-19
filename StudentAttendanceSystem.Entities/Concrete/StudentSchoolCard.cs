using StudentAttendanceSystem.Core.Entities.Abstract;

using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAttendanceSystem.Entities.Concrete
{
    public class StudentSchoolCard:IEntity
    {
        public StudentSchoolCard()
        {
            StudentSchoolCardId= Guid.NewGuid();
        }
        public Guid StudentSchoolCardId { get; set; }
        public string StudentSchoolCardPhysicalUID { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        
    }
}
