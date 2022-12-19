using StudentAttendanceSystem.Core.Entities.Abstract;

using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAttendanceSystem.Entities.Concrete
{
    public class Instructor:IEntity
    {
        public Guid InstructorId { get; set; }
        public List<Lecture> Lectures { get; set; }
        public User User { get; set; }
    }
}
