using StudentAttendanceSystem.Core.Entities.Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Entities.DTOs
{
    public class LectureHourDto:IDto
    {
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
    }
}
