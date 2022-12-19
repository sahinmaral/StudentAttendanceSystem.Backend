using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Core.Entities.Abstract;
using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.DataAccess.Concrete;
using StudentAttendanceSystem.Entities.Concrete;
using StudentAttendanceSystem.Entities.DTOs;

using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace StudentAttendanceSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("lectures")]
    public class LecturesController : ControllerBase
    {

        private readonly ILectureService _lectureService;
        public LecturesController(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var result = await _lectureService.GetByDetailAsync();

            stopwatch.Stop();

            Console.WriteLine($"Elapsed miliseconds : {stopwatch.ElapsedMilliseconds}");

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> AddAsync(LectureDto dto)
        {
            var result = await _lectureService.AddAsync(new Lecture()
            {
                Departments = dto.DepartmentIds.Select(x => new Department()
                {
                    DepartmentId = x
                }).ToList(),
                LectureHours = dto.LectureHourIds.Select(x => new LectureHour()
                {
                    LectureHourId = x
                }).ToList(),
                Instructors = dto.InstructorIds.Select(x => new Instructor()
                {
                    InstructorId = x
                }).ToList(),
                LectureName = dto.Name,
                LectureCode = dto.Code,
                LectureLanguage = dto.Language,
                LectureClassCode = dto.ClassCode,
                LectureDay = dto.Day
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
            var result = await _lectureService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _lectureService.GetByIdDetailAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        //[HttpGet("isExists")]
        //public async Task<IActionResult> IsExists(Guid id)
        //{
        //    var result = await _lectureService.GetAsync();
        //    if(result.Data == null)
        //    {
        //        return BadRequest(false);
        //    }

        //    return Ok(true);
        //}

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] LectureUpdateDto dto)
        {
            var result = await _lectureService.UpdateAsync(new Lecture()
            {
                Departments = dto.DepartmentIds.Select(x => new Department()
                {
                    DepartmentId = x
                }).ToList(),
                LectureHours = dto.LectureHourIds.Select(x => new LectureHour()
                {
                    LectureHourId = x
                }).ToList(),
                Instructors = dto.InstructorIds.Select(x => new Instructor()
                {
                    InstructorId = x
                }).ToList(),
                Students = dto.StudentIds.Select(x => new Student()
                {
                    StudentId = x
                }).ToList(),
                LectureName = dto.Name,
                LectureCode = dto.Code,
                LectureLanguage = dto.Language,
                LectureClassCode = dto.ClassCode,
                LectureDay = dto.Day,
                LectureId = id
            });
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}