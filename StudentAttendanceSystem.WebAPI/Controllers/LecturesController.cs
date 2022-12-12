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

        [HttpGet("get")]
        public IActionResult Get()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var result = _lectureService.GetByDetail();

            stopwatch.Stop();

            Console.WriteLine($"Elapsed miliseconds : {stopwatch.ElapsedMilliseconds}");

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("getAsync")]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _lectureService.GetByDetailAsync();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("add")]
        public IActionResult Add(LectureAddDto dto)
        {
            var result = _lectureService.Add(new Lecture()
            {
                Departments = dto.DepartmentIds.Select(x=> new Department()
                {
                    DepartmentId = x
                }).ToList(),
                LectureHours = dto.LectureHourIds.Select(x => new LectureHour()
                {
                    LectureHourId = x
                }).ToList(),
                Instructors = dto.InstructorIds.Select(x=> new Instructor()
                {
                    InstructorId = x
                }).ToList(),
                LectureName = dto.LectureName,
                LectureCode = dto.LectureCode,
                LectureLanguage = dto.LectureLanguage,
                LectureClassCode = dto.LectureClassCode,
            });

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpPut("addAsync")]
        public async Task<IActionResult> AddAsync(LectureAddDto dto)
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
                LectureName = dto.LectureName,
                LectureCode = dto.LectureCode,
                LectureLanguage = dto.LectureLanguage,
                LectureClassCode = dto.LectureClassCode,
            });

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _lectureService.Delete(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("deleteAsync")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _lectureService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(Guid id)
        {
            var result = _lectureService.GetByIdDetail(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("getByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _lectureService.GetByIdDetailAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("isExists")]
        public async Task<IActionResult> IsExists(Guid id)
        {
            var result = await _lectureService.GetAsync();
            if(result.Data == null)
            {
                return BadRequest(false);
            }

            return Ok(true);
        }

        [HttpPatch("update")]
        public IActionResult Update(LectureUpdateDto dto)
        {
            var result = _lectureService.Update(new Lecture()
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
                LectureName = dto.LectureName,
                LectureCode = dto.LectureCode,
                LectureLanguage = dto.LectureLanguage,
                LectureClassCode = dto.LectureClassCode,
            });
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPatch("updateAsync")]
        public async Task<IActionResult> UpdateAsync(LectureUpdateDto dto)
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
                LectureName = dto.LectureName,
                LectureCode = dto.LectureCode,
                LectureLanguage = dto.LectureLanguage,
                LectureClassCode = dto.LectureClassCode,
            });
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}