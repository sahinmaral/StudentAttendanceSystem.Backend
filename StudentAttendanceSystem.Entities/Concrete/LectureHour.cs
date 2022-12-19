using StudentAttendanceSystem.Core.Entities.Abstract;

using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAttendanceSystem.Entities.Concrete
{
    public class LectureHour:IEntity
    {
        public LectureHour()
        {
            LectureHourId = Guid.NewGuid();
        }
        public Guid LectureHourId { get; set; }
        public TimeSpan LectureHourStartHour { get; set; }
        public TimeSpan LectureHourEndHour { get; set;}

        public List<Lecture> Lectures { get; set; }
    }
}
