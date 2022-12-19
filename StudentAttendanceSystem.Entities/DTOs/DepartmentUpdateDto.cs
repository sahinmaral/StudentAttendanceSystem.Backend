using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Entities.DTOs
{
    public class DepartmentUpdateDto:DepartmentDto
    {
        public List<Guid> LectureIds { get; set; }
    }
}
