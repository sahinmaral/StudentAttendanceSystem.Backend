using Microsoft.AspNetCore.Mvc;

using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Entities.Concrete;
using StudentAttendanceSystem.Entities.DTOs;

namespace InstructorAttendanceSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("instructors")]
    public class InstructorsController : ControllerBase
    {

        private readonly IInstructorService _instructorService;
        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _instructorService.GetByDetailAsync();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> AddAsync(InstructorDto dto)
        {
            var result = await _instructorService.AddAsync(new Instructor()
            {
                User = new User()
                {
                    UserEmail = dto.Email,
                    UserName = dto.Name,
                    UserSurname = dto.Surname,
                },
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
            var result = await _instructorService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _instructorService.GetByIdDetailAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] InstructorUpdateDto dto)
        {
            var result = await _instructorService.UpdateAsync(new Instructor()
            {
                User = new User()
                {
                    UserEmail = dto.Email,
                    UserName = dto.Name,
                    UserSurname = dto.Surname,
                },
                Lectures = dto.LectureIds.Select(x=> new Lecture()
                {
                    LectureId = x
                }).ToList()
            });
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
