using Microsoft.AspNetCore.Mvc;

using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Entities.Concrete;
using StudentAttendanceSystem.Entities.DTOs;

namespace StudentAttendanceSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("studentSchoolCards")]
    public class StudentSchoolCardsController : ControllerBase
    {

        private readonly IStudentSchoolCardService _studentSchoolCardService;
        public StudentSchoolCardsController(IStudentSchoolCardService studentSchoolCardService)
        {
            _studentSchoolCardService = studentSchoolCardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _studentSchoolCardService.GetByDetailAsync();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> AddAsync(StudentSchoolCardDto dto)
        {
            var result = await _studentSchoolCardService.AddAsync(new StudentSchoolCard()
            {
                StudentId = dto.StudentId,
                StudentSchoolCardPhysicalUID = dto.PhysicalUID,
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
            var result = await _studentSchoolCardService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _studentSchoolCardService.GetByIdDetailAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] StudentSchoolCardDto dto)
        {
            var result = await _studentSchoolCardService.UpdateAsync(new StudentSchoolCard()
            {
                StudentId = dto.StudentId,
                StudentSchoolCardPhysicalUID = dto.PhysicalUID,
                StudentSchoolCardId = id
            });
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
