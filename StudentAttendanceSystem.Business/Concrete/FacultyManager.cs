using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Core.Aspects.Autofac.Caching;
using StudentAttendanceSystem.Core.Utilities.Business;
using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

using System.Linq.Expressions;

namespace StudentAttendanceSystem.Business.Concrete
{
    public class FacultyManager:IFacultyService
    {
        private readonly IFacultyDal _facultyDal;
        public FacultyManager(IFacultyDal facultyDal)
        {
            _facultyDal = facultyDal;
        }

        private IResult CheckIfFacultyExists(Guid facultyId)
        {
            Faculty addedFaculty = GetById(facultyId).Data;
            if (addedFaculty == null)
            {
                return new ErrorResult("Yazilan ID'ye bagli bir fakulte yok");
            }

            return new SuccessResult();
        }

        private IResult CheckIfDepartmentNameIsNotAlreadyTaken(string facultyName)
        {
            Faculty addedFaculty = GetSingle(x=>x.FacultyName == facultyName).Data;
            if (addedFaculty != null)
                return new ErrorResult("Bu isimde bir fakulte zaten kayitlidir");
            

            return new SuccessResult();
        }

        [CacheRemoveAspect
            ($"{nameof(IGenericService<Faculty>)}.{nameof(Get)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByDetail)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByDetailAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetById)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByIdAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetWhere)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetWhereAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetSingle)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetSingleAsync)}")]
        public IResult Add(Faculty faculty)
        {
            var result = BusinessRules.Run(CheckIfDepartmentNameIsNotAlreadyTaken(faculty.FacultyName));
            if (!result.Success) return result;

            _facultyDal.Add(faculty);

            return new SuccessResult("Fakulte basariyla eklendi");
        }
        [CacheRemoveAspect
            ($"{nameof(IGenericService<Faculty>)}.{nameof(Get)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByDetail)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByDetailAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetById)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByIdAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetWhere)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetWhereAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetSingle)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetSingleAsync)}")]
        public async Task<IResult> AddAsync(Faculty faculty)
        {
            await _facultyDal.AddAsync(faculty);

            return new SuccessResult("Fakulte basariyla eklendi");
        }
        [CacheRemoveAspect
            ($"{nameof(IGenericService<Faculty>)}.{nameof(Get)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByDetail)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByDetailAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetById)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByIdAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetWhere)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetWhereAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetSingle)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetSingleAsync)}")]
        public IResult Delete(Guid id)
        {
            _facultyDal.Delete(GetById(id).Data);

            return new SuccessResult("Fakulte basariyla silindi");
        }

        [CacheRemoveAspect
            ($"{nameof(IGenericService<Faculty>)}.{nameof(Get)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByDetail)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByDetailAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetById)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByIdAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetWhere)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetWhereAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetSingle)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetSingleAsync)}")]
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var faculty = await GetByIdAsync(id);
            await _facultyDal.DeleteAsync(faculty.Data);

            return new SuccessResult("Fakulte basariyla silindi");
        }

        [CacheAspect(60)]
        public IDataResult<List<Faculty>> Get()
        {
            return new SuccessDataResult<List<Faculty>>(_facultyDal.Get());
        }

        [CacheAspect(60)]
        public async Task<IDataResult<List<Faculty>>> GetAsync()
        {
            return new SuccessDataResult<List<Faculty>>(await _facultyDal.GetAsync());
        }

        [CacheAspect(60)]
        public IDataResult<List<Faculty>> GetByDetail()
        {
            return new SuccessDataResult<List<Faculty>>(_facultyDal.GetByDetail());
        }

        [CacheAspect(60)]
        public async Task<IDataResult<List<Faculty>>> GetByDetailAsync()
        {
            return new SuccessDataResult<List<Faculty>>(await _facultyDal.GetByDetailAsync());
        }

        [CacheAspect(60)]
        public IDataResult<Faculty> GetById(Guid id)
        {
            return new SuccessDataResult<Faculty>(_facultyDal.GetById(id));
        }

        [CacheAspect(60)]
        public async Task<IDataResult<Faculty>> GetByIdAsync(Guid id)
        {
            return new SuccessDataResult<Faculty>(await _facultyDal.GetByIdAsync(id));
        }

        [CacheAspect(60)]
        public IDataResult<Faculty> GetByIdDetail(Guid id)
        {
            return new SuccessDataResult<Faculty>(_facultyDal.GetByIdDetail(id));
        }

        [CacheAspect(60)]
        public async Task<IDataResult<Faculty>> GetByIdDetailAsync(Guid id)
        {
            return new SuccessDataResult<Faculty>(await _facultyDal.GetByIdDetailAsync(id));
        }

        [CacheAspect(60)]
        public IDataResult<Faculty> GetSingle(Expression<Func<Faculty, bool>> predicate)
        {
            return new SuccessDataResult<Faculty>(_facultyDal.GetSingle(predicate));
        }

        [CacheAspect(60)]
        public async Task<IDataResult<Faculty>> GetSingleAsync(Expression<Func<Faculty, bool>> predicate)
        {
            return new SuccessDataResult<Faculty>(await _facultyDal.GetSingleAsync(predicate));
        }

        [CacheAspect(60)]
        public IDataResult<List<Faculty>> GetWhere(Expression<Func<Faculty, bool>> predicate)
        {
            return new SuccessDataResult<List<Faculty>>(_facultyDal.GetWhere(predicate));
        }

        [CacheAspect(60)]
        public async Task<IDataResult<List<Faculty>>> GetWhereAsync(Expression<Func<Faculty, bool>> predicate)
        {
            return new SuccessDataResult<List<Faculty>>(await _facultyDal.GetWhereAsync(predicate));
        }

        [CacheRemoveAspect
            ($"{nameof(IGenericService<Faculty>)}.{nameof(Get)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByDetail)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByDetailAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetById)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByIdAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetWhere)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetWhereAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetSingle)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetSingleAsync)}")]
        public IResult Update(Faculty faculty)
        {
            var result = CheckIfFacultyExists(faculty.FacultyId);
            if (!result.Success) return result;

            Faculty updatedFaculty = GetByIdDetail(faculty.FacultyId).Data;

            updatedFaculty.FacultyName = faculty.FacultyName;


            _facultyDal.Update(updatedFaculty);

            return new SuccessResult("Fakulte basariyla guncellendi");
        }

        [CacheRemoveAspect
            ($"{nameof(IGenericService<Faculty>)}.{nameof(Get)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByDetail)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByDetailAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetById)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetByIdAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetWhere)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetWhereAsync)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetSingle)}," +
            $"{nameof(IGenericService<Faculty>)}.{nameof(GetSingleAsync)}")]
        public async Task<IResult> UpdateAsync(Faculty faculty)
        {
            var result = CheckIfFacultyExists(faculty.FacultyId);
            if (!result.Success) return result;

            Faculty updatedFaculty = GetByIdDetail(faculty.FacultyId).Data;

            updatedFaculty.FacultyName = faculty.FacultyName;

            await _facultyDal.UpdateAsync(updatedFaculty);

            return new SuccessResult("Fakulte basariyla guncellendi");
        }
    }
}
