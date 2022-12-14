using StudentAttendanceSystem.Core.Entities.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Entities.DTOs
{
    public class StudentSchoolCardDto : IDto
    {
        public string PhysicalUID { get; set; }
        public Guid StudentId { get; set; }
    }
}
