using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Core.Aspects.Autofac.Caching;
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
        private readonly IDepartmentService _departmentService;
        private readonly ILectureHourService _lectureHourService;
        private readonly IInstructorService _instructorService;
        public LectureManager(ILectureDal lectureDal, IDepartmentService departmentService, ILectureHourService lectureHourService, IInstructorService instructorService)
        {
            _lectureDal = lectureDal;
            _departmentService = departmentService;
            _lectureHourService = lectureHourService;
            _instructorService = instructorService;
        }
        public IResult CheckIfLectureExists(Guid lectureId)
        {
            Lecture addedLecture = GetById(lectureId).Data;
            if (addedLecture == null)
            {
                return new ErrorResult("Yazilan ID'ye bagli bir ders yok");
            }

            return new SuccessResult();
        }
        public IResult CheckIfLectureAlreadyAddedAtDepartments(Guid lectureId, List<Guid> departmentIds)
        {
            Lecture addedLecture = GetByIdDetail(lectureId).Data;

            foreach (var departmentId in departmentIds)
            {
                Department lectureAddedDepartment = _departmentService.GetById(departmentId).Data;

                if (addedLecture.Departments.Contains(lectureAddedDepartment))
                {
                    return new ErrorResult($"{lectureAddedDepartment.DepartmentName} department uzerinde zaten ders ekli");
                }
            }

            return new SuccessResult();

        }
        private IResult CheckIfDepartmentsAreExistedAndNotDuplicated(List<Guid> departmentIds)
        {
            if (departmentIds.Count != departmentIds.Distinct().Count())
            {
                return new ErrorResult("Yazilan department ID degerlerinden birinden birden fazla yazildigi tespit edildi. Tekrar kontrol ediniz.");
            }

            foreach (var departmentId in departmentIds)
            {
                var department = _departmentService.GetById(departmentId).Data;
                if (department == null)
                {
                    return new ErrorResult("Boyle bir department yok");
                }
            }

            return new SuccessResult();

        }
        private IResult CheckIfInstructorsAreExistedAndNotDuplicated(List<Guid> instructorIds)
        {
            if (instructorIds.Count != instructorIds.Distinct().Count())
            {
                return new ErrorResult("Yazilan ogretmen ID degerlerinden birinden birden fazla yazildigi tespit edildi. Tekrar kontrol ediniz.");
            }

            foreach (var instructorId in instructorIds)
            {
                var instructor = _instructorService.GetById(instructorId).Data;
                if (instructor == null)
                {
                    return new ErrorResult("Boyle bir ogretmen yok");
                }
            }

            return new SuccessResult();
        }
        private IResult CheckIfLectureHoursAreExistedAndNotDuplicated(List<Guid> lectureHourIds)
        {
            if (lectureHourIds.Count != lectureHourIds.Distinct().Count())
            {
                return new ErrorResult("Yazilan ders saati ID degerlerinden birinden birden fazla yazildigi tespit edildi. Tekrar kontrol ediniz.");
            }

            foreach (var lectureHourId in lectureHourIds)
            {
                var lectureHour = _lectureHourService.GetById(lectureHourId).Data;
                if (lectureHour == null)
                {
                    return new ErrorResult("Boyle bir ders saati yok");
                }
            }

            return new SuccessResult();
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

        [CacheRemoveAspect
            ($"{nameof(ILectureService)}{nameof(Get)}," +
            $"{nameof(ILectureService)}{nameof(GetAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetByDetail)}" +
            $"{nameof(ILectureService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetById)}" +
            $"{nameof(ILectureService)}{nameof(GetByIdAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetWhere)}" +
            $"{nameof(ILectureService)}{nameof(GetWhereAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetSingle)}" +
            $"{nameof(ILectureService)}{nameof(GetSingleAsync)}")]
        public IResult Add(Lecture lecture)
        {
            var result = BusinessRules.Run(
                CheckIfDepartmentsAreExistedAndNotDuplicated(lecture.Departments.Select(x=>x.DepartmentId).ToList()),
                CheckIfInstructorsAreExistedAndNotDuplicated(lecture.Instructors.Select(x => x.InstructorId).ToList()),
                CheckIfLectureHoursAreExistedAndNotDuplicated(lecture.LectureHours.Select(x => x.LectureHourId).ToList())
                );

            if (result != null) return result;

            Lecture newLecture = new Lecture()
            {
                LectureId = new Guid(),
                LectureName = lecture.LectureName,
                LectureCode = lecture.LectureCode,
                LectureLanguage = lecture.LectureLanguage,
                LectureClassCode = lecture.LectureClassCode,
                LectureHours = lecture.LectureHours,
                Departments = lecture.Departments,
                Instructors = lecture.Instructors
            };

            _lectureDal.Add(newLecture);

            return new SuccessResult("Ders basariyla eklendi");
        }
        [CacheRemoveAspect
            ($"{nameof(ILectureService)}{nameof(Get)}," +
            $"{nameof(ILectureService)}{nameof(GetAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetByDetail)}" +
            $"{nameof(ILectureService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetById)}" +
            $"{nameof(ILectureService)}{nameof(GetByIdAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetWhere)}" +
            $"{nameof(ILectureService)}{nameof(GetWhereAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetSingle)}" +
            $"{nameof(ILectureService)}{nameof(GetSingleAsync)}")]
        public async Task<IResult> AddAsync(Lecture lecture)
        {
            var result = BusinessRules.Run(
                CheckIfDepartmentsAreExistedAndNotDuplicated(lecture.Departments.Select(x => x.DepartmentId).ToList()),
                CheckIfInstructorsAreExistedAndNotDuplicated(lecture.Instructors.Select(x => x.InstructorId).ToList()),
                CheckIfLectureHoursAreExistedAndNotDuplicated(lecture.LectureHours.Select(x => x.LectureHourId).ToList())
                );

            if (result != null) return result;

            Lecture newLecture = new Lecture()
            {
                LectureId = new Guid(),
                LectureName = lecture.LectureName,
                LectureCode = lecture.LectureCode,
                LectureLanguage = lecture.LectureLanguage,
                LectureClassCode = lecture.LectureClassCode,
                LectureHours = lecture.LectureHours,
                Departments = lecture.Departments,
                Instructors = lecture.Instructors
            };

            await _lectureDal.AddAsync(newLecture);

            return new SuccessResult("Ders basariyla eklendi");
        }
        [CacheRemoveAspect
            ($"{nameof(ILectureService)}{nameof(Get)}," +
            $"{nameof(ILectureService)}{nameof(GetAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetByDetail)}" +
            $"{nameof(ILectureService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetById)}" +
            $"{nameof(ILectureService)}{nameof(GetByIdAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetWhere)}" +
            $"{nameof(ILectureService)}{nameof(GetWhereAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetSingle)}" +
            $"{nameof(ILectureService)}{nameof(GetSingleAsync)}")]
        public IResult Delete(Guid id)
        {
            _lectureDal.Delete(_lectureDal.GetById(id));

            return new SuccessResult("Ders basariyla silindi");
        }

        [CacheRemoveAspect
            ($"{nameof(ILectureService)}{nameof(Get)}," +
            $"{nameof(ILectureService)}{nameof(GetAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetByDetail)}" +
            $"{nameof(ILectureService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetById)}" +
            $"{nameof(ILectureService)}{nameof(GetByIdAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetWhere)}" +
            $"{nameof(ILectureService)}{nameof(GetWhereAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetSingle)}" +
            $"{nameof(ILectureService)}{nameof(GetSingleAsync)}")]
        public async Task<IResult> DeleteAsync(Guid id)
        {
            await _lectureDal.DeleteAsync(await _lectureDal.GetByIdAsync(id));

            return new SuccessResult("Ders basariyla silindi");
        }

        [CacheAspect(10)]
        public IDataResult<List<Lecture>> Get()
        {
            return new SuccessDataResult<List<Lecture>>(_lectureDal.Get());
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<Lecture>>> GetAsync()
        {
            return new SuccessDataResult<List<Lecture>>(await _lectureDal.GetAsync());
        }

        [CacheAspect(10)]
        public IDataResult<List<Lecture>> GetByDetail()
        {
            return new SuccessDataResult<List<Lecture>>(_lectureDal.GetByDetail());
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<Lecture>>> GetByDetailAsync()
        {
            return new SuccessDataResult<List<Lecture>>(await _lectureDal.GetByDetailAsync());
        }

        [CacheAspect(10)]
        public IDataResult<Lecture> GetById(Guid id)
        {
            return new SuccessDataResult<Lecture>(_lectureDal.GetById(id));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<Lecture>> GetByIdAsync(Guid id)
        {
            return new SuccessDataResult<Lecture>(await _lectureDal.GetByIdAsync(id));
        }

        [CacheAspect(10)]
        public IDataResult<Lecture> GetByIdDetail(Guid id)
        {
            return new SuccessDataResult<Lecture>(_lectureDal.GetByIdDetail(id));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<Lecture>> GetByIdDetailAsync(Guid id)
        {
            return new SuccessDataResult<Lecture>(await _lectureDal.GetByIdDetailAsync(id));
        }

        [CacheAspect(10)]
        public IDataResult<Lecture> GetSingle(Expression<Func<Lecture, bool>> predicate)
        {
            return new SuccessDataResult<Lecture>(_lectureDal.GetSingle(predicate));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<Lecture>> GetSingleAsync(Expression<Func<Lecture, bool>> predicate)
        {
            return new SuccessDataResult<Lecture>(await _lectureDal.GetSingleAsync(predicate));
        }

        [CacheAspect(10)]
        public IDataResult<List<Lecture>> GetWhere(Expression<Func<Lecture, bool>> predicate)
        {
            return new SuccessDataResult<List<Lecture>>(_lectureDal.GetWhere(predicate));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<Lecture>>> GetWhereAsync(Expression<Func<Lecture, bool>> predicate)
        {
            return new SuccessDataResult<List<Lecture>>(await _lectureDal.GetWhereAsync(predicate));
        }

        [CacheRemoveAspect
            ($"{nameof(ILectureService)}{nameof(Get)}," +
            $"{nameof(ILectureService)}{nameof(GetAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetByDetail)}" +
            $"{nameof(ILectureService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetById)}" +
            $"{nameof(ILectureService)}{nameof(GetByIdAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetWhere)}" +
            $"{nameof(ILectureService)}{nameof(GetWhereAsync)}" +
            $"{nameof(ILectureService)}{nameof(GetSingle)}" +
            $"{nameof(ILectureService)}{nameof(GetSingleAsync)}")]
        public IResult Update(Lecture lecture)
        {
            var result = CheckIfLectureExists(lecture.LectureId);
            if (!result.Success) return result;

            Lecture updatedLecture = GetByIdDetail(lecture.LectureId).Data;

            updatedLecture.LectureName = lecture.LectureName;
            updatedLecture.LectureLanguage = lecture.LectureLanguage;
            updatedLecture.LectureCode = lecture.LectureCode;
            updatedLecture.Departments = lecture.Departments;
            updatedLecture.LectureHours = lecture.LectureHours;
            updatedLecture.Instructors = lecture.Instructors;
            updatedLecture.Students = lecture.Students;

            _lectureDal.Update(updatedLecture);

            return new SuccessResult("Ders basariyla guncellendi");
        }

        [CacheRemoveAspect
            ($"{nameof(IDepartmentService)}{nameof(Get)}," +
            $"{nameof(IDepartmentService)}{nameof(GetAsync)}" +
            $"{nameof(IDepartmentService)}{nameof(GetByDetail)}" +
            $"{nameof(IDepartmentService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IDepartmentService)}{nameof(GetById)}" +
            $"{nameof(IDepartmentService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IDepartmentService)}{nameof(GetWhere)}" +
            $"{nameof(IDepartmentService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IDepartmentService)}{nameof(GetSingle)}" +
            $"{nameof(IDepartmentService)}{nameof(GetSingleAsync)}")]
        public async Task<IResult> UpdateAsync(Lecture lecture)
        {
            var result = CheckIfLectureExists(lecture.LectureId);
            if (!result.Success) return result;

            Lecture updatedLecture = GetByIdDetail(lecture.LectureId).Data;

            updatedLecture.LectureName = lecture.LectureName;
            updatedLecture.LectureLanguage = lecture.LectureLanguage;
            updatedLecture.LectureCode = lecture.LectureCode;
            updatedLecture.Departments = lecture.Departments;
            updatedLecture.LectureHours = lecture.LectureHours;
            updatedLecture.Instructors = lecture.Instructors;
            updatedLecture.Students = lecture.Students;

            await _lectureDal.UpdateAsync(updatedLecture);

            return new SuccessResult("Ders basariyla guncellendi");
        }

    }
}
