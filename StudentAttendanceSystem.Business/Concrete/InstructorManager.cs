using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Core.Aspects.Autofac.Caching;
using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

using System.Linq.Expressions;

namespace InstructorAttendanceSystem.Business.Concrete
{
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorDal _instructorDal;
        public InstructorManager(IInstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }
        public IResult CheckIfInstructorExists(Guid instructorId)
        {
            Instructor addedInstructor = GetById(instructorId).Data;
            if (addedInstructor == null)
            {
                return new ErrorResult("Yazilan ID'ye bagli bir ogretmen yok");
            }

            return new SuccessResult();
        }

        [CacheRemoveAspect
            ($"{nameof(IInstructorService)}{nameof(Get)}," +
            $"{nameof(IInstructorService)}{nameof(GetAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetByDetail)}" +
            $"{nameof(IInstructorService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetById)}" +
            $"{nameof(IInstructorService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetWhere)}" +
            $"{nameof(IInstructorService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetSingle)}" +
            $"{nameof(IInstructorService)}{nameof(GetSingleAsync)}")]
        public IResult Add(Instructor instructor)
        {
            _instructorDal.Add(instructor);

            return new SuccessResult("Ogretmen basariyla eklendi");
        }
        [CacheRemoveAspect
            ($"{nameof(IInstructorService)}{nameof(Get)}," +
            $"{nameof(IInstructorService)}{nameof(GetAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetByDetail)}" +
            $"{nameof(IInstructorService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetById)}" +
            $"{nameof(IInstructorService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetWhere)}" +
            $"{nameof(IInstructorService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetSingle)}" +
            $"{nameof(IInstructorService)}{nameof(GetSingleAsync)}")]
        public async Task<IResult> AddAsync(Instructor instructor)
        {
            await _instructorDal.AddAsync(instructor);

            return new SuccessResult("Ogretmen basariyla eklendi");
        }
        [CacheRemoveAspect
            ($"{nameof(IInstructorService)}{nameof(Get)}," +
            $"{nameof(IInstructorService)}{nameof(GetAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetByDetail)}" +
            $"{nameof(IInstructorService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetById)}" +
            $"{nameof(IInstructorService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetWhere)}" +
            $"{nameof(IInstructorService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetSingle)}" +
            $"{nameof(IInstructorService)}{nameof(GetSingleAsync)}")]
        public IResult Delete(Guid id)
        {
            _instructorDal.Delete(GetById(id).Data);

            return new SuccessResult("Ogrenci basariyla silindi");
        }

        [CacheRemoveAspect
            ($"{nameof(IInstructorService)}{nameof(Get)}," +
            $"{nameof(IInstructorService)}{nameof(GetAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetByDetail)}" +
            $"{nameof(IInstructorService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetById)}" +
            $"{nameof(IInstructorService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetWhere)}" +
            $"{nameof(IInstructorService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetSingle)}" +
            $"{nameof(IInstructorService)}{nameof(GetSingleAsync)}")]
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var instructor = await GetByIdAsync(id);
            await _instructorDal.DeleteAsync(instructor.Data);

            return new SuccessResult("Ogretmen basariyla silindi");
        }

        [CacheAspect(10)]
        public IDataResult<List<Instructor>> Get()
        {
            return new SuccessDataResult<List<Instructor>>(_instructorDal.Get());
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<Instructor>>> GetAsync()
        {
            return new SuccessDataResult<List<Instructor>>(await _instructorDal.GetAsync());
        }

        [CacheAspect(10)]
        public IDataResult<List<Instructor>> GetByDetail()
        {
            return new SuccessDataResult<List<Instructor>>(_instructorDal.GetByDetail());
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<Instructor>>> GetByDetailAsync()
        {
            return new SuccessDataResult<List<Instructor>>(await _instructorDal.GetByDetailAsync());
        }

        [CacheAspect(10)]
        public IDataResult<Instructor> GetById(Guid id)
        {
            return new SuccessDataResult<Instructor>(_instructorDal.GetById(id));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<Instructor>> GetByIdAsync(Guid id)
        {
            return new SuccessDataResult<Instructor>(await _instructorDal.GetByIdAsync(id));
        }

        [CacheAspect(10)]
        public IDataResult<Instructor> GetByIdDetail(Guid id)
        {
            return new SuccessDataResult<Instructor>(_instructorDal.GetByIdDetail(id));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<Instructor>> GetByIdDetailAsync(Guid id)
        {
            return new SuccessDataResult<Instructor>(await _instructorDal.GetByIdDetailAsync(id));
        }

        [CacheAspect(10)]
        public IDataResult<Instructor> GetSingle(Expression<Func<Instructor, bool>> predicate)
        {
            return new SuccessDataResult<Instructor>(_instructorDal.GetSingle(predicate));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<Instructor>> GetSingleAsync(Expression<Func<Instructor, bool>> predicate)
        {
            return new SuccessDataResult<Instructor>(await _instructorDal.GetSingleAsync(predicate));
        }

        [CacheAspect(10)]
        public IDataResult<List<Instructor>> GetWhere(Expression<Func<Instructor, bool>> predicate)
        {
            return new SuccessDataResult<List<Instructor>>(_instructorDal.GetWhere(predicate));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<Instructor>>> GetWhereAsync(Expression<Func<Instructor, bool>> predicate)
        {
            return new SuccessDataResult<List<Instructor>>(await _instructorDal.GetWhereAsync(predicate));
        }

        [CacheRemoveAspect
            ($"{nameof(IInstructorService)}{nameof(Get)}," +
            $"{nameof(IInstructorService)}{nameof(GetAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetByDetail)}" +
            $"{nameof(IInstructorService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetById)}" +
            $"{nameof(IInstructorService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetWhere)}" +
            $"{nameof(IInstructorService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetSingle)}" +
            $"{nameof(IInstructorService)}{nameof(GetSingleAsync)}")]
        public IResult Update(Instructor instructor)
        {
            var result = CheckIfInstructorExists(instructor.InstructorId);
            if (!result.Success) return result;

            Instructor updatedInstructor = GetByIdDetail(instructor.InstructorId).Data;

            updatedInstructor.User = instructor.User;
            updatedInstructor.Lectures = instructor.Lectures;

            _instructorDal.Update(updatedInstructor);

            return new SuccessResult("Ogretmen basariyla guncellendi");
        }

        [CacheRemoveAspect
            ($"{nameof(IInstructorService)}{nameof(Get)}," +
            $"{nameof(IInstructorService)}{nameof(GetAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetByDetail)}" +
            $"{nameof(IInstructorService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetById)}" +
            $"{nameof(IInstructorService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetWhere)}" +
            $"{nameof(IInstructorService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IInstructorService)}{nameof(GetSingle)}" +
            $"{nameof(IInstructorService)}{nameof(GetSingleAsync)}")]
        public async Task<IResult> UpdateAsync(Instructor instructor)
        {
            var result = CheckIfInstructorExists(instructor.InstructorId);
            if (!result.Success) return result;

            Instructor updatedInstructor = GetByIdDetail(instructor.InstructorId).Data;

            updatedInstructor.User = instructor.User;
            updatedInstructor.Lectures = instructor.Lectures;

            await _instructorDal.UpdateAsync(updatedInstructor);

            return new SuccessResult("Ogretmen basariyla guncellendi");
        }

    }
}
