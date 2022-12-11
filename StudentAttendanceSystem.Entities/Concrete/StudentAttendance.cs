using StudentAttendanceSystem.Core.Entities.Abstract;

using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAttendanceSystem.Entities.Concrete
{
    public class StudentAttendance:IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StudentAttendanceId { get; set; }
        public DateTime? StudentAttendanceLectureEnteredDateTime { get; set; }
        public Student Student { get; set; }
        public Lecture Lecture { get; set; }

    }
}
