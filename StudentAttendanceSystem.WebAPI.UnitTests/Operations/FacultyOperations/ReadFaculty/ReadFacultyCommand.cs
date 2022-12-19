using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Business.Concrete;
using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.DataAccess.Concrete;
using StudentAttendanceSystem.DataAccess.Concrete.EntityFramework;
using StudentAttendanceSystem.Entities.Concrete;
using StudentAttendanceSystem.WebAPI.Controllers;
using StudentAttendanceSystem.WebAPI.UnitTests.TestSetup;

using Xunit;

namespace StudentAttendanceSystem.WebAPI.UnitTests.Operations.FacultyOperations.ReadFaculty
{
    public class ReadFacultyCommand:IClassFixture<CommonTextFixture>
    {
        private readonly CommonTextFixture _fixture;
        public ReadFacultyCommand(CommonTextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void WhenGetRequestSent_EveryDataMustGetCompletely()
        {
            //var result = await _facultyService.GetAsync();

            //Assert.True(result.Success);
            //Assert.True(result.Data.Count > 0);
            //Assert.Contains(result.Data.Single(x=>x.FacultyName == "Engineering"),result.Data);  

            var result = _fixture.Context.Faculties.ToList();
            Assert.True(result.Count > 0);
            Assert.Contains(result.Single(x => x.FacultyName == "Engineering"), result);
        }

        

    }


}
