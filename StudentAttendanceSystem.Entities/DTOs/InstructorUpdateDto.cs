using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Entities.DTOs
{
    public class InstructorUpdateDto:InstructorDto
    {
        public List<Guid> LectureIds { get; set; }
    }
}
