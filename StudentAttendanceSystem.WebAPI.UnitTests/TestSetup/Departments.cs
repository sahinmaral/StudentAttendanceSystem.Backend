using Microsoft.EntityFrameworkCore;

using StudentAttendanceSystem.DataAccess.Concrete;
using StudentAttendanceSystem.Entities.Concrete;

namespace StudentAttendanceSystem.WebAPI.UnitTests.TestSetup
{
    public static class Departments
    {
        public static void AddDepartments(this StudentAttendanceSystemAppDbContext context)
        {
            context.Departments.AddRange(
                new Department()
                {
                    DepartmentName = "Computer Engineering",
                    Faculty = context.Faculties.Single(x=>x.FacultyName == "Engineering")
                },
                new Department()
                {
                    DepartmentName = "Mechatronic Engineering",
                    Faculty = context.Faculties.Single(x => x.FacultyName == "Engineering")
                },
                new Department()
                {
                    DepartmentName = "Industrial Engineering",
                    Faculty = context.Faculties.Single(x => x.FacultyName == "Engineering")
                }
            );

            context.SaveChanges();

        }
    }
}
