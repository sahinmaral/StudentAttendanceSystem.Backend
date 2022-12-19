using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Entities.Concrete;
using StudentAttendanceSystem.Entities.DTOs;

namespace StudentAttendanceSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("lectureHours")]
    public class LectureHoursController : ControllerBase
    {

        private readonly ILectureHourService _lectureHourService;
        public LectureHoursController(ILectureHourService lectureHourService)
        {
            _lectureHourService = lectureHourService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _lectureHourService.GetByDetailAsync();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> AddAsync(LectureHourDto dto)
        {
            var result = await _lectureHourService.AddAsync(new LectureHour()
            {
                LectureHourEndHour = dto.EndHour,
                LectureHourStartHour = dto.StartHour,
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
            var result = await _lectureHourService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _lectureHourService.GetByIdDetailAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] LectureHourUpdateDto dto)
        {
            var result = await _lectureHourService.UpdateAsync(new LectureHour()
            {
                LectureHourEndHour = dto.EndHour,
                LectureHourStartHour = dto.StartHour,
                LectureHourId = id,
                Lectures = dto.LectureIds.Select(x => new Lecture()
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
