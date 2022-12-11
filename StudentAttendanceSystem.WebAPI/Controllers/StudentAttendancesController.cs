using Microsoft.AspNetCore.Mvc;

using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Entities.DTOs;

namespace StudentAttendanceSystem.WebAPI.Controllers
{
    [Route("studentAttendance")]
    [ApiController]
    public class StudentAttendancesController : ControllerBase
    {
        private readonly IStudentAttendanceService _studentAttendanceService;
        public StudentAttendancesController(IStudentAttendanceService studentAttendanceService)
        {
            _studentAttendanceService = studentAttendanceService;
        }

        [HttpPut("addByStudent")]
        public IActionResult AddByStudent(StudentAttendanceAddByStudentDto dto)
        {
            var result = _studentAttendanceService.AddByStudent(dto);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }


    }
}
