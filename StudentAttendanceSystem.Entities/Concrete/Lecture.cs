using StudentAttendanceSystem.Core.Entities.Abstract;

using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAttendanceSystem.Entities.Concrete
{
    public class Lecture : IEntity
    {
        public Lecture()
        {
            LectureId = Guid.NewGuid();
        }
        public Guid LectureId { get; set; }
        public string LectureName { get; set; }
        public string LectureCode { get; set; }
        public string LectureLanguage { get; set; }
        public string LectureClassCode { get; set; }
        public List<Instructor> Instructors { get; set; }
        public List<Student> Students { get; set; }
        public DayOfWeek LectureDay { get; set; }

        public List<LectureHour> LectureHours { get; set; }
        public List<Department> Departments { get; set; }
    }
}
