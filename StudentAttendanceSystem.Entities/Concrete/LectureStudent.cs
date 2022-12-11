using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Entities.Concrete
{
    public class LectureStudent
    {
        public Student Student { get; set; }
        public Lecture Lecture { get; set; }
    }
}
