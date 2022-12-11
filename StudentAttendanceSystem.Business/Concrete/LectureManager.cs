using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Core.Utilities.Business;
using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;
using StudentAttendanceSystem.Entities.DTOs;

using System.Data;
using System.Linq.Expressions;

namespace StudentAttendanceSystem.Business.Concrete
{
    public class LectureManager : ILectureService
    {
        private readonly ILectureDal _lectureDal;
        private readonly IDepartmentDal _departmentDal;
        private readonly ILectureHourDal _lectureHourDal;
        private readonly IInstructorDal _instructorDal;
        public LectureManager(ILectureDal lectureDal, IDepartmentDal departmentDal, ILectureHourDal lectureHourDal, IInstructorDal instructorDal)
        {
            _lectureDal = lectureDal;
            _departmentDal = departmentDal;
            _lectureHourDal = lectureHourDal;
            _instructorDal = instructorDal;
        }

        public IResult Add(LectureAddDto dto)
        {
            var result = BusinessRules.Run(
                CheckIfDepartmentsAreExistedAndNotDuplicated(dto.DepartmentIds),
                CheckIfInstructorsAreExistedAndNotDuplicated(dto.InstructorIds),
                CheckIfLectureHoursAreExistedAndNotDuplicated(dto.LectureHourIds)
                );

            if (result != null) return result;

            Lecture newLecture = new Lecture()
            {
                LectureId = new Guid(),
                LectureName = dto.LectureName,
                LectureCode = dto.LectureCode,
                LectureLanguage = dto.LectureLanguage,
                LectureClassCode = dto.LectureClassCode,
                LectureHours = dto.LectureHourIds.Select(x =>
                {
                    return new LectureHour() { LectureHourId = new Guid(x) };
                }).ToList(),
                Departments = dto.DepartmentIds.Select(x =>
                {
                    return new Department() { DepartmentId = new Guid(x) };
                }).ToList(),
                Instructors = dto.InstructorIds.Select(x =>
                {
                    Instructor instructor = new Instructor();
                    instructor.InstructorId = new Guid(x);
                    return instructor;
                }).ToList()
            };

            _lectureDal.Add(newLecture);

            return new SuccessResult("Ders basariyla eklendi");
        }

        private IResult CheckIfDepartmentsAreExistedAndNotDuplicated(List<string> departmentIds)
        {
            if (departmentIds.Count != departmentIds.Distinct().Count())
            {
                return new ErrorResult("Yazilan department ID degerlerinden birinden birden fazla yazildigi tespit edildi. Tekrar kontrol ediniz.");
            }

            foreach (var departmentId in departmentIds)
            {
                var department = _departmentDal.GetById(new Guid(departmentId));
                if (department == null)
                {
                    return new ErrorResult("Boyle bir department yok");
                }
            }

            return new SuccessResult();

        }

        private IResult CheckIfInstructorsAreExistedAndNotDuplicated(List<string> instructorIds)
        {
            if (instructorIds.Count != instructorIds.Distinct().Count())
            {
                return new ErrorResult("Yazilan ogretmen ID degerlerinden birinden birden fazla yazildigi tespit edildi. Tekrar kontrol ediniz.");
            }

            foreach (var instructorId in instructorIds)
            {
                var instructor = _instructorDal.GetById(new Guid(instructorId));
                if (instructor == null)
                {
                    return new ErrorResult("Boyle bir ogretmen yok");
                }
            }

            return new SuccessResult();
        }

        private IResult CheckIfLectureHoursAreExistedAndNotDuplicated(List<string> lectureHourIds)
        {
            if (lectureHourIds.Count != lectureHourIds.Distinct().Count())
            {
                return new ErrorResult("Yazilan ders saati ID degerlerinden birinden birden fazla yazildigi tespit edildi. Tekrar kontrol ediniz.");
            }

            foreach (var lectureHourId in lectureHourIds)
            {
                var lectureHour = _lectureHourDal.GetById(new Guid(lectureHourId));
                if (lectureHour == null)
                {
                    return new ErrorResult("Boyle bir ders saati yok");
                }
            }

            return new SuccessResult();
        }

        public async Task<IResult> AddAsync(LectureAddDto dto)
        {
            var result = BusinessRules.Run(CheckIfLectureNameIsNotAlreadyTaken(dto.LectureName));

            if (result != null) return result;


            Lecture newLecture = new Lecture()
            {
                LectureName = dto.LectureName,
                LectureCode = dto.LectureCode,
                LectureLanguage = dto.LectureLanguage,
                LectureClassCode = dto.LectureClassCode,
                LectureHours = dto.LectureHourIds.Select(x =>
                {
                    return new LectureHour() { LectureHourId = new Guid(x) };
                }).ToList(),
                Departments = dto.DepartmentIds.Select(x =>
                {
                    return new Department() { DepartmentId = new Guid(x) };
                }).ToList(),
                Instructors = dto.InstructorIds.Select(x =>
                {
                    Instructor instructor = new Instructor();
                    instructor.InstructorId = new Guid(x);
                    return instructor;
                }).ToList()
            };

            await _lectureDal.AddAsync(newLecture);

            return new SuccessResult("Ders basariyla eklendi");
        }

        private IResult CheckIfLectureNameIsNotAlreadyTaken(string lectureName)
        {
            var lecture = _lectureDal.GetSingle(x => x.LectureName == lectureName);
            if (lecture != null)
            {
                return new ErrorResult("Bu isimde bir ders zaten kayitlidir");
            }
            return new SuccessResult();
        }

        public IResult Delete(Guid id)
        {
            _lectureDal.Delete(_lectureDal.GetById(id));

            return new SuccessResult("Ders basariyla silindi");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            await _lectureDal.DeleteAsync(await _lectureDal.GetByIdAsync(id));

            return new SuccessResult("Ders basariyla silindi");
        }

        public IDataResult<List<Lecture>> Get()
        {
            return new SuccessDataResult<List<Lecture>>(_lectureDal.Get());
        }

        public async Task<IDataResult<List<Lecture>>> GetAsync()
        {
            return new SuccessDataResult<List<Lecture>>(await _lectureDal.GetAsync());
        }

        public IDataResult<List<Lecture>> GetByDetail()
        {
            return new SuccessDataResult<List<Lecture>>(_lectureDal.GetByDetail());
        }

        public async Task<IDataResult<List<Lecture>>> GetByDetailAsync()
        {
            return new SuccessDataResult<List<Lecture>>(await _lectureDal.GetByDetailAsync());
        }

        public IDataResult<Lecture> GetById(Guid id)
        {
            return new SuccessDataResult<Lecture>(_lectureDal.GetById(id));
        }

        public async Task<IDataResult<Lecture>> GetByIdAsync(Guid id)
        {
            return new SuccessDataResult<Lecture>(await _lectureDal.GetByIdAsync(id));
        }

        public IDataResult<Lecture> GetByIdDetail(Guid id)
        {
            return new SuccessDataResult<Lecture>(_lectureDal.GetByIdDetail(id));
        }

        public async Task<IDataResult<Lecture>> GetByIdDetailAsync(Guid id)
        {
            return new SuccessDataResult<Lecture>(await _lectureDal.GetByIdDetailAsync(id));
        }

        public IDataResult<Lecture> GetSingle(Expression<Func<Lecture, bool>> predicate)
        {
            return new SuccessDataResult<Lecture>(_lectureDal.GetSingle(predicate));
        }

        public async Task<IDataResult<Lecture>> GetSingleAsync(Expression<Func<Lecture, bool>> predicate)
        {
            return new SuccessDataResult<Lecture>(await _lectureDal.GetSingleAsync(predicate));
        }

        public IDataResult<List<Lecture>> GetWhere(Expression<Func<Lecture, bool>> predicate)
        {
            return new SuccessDataResult<List<Lecture>>(_lectureDal.GetWhere(predicate));
        }

        public async Task<IDataResult<List<Lecture>>> GetWhereAsync(Expression<Func<Lecture, bool>> predicate)
        {
            return new SuccessDataResult<List<Lecture>>(await _lectureDal.GetWhereAsync(predicate));
        }

        public IResult Update(LectureUpdateDto dto)
        {
            Lecture addedLecture = _lectureDal.GetById(dto.LectureId);
            if (addedLecture == null)
            {
                return new ErrorResult("Yazilan ID'ye bagli bir ders yok");
            }

            addedLecture.LectureName = dto.LectureName;
            addedLecture.LectureLanguage = dto.LectureLanguage;
            addedLecture.LectureCode = dto.LectureCode;

            addedLecture.Departments = dto.DepartmentIds.Select(x =>
            {
                return new Department() { DepartmentId = new Guid(x) };
            }).ToList();

            addedLecture.LectureHours = dto.LectureHourIds.Select(x =>
            {
                return new LectureHour() { LectureHourId = new Guid(x) };
            }).ToList();

            addedLecture.Instructors = dto.InstructorIds.Select(x =>
            {
                return new Instructor() { InstructorId = new Guid(x) };
            }).ToList();

            addedLecture.Students = dto.StudentIds.Select(x =>
            {
                return new Student() { StudentId = new Guid(x) };
            }).ToList();


            _lectureDal.Update(addedLecture);

            return new SuccessResult("Ders basariyla guncellendi");
        }

        public async Task<IResult> UpdateAsync(LectureUpdateDto dto)
        {
            await _lectureDal.UpdateAsync(null);

            return new SuccessResult("Ders basariyla guncellendi");
        }

        public IResult CheckIfLectureExists(Guid lectureId)
        {
            Lecture addedLecture = _lectureDal.GetById(lectureId);
            if (addedLecture == null)
            {
                return new ErrorResult("Yazilan ID'ye bagli bir ders yok");
            }

            return new SuccessResult();
        }

        public IResult CheckIfLectureAlreadyAddedAtDepartments(Guid lectureId, List<Guid> departmentIds)
        {
            Lecture addedLecture = _lectureDal.GetByIdDetail(lectureId);

            foreach (var departmentId in departmentIds)
            {
                Department lectureAddedDepartment = _departmentDal.GetById(departmentId);

                if (addedLecture.Departments.Contains(lectureAddedDepartment))
                {
                    return new ErrorResult($"{lectureAddedDepartment.DepartmentName} department uzerinde zaten ders ekli");
                }
            }

            return new SuccessResult();

        }

    }
}
