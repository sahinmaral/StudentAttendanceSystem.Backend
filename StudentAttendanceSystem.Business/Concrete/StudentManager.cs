using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Core.Aspects.Autofac.Caching;
using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

using System.Linq.Expressions;

namespace StudentAttendanceSystem.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private readonly IStudentDal _studentDal;
        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }
        public IResult CheckIfStudentExists(Guid studentId)
        {
            Student addedStudent = GetById(studentId).Data;
            if (addedStudent == null)
            {
                return new ErrorResult("Yazilan ID'ye bagli bir ogrenci yok");
            }

            return new SuccessResult();
        }

        [CacheRemoveAspect
            ($"{nameof(IStudentService)}{nameof(Get)}," +
            $"{nameof(IStudentService)}{nameof(GetAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetByDetail)}" +
            $"{nameof(IStudentService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetById)}" +
            $"{nameof(IStudentService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetWhere)}" +
            $"{nameof(IStudentService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetSingle)}" +
            $"{nameof(IStudentService)}{nameof(GetSingleAsync)}")]
        public IResult Add(Student student)
        {
            _studentDal.Add(student);

            return new SuccessResult("Ogrenci basariyla eklendi");
        }
        [CacheRemoveAspect
            ($"{nameof(IStudentService)}{nameof(Get)}," +
            $"{nameof(IStudentService)}{nameof(GetAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetByDetail)}" +
            $"{nameof(IStudentService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetById)}" +
            $"{nameof(IStudentService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetWhere)}" +
            $"{nameof(IStudentService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetSingle)}" +
            $"{nameof(IStudentService)}{nameof(GetSingleAsync)}")]
        public async Task<IResult> AddAsync(Student student)
        {
            await _studentDal.AddAsync(student);

            return new SuccessResult("Ogrenci basariyla eklendi");
        }
        [CacheRemoveAspect
            ($"{nameof(IStudentService)}{nameof(Get)}," +
            $"{nameof(IStudentService)}{nameof(GetAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetByDetail)}" +
            $"{nameof(IStudentService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetById)}" +
            $"{nameof(IStudentService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetWhere)}" +
            $"{nameof(IStudentService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetSingle)}" +
            $"{nameof(IStudentService)}{nameof(GetSingleAsync)}")]
        public IResult Delete(Guid id)
        {
            _studentDal.Delete(GetById(id).Data);

            return new SuccessResult("Ogrenci basariyla silindi");
        }

        [CacheRemoveAspect
            ($"{nameof(IStudentService)}{nameof(Get)}," +
            $"{nameof(IStudentService)}{nameof(GetAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetByDetail)}" +
            $"{nameof(IStudentService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetById)}" +
            $"{nameof(IStudentService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetWhere)}" +
            $"{nameof(IStudentService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetSingle)}" +
            $"{nameof(IStudentService)}{nameof(GetSingleAsync)}")]
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var student = await GetByIdAsync(id);
            await _studentDal.DeleteAsync(student.Data);

            return new SuccessResult("Ogrenci basariyla silindi");
        }

        [CacheAspect(10)]
        public IDataResult<List<Student>> Get()
        {
            return new SuccessDataResult<List<Student>>(_studentDal.Get());
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<Student>>> GetAsync()
        {
            return new SuccessDataResult<List<Student>>(await _studentDal.GetAsync());
        }

        [CacheAspect(10)]
        public IDataResult<List<Student>> GetByDetail()
        {
            return new SuccessDataResult<List<Student>>(_studentDal.GetByDetail());
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<Student>>> GetByDetailAsync()
        {
            return new SuccessDataResult<List<Student>>(await _studentDal.GetByDetailAsync());
        }

        [CacheAspect(10)]
        public IDataResult<Student> GetById(Guid id)
        {
            return new SuccessDataResult<Student>(_studentDal.GetById(id));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<Student>> GetByIdAsync(Guid id)
        {
            return new SuccessDataResult<Student>(await _studentDal.GetByIdAsync(id));
        }

        [CacheAspect(10)]
        public IDataResult<Student> GetByIdDetail(Guid id)
        {
            return new SuccessDataResult<Student>(_studentDal.GetByIdDetail(id));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<Student>> GetByIdDetailAsync(Guid id)
        {
            return new SuccessDataResult<Student>(await _studentDal.GetByIdDetailAsync(id));
        }

        [CacheAspect(10)]
        public IDataResult<Student> GetSingle(Expression<Func<Student, bool>> predicate)
        {
            return new SuccessDataResult<Student>(_studentDal.GetSingle(predicate));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<Student>> GetSingleAsync(Expression<Func<Student, bool>> predicate)
        {
            return new SuccessDataResult<Student>(await _studentDal.GetSingleAsync(predicate));
        }

        [CacheAspect(10)]
        public IDataResult<List<Student>> GetWhere(Expression<Func<Student, bool>> predicate)
        {
            return new SuccessDataResult<List<Student>>(_studentDal.GetWhere(predicate));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<Student>>> GetWhereAsync(Expression<Func<Student, bool>> predicate)
        {
            return new SuccessDataResult<List<Student>>(await _studentDal.GetWhereAsync(predicate));
        }

        [CacheRemoveAspect
            ($"{nameof(IStudentService)}{nameof(Get)}," +
            $"{nameof(IStudentService)}{nameof(GetAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetByDetail)}" +
            $"{nameof(IStudentService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetById)}" +
            $"{nameof(IStudentService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetWhere)}" +
            $"{nameof(IStudentService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetSingle)}" +
            $"{nameof(IStudentService)}{nameof(GetSingleAsync)}")]
        public IResult Update(Student student)
        {
            var result = CheckIfStudentExists(student.StudentId);
            if (!result.Success) return result;

            Student updatedStudent = GetByIdDetail(student.StudentId).Data;

            updatedStudent.User = student.User;
            updatedStudent.Lectures = student.Lectures;
            updatedStudent.StudentSchoolNumber = student.StudentSchoolNumber;
            updatedStudent.StudentSchoolCard = student.StudentSchoolCard;

            _studentDal.Update(updatedStudent);

            return new SuccessResult("Ogrenci basariyla guncellendi");
        }

        [CacheRemoveAspect
            ($"{nameof(IStudentService)}{nameof(Get)}," +
            $"{nameof(IStudentService)}{nameof(GetAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetByDetail)}" +
            $"{nameof(IStudentService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetById)}" +
            $"{nameof(IStudentService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetWhere)}" +
            $"{nameof(IStudentService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IStudentService)}{nameof(GetSingle)}" +
            $"{nameof(IStudentService)}{nameof(GetSingleAsync)}")]
        public async Task<IResult> UpdateAsync(Student student)
        {
            var result = CheckIfStudentExists(student.StudentId);
            if (!result.Success) return result;

            Student updatedStudent = GetByIdDetail(student.StudentId).Data;

            updatedStudent.User = student.User;
            updatedStudent.Lectures = student.Lectures;
            updatedStudent.StudentSchoolNumber = student.StudentSchoolNumber;
            updatedStudent.StudentSchoolCard = student.StudentSchoolCard;

            await _studentDal.UpdateAsync(updatedStudent);

            return new SuccessResult("Ogrenci basariyla guncellendi");
        }

    }
}
