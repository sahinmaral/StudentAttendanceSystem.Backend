using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Core.Aspects.Autofac.Caching;
using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

using System.Linq.Expressions;

namespace LectureHourAttendanceSystem.Business.Concrete
{
    public class LectureHourManager:ILectureHourService
    {
        private readonly ILectureHourDal _lectureHourDal;
        public LectureHourManager(ILectureHourDal lectureHourDal)
        {
            _lectureHourDal = lectureHourDal;
        }
        public IResult CheckIfLectureHourExists(Guid lectureHourId)
        {
            LectureHour addedLectureHour = GetById(lectureHourId).Data;
            if (addedLectureHour == null)
            {
                return new ErrorResult("Yazilan ID'ye bagli bir ders saati yok");
            }

            return new SuccessResult();
        }

        [CacheRemoveAspect
            ($"{nameof(ILectureHourService)}{nameof(Get)}," +
            $"{nameof(ILectureHourService)}{nameof(GetAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByDetail)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetById)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByIdAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetWhere)}" +
            $"{nameof(ILectureHourService)}{nameof(GetWhereAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetSingle)}" +
            $"{nameof(ILectureHourService)}{nameof(GetSingleAsync)}")]
        public IResult Add(LectureHour lectureHour)
        {
            _lectureHourDal.Add(lectureHour);

            return new SuccessResult("Ders saati basariyla eklendi");
        }
        [CacheRemoveAspect
            ($"{nameof(ILectureHourService)}{nameof(Get)}," +
            $"{nameof(ILectureHourService)}{nameof(GetAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByDetail)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetById)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByIdAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetWhere)}" +
            $"{nameof(ILectureHourService)}{nameof(GetWhereAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetSingle)}" +
            $"{nameof(ILectureHourService)}{nameof(GetSingleAsync)}")]
        public async Task<IResult> AddAsync(LectureHour lectureHour)
        {
            await _lectureHourDal.AddAsync(lectureHour);

            return new SuccessResult("Ders saati basariyla eklendi");
        }
        [CacheRemoveAspect
            ($"{nameof(ILectureHourService)}{nameof(Get)}," +
            $"{nameof(ILectureHourService)}{nameof(GetAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByDetail)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetById)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByIdAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetWhere)}" +
            $"{nameof(ILectureHourService)}{nameof(GetWhereAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetSingle)}" +
            $"{nameof(ILectureHourService)}{nameof(GetSingleAsync)}")]
        public IResult Delete(Guid id)
        {
            _lectureHourDal.Delete(GetById(id).Data);

            return new SuccessResult("Ders saati basariyla silindi");
        }

        [CacheRemoveAspect
            ($"{nameof(ILectureHourService)}{nameof(Get)}," +
            $"{nameof(ILectureHourService)}{nameof(GetAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByDetail)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetById)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByIdAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetWhere)}" +
            $"{nameof(ILectureHourService)}{nameof(GetWhereAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetSingle)}" +
            $"{nameof(ILectureHourService)}{nameof(GetSingleAsync)}")]
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var lectureHour = await GetByIdAsync(id);
            await _lectureHourDal.DeleteAsync(lectureHour.Data);

            return new SuccessResult("Ders saati basariyla silindi");
        }

        [CacheAspect(10)]
        public IDataResult<List<LectureHour>> Get()
        {
            return new SuccessDataResult<List<LectureHour>>(_lectureHourDal.Get());
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<LectureHour>>> GetAsync()
        {
            return new SuccessDataResult<List<LectureHour>>(await _lectureHourDal.GetAsync());
        }

        [CacheAspect(10)]
        public IDataResult<List<LectureHour>> GetByDetail()
        {
            return new SuccessDataResult<List<LectureHour>>(_lectureHourDal.GetByDetail());
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<LectureHour>>> GetByDetailAsync()
        {
            return new SuccessDataResult<List<LectureHour>>(await _lectureHourDal.GetByDetailAsync());
        }

        [CacheAspect(10)]
        public IDataResult<LectureHour> GetById(Guid id)
        {
            return new SuccessDataResult<LectureHour>(_lectureHourDal.GetById(id));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<LectureHour>> GetByIdAsync(Guid id)
        {
            return new SuccessDataResult<LectureHour>(await _lectureHourDal.GetByIdAsync(id));
        }

        [CacheAspect(10)]
        public IDataResult<LectureHour> GetByIdDetail(Guid id)
        {
            return new SuccessDataResult<LectureHour>(_lectureHourDal.GetByIdDetail(id));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<LectureHour>> GetByIdDetailAsync(Guid id)
        {
            return new SuccessDataResult<LectureHour>(await _lectureHourDal.GetByIdDetailAsync(id));
        }

        [CacheAspect(10)]
        public IDataResult<LectureHour> GetSingle(Expression<Func<LectureHour, bool>> predicate)
        {
            return new SuccessDataResult<LectureHour>(_lectureHourDal.GetSingle(predicate));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<LectureHour>> GetSingleAsync(Expression<Func<LectureHour, bool>> predicate)
        {
            return new SuccessDataResult<LectureHour>(await _lectureHourDal.GetSingleAsync(predicate));
        }

        [CacheAspect(10)]
        public IDataResult<List<LectureHour>> GetWhere(Expression<Func<LectureHour, bool>> predicate)
        {
            return new SuccessDataResult<List<LectureHour>>(_lectureHourDal.GetWhere(predicate));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<LectureHour>>> GetWhereAsync(Expression<Func<LectureHour, bool>> predicate)
        {
            return new SuccessDataResult<List<LectureHour>>(await _lectureHourDal.GetWhereAsync(predicate));
        }

        [CacheRemoveAspect
            ($"{nameof(ILectureHourService)}{nameof(Get)}," +
            $"{nameof(ILectureHourService)}{nameof(GetAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByDetail)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetById)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByIdAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetWhere)}" +
            $"{nameof(ILectureHourService)}{nameof(GetWhereAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetSingle)}" +
            $"{nameof(ILectureHourService)}{nameof(GetSingleAsync)}")]
        public IResult Update(LectureHour lectureHour)
        {
            var result = CheckIfLectureHourExists(lectureHour.LectureHourId);
            if (!result.Success) return result;

            LectureHour updatedLectureHour = GetByIdDetail(lectureHour.LectureHourId).Data;

;            updatedLectureHour.LectureHourStartHour = lectureHour.LectureHourStartHour;
            updatedLectureHour.LectureHourEndHour = lectureHour.LectureHourEndHour;
            

            _lectureHourDal.Update(updatedLectureHour);

            return new SuccessResult("Ogrenci basariyla guncellendi");
        }

        [CacheRemoveAspect
            ($"{nameof(ILectureHourService)}{nameof(Get)}," +
            $"{nameof(ILectureHourService)}{nameof(GetAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByDetail)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetById)}" +
            $"{nameof(ILectureHourService)}{nameof(GetByIdAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetWhere)}" +
            $"{nameof(ILectureHourService)}{nameof(GetWhereAsync)}" +
            $"{nameof(ILectureHourService)}{nameof(GetSingle)}" +
            $"{nameof(ILectureHourService)}{nameof(GetSingleAsync)}")]
        public async Task<IResult> UpdateAsync(LectureHour lectureHour)
        {
            var result = CheckIfLectureHourExists(lectureHour.LectureHourId);
            if (!result.Success) return result;

            LectureHour updatedLectureHour = GetByIdDetail(lectureHour.LectureHourId).Data;

            ; updatedLectureHour.LectureHourStartHour = lectureHour.LectureHourStartHour;
            updatedLectureHour.LectureHourEndHour = lectureHour.LectureHourEndHour;

            await _lectureHourDal.UpdateAsync(updatedLectureHour);

            return new SuccessResult("Ogrenci basariyla guncellendi");
        }
    }
}
