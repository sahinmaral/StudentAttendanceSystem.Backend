using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Entities.DTOs
{
    public class LectureUpdateDto
    {
        public Guid LectureId { get; set; }
        public string LectureName { get; set; }
        public string LectureCode { get; set; }
        public string LectureLanguage { get; set; }
        public string LectureClassCode { get; set; }
        public List<Guid> LectureHourIds { get; set; }
        public List<Guid> DepartmentIds { get; set; }
        public List<Guid> InstructorIds { get; set; }
        public List<Guid> StudentIds { get; set; }
    }
}
