using StudentAttendanceSystem.Core.Entities.Abstract;
using StudentAttendanceSystem.Entities.Enums;

using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAttendanceSystem.Entities.Concrete
{
    public class Lecture : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LectureId { get; set; }
        public string LectureName { get; set; }
        public string LectureCode { get; set; }
        public string LectureLanguage { get; set; }
        public string LectureClassCode { get; set; }
        public List<Instructor> Instructors { get; set; }
        public List<Student> Students { get; set; }
        public Enums.DayOfWeek LectureDay { get; set; }

        public List<LectureHour> LectureHours { get; set; }
        public List<Department> Departments { get; set; }
    }
}
