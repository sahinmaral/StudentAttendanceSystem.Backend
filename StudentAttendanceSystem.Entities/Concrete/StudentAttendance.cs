using StudentAttendanceSystem.Core.Entities.Abstract;
using StudentAttendanceSystem.Entities.Enums;

using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAttendanceSystem.Entities.Concrete
{
    public class StudentAttendance:IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StudentAttendanceId { get; set; }
        public DateTime StudentAttendanceEnteredDateTime { get; set; }
        public Student Student { get; set; }
        public Lecture Lecture { get; set; }
        public StudentAttendanceType StudentAttendanceType { get; set; }

    }
}
