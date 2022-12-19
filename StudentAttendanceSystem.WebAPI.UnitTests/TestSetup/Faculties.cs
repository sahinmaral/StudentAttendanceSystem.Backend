using StudentAttendanceSystem.DataAccess.Concrete;
using StudentAttendanceSystem.Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.WebAPI.UnitTests.TestSetup
{
    public static class Faculties
    {
        public static void AddFaculties(this StudentAttendanceSystemAppDbContext context)
        {
            context.Faculties.AddRange(
                new Faculty()
                {
                    FacultyName = "Engineering",
                },
                new Faculty()
                {
                    FacultyName = "Law",
                },
                new Faculty()
                {
                    FacultyName = "Economics and Business",
                }
            );

            context.SaveChanges();

        }
    }
}
