using StudentAttendanceSystem.Core.Entities.Abstract;

using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAttendanceSystem.Entities.Concrete
{
    public class LectureHour:IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LectureHourId { get; set; }
        public TimeSpan LectureHourStartHour { get; set; }
        public TimeSpan LectureHourEndHour { get; set;}

        public List<Lecture> Lectures { get; set; }
    }
}
