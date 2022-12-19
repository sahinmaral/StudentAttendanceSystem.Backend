using Microsoft.AspNetCore.Mvc;
using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Entities.Concrete;
using StudentAttendanceSystem.Entities.DTOs;

namespace StudentAttendanceSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentsController : ControllerBase
    {

        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _studentService.GetByDetailAsync();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> AddAsync(StudentDto dto)
        {
            var result = await _studentService.AddAsync(new Student()
            {
                User = new User()
                {
                    UserEmail = dto.Email,
                    UserName = dto.Name,
                    UserSurname = dto.Surname,
                },
                StudentSchoolNumber = dto.SchoolNumber,
            });

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _studentService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _studentService.GetByIdDetailAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] StudentDto dto)
        {
            var result = await _studentService.UpdateAsync(new Student()
            {
                User = new User()
                {
                    UserEmail = dto.Email,
                    UserName = dto.Name,
                    UserSurname = dto.Surname,
                    UserId = id
                },
                StudentId = id,
                StudentSchoolNumber = dto.SchoolNumber,
            });
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
