using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Entities.Concrete;
using StudentAttendanceSystem.Entities.DTOs;

namespace StudentAttendanceSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("faculties")]
    public class FacultiesController : ControllerBase
    {

        private readonly IFacultyService _facultyService;
        public FacultiesController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _facultyService.GetByDetailAsync();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> AddAsync(FacultyDto dto)
        {
            var result = await _facultyService.AddAsync(new Faculty()
            {
                FacultyName = dto.Name,
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
            var result = await _facultyService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _facultyService.GetByIdDetailAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] FacultyUpdateDto dto)
        {
            var result = await _facultyService.UpdateAsync(new Faculty()
            {
                FacultyName = dto.Name,
                Departments = dto.DepartmentIds.Select(x => new Department()
                {
                    DepartmentId = x
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
