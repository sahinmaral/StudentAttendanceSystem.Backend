using Microsoft.EntityFrameworkCore;

using StudentAttendanceSystem.DataAccess.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.WebAPI.UnitTests.TestSetup
{
    public class CommonTextFixture
    {
        public StudentAttendanceSystemAppDbContext Context { get; set; }

        public CommonTextFixture()
        {
            var options = new DbContextOptionsBuilder<StudentAttendanceSystemAppDbContext>().UseInMemoryDatabase(databaseName: "StudentAttendanceSystemTestDb").Options;

            Context = new StudentAttendanceSystemAppDbContext(options);

            Context.Database.EnsureCreated();

            Context.AddFaculties();

            Context.AddDepartments();
            
        }
    }
}
