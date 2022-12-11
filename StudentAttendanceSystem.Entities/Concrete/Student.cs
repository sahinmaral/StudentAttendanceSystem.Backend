using StudentAttendanceSystem.Core.Entities.Abstract;

using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAttendanceSystem.Entities.Concrete
{
    public class Student:IEntity
    {
        [ForeignKey(nameof(User))]
        public Guid StudentId { get; set; }
        public List<Lecture> Lectures { get; set; }
        public string StudentSchoolNumber { get; set; }
        public User User { get; set; }
        public StudentSchoolCard StudentSchoolCard { get; set; }
    }
}
