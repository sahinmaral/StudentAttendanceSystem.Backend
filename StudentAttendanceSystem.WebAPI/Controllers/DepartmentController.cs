using Microsoft.AspNetCore.Mvc;

using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Entities.Concrete;
using StudentAttendanceSystem.Entities.DTOs;

namespace StudentAttendanceSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("departments")]
    public class DepartmentsController : ControllerBase
    {

        private readonly IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _departmentService.GetByDetailAsync();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> AddAsync(DepartmentDto dto)
        {
            var result = await _departmentService.AddAsync(new Department()
            {
                Faculty = new Faculty()
                {
                    FacultyId = dto.FacultyId,
                },
                DepartmentName = dto.Name,
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
            var result = await _departmentService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }  

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _departmentService.GetByIdDetailAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id,[FromBody]DepartmentUpdateDto dto)
        {
            var result = await _departmentService.UpdateAsync(new Department()
            {
                Faculty = new Faculty()
                {
                    FacultyId = dto.FacultyId,
                },
                Lectures = dto.LectureIds.Select(x => new Lecture()
                {
                    LectureId = x
                }).ToList(),
                DepartmentName = dto.Name,
                DepartmentId = id
            });
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}