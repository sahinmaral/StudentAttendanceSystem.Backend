using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Core.Aspects.Autofac.Caching;
using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

using System.Linq.Expressions;

namespace StudentAttendanceSystem.Business.Concrete
{
    public class StudentSchoolCardManager:IStudentSchoolCardService
    {
        private readonly IStudentSchoolCardDal _studentSchoolCardDal;
        public StudentSchoolCardManager(IStudentSchoolCardDal studentSchoolCardDal)
        {
            _studentSchoolCardDal = studentSchoolCardDal;
        }
        public IResult CheckIfStudentSchoolCardExists(Guid studentSchoolCardId)
        {
            StudentSchoolCard addedStudentSchoolCard = GetById(studentSchoolCardId).Data;
            if (addedStudentSchoolCard == null)
            {
                return new ErrorResult("Yazilan ID'ye bagli bir ogrenci karti yok");
            }

            return new SuccessResult();
        }
        private IResult CheckIfStudentSchoolCardPhysicalIdIsNotAlreadyTaken(string cardUID)
        {
            var studentSchoolCard = GetSingle(x => x.StudentSchoolCardPhysicalUID == cardUID).Data;
            if (studentSchoolCard != null)
            {
                return new ErrorResult("Bu isimde bir ogrenci karti zaten kayitlidir");
            }
            return new SuccessResult();
        }

        [CacheRemoveAspect
            ($"{nameof(IStudentSchoolCardService)}{nameof(Get)}," +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByDetail)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetById)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetWhere)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetSingle)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetSingleAsync)}")]
        public IResult Add(StudentSchoolCard studentSchoolCard)
        {
            _studentSchoolCardDal.Add(studentSchoolCard);

            return new SuccessResult("StudentSchoolCard basariyla eklendi");
        }
        [CacheRemoveAspect
            ($"{nameof(IStudentSchoolCardService)}{nameof(Get)}," +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByDetail)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetById)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetWhere)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetSingle)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetSingleAsync)}")]
        public async Task<IResult> AddAsync(StudentSchoolCard studentSchoolCard)
        {
            await _studentSchoolCardDal.AddAsync(studentSchoolCard);

            return new SuccessResult("StudentSchoolCard basariyla eklendi");
        }
        [CacheRemoveAspect
            ($"{nameof(IStudentSchoolCardService)}{nameof(Get)}," +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByDetail)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetById)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetWhere)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetSingle)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetSingleAsync)}")]
        public IResult Delete(Guid id)
        {
            _studentSchoolCardDal.Delete(GetById(id).Data);

            return new SuccessResult("StudentSchoolCard basariyla silindi");
        }

        [CacheRemoveAspect
            ($"{nameof(IStudentSchoolCardService)}{nameof(Get)}," +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByDetail)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetById)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetWhere)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetSingle)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetSingleAsync)}")]
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var studentSchoolCard = await GetByIdAsync(id);
            await _studentSchoolCardDal.DeleteAsync(studentSchoolCard.Data);

            return new SuccessResult("StudentSchoolCard basariyla silindi");
        }

        [CacheAspect(10)]
        public IDataResult<List<StudentSchoolCard>> Get()
        {
            return new SuccessDataResult<List<StudentSchoolCard>>(_studentSchoolCardDal.Get());
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<StudentSchoolCard>>> GetAsync()
        {
            return new SuccessDataResult<List<StudentSchoolCard>>(await _studentSchoolCardDal.GetAsync());
        }

        [CacheAspect(10)]
        public IDataResult<List<StudentSchoolCard>> GetByDetail()
        {
            return new SuccessDataResult<List<StudentSchoolCard>>(_studentSchoolCardDal.GetByDetail());
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<StudentSchoolCard>>> GetByDetailAsync()
        {
            return new SuccessDataResult<List<StudentSchoolCard>>(await _studentSchoolCardDal.GetByDetailAsync());
        }

        [CacheAspect(10)]
        public IDataResult<StudentSchoolCard> GetById(Guid id)
        {
            return new SuccessDataResult<StudentSchoolCard>(_studentSchoolCardDal.GetById(id));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<StudentSchoolCard>> GetByIdAsync(Guid id)
        {
            return new SuccessDataResult<StudentSchoolCard>(await _studentSchoolCardDal.GetByIdAsync(id));
        }

        [CacheAspect(10)]
        public IDataResult<StudentSchoolCard> GetByIdDetail(Guid id)
        {
            return new SuccessDataResult<StudentSchoolCard>(_studentSchoolCardDal.GetByIdDetail(id));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<StudentSchoolCard>> GetByIdDetailAsync(Guid id)
        {
            return new SuccessDataResult<StudentSchoolCard>(await _studentSchoolCardDal.GetByIdDetailAsync(id));
        }

        [CacheAspect(10)]
        public IDataResult<StudentSchoolCard> GetSingle(Expression<Func<StudentSchoolCard, bool>> predicate)
        {
            return new SuccessDataResult<StudentSchoolCard>(_studentSchoolCardDal.GetSingle(predicate));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<StudentSchoolCard>> GetSingleAsync(Expression<Func<StudentSchoolCard, bool>> predicate)
        {
            return new SuccessDataResult<StudentSchoolCard>(await _studentSchoolCardDal.GetSingleAsync(predicate));
        }

        [CacheAspect(10)]
        public IDataResult<List<StudentSchoolCard>> GetWhere(Expression<Func<StudentSchoolCard, bool>> predicate)
        {
            return new SuccessDataResult<List<StudentSchoolCard>>(_studentSchoolCardDal.GetWhere(predicate));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<StudentSchoolCard>>> GetWhereAsync(Expression<Func<StudentSchoolCard, bool>> predicate)
        {
            return new SuccessDataResult<List<StudentSchoolCard>>(await _studentSchoolCardDal.GetWhereAsync(predicate));
        }

        [CacheRemoveAspect
            ($"{nameof(IStudentSchoolCardService)}{nameof(Get)}," +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByDetail)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetById)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetWhere)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetSingle)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetSingleAsync)}")]
        public IResult Update(StudentSchoolCard studentSchoolCard)
        {
            var result = CheckIfStudentSchoolCardExists(studentSchoolCard.StudentSchoolCardId);
            if (!result.Success) return result;

            StudentSchoolCard updatedStudentSchoolCard = GetByIdDetail(studentSchoolCard.StudentSchoolCardId).Data;

            updatedStudentSchoolCard.Student = studentSchoolCard.Student;
            updatedStudentSchoolCard.StudentSchoolCardPhysicalUID = studentSchoolCard.StudentSchoolCardPhysicalUID;

            _studentSchoolCardDal.Update(updatedStudentSchoolCard);

            return new SuccessResult("StudentSchoolCard basariyla guncellendi");
        }

        [CacheRemoveAspect
            ($"{nameof(IStudentSchoolCardService)}{nameof(Get)}," +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByDetail)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByDetailAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetById)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetByIdAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetWhere)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetWhereAsync)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetSingle)}" +
            $"{nameof(IStudentSchoolCardService)}{nameof(GetSingleAsync)}")]
        public async Task<IResult> UpdateAsync(StudentSchoolCard studentSchoolCard)
        {
            var result = CheckIfStudentSchoolCardExists(studentSchoolCard.StudentSchoolCardId);
            if (!result.Success) return result;

            StudentSchoolCard updatedStudentSchoolCard = GetByIdDetail(studentSchoolCard.StudentSchoolCardId).Data;

            updatedStudentSchoolCard.Student = studentSchoolCard.Student;
            updatedStudentSchoolCard.StudentSchoolCardPhysicalUID = studentSchoolCard.StudentSchoolCardPhysicalUID;

            await _studentSchoolCardDal.UpdateAsync(updatedStudentSchoolCard);

            return new SuccessResult("Ogrenci karti basariyla guncellendi");
        }
    }
}
