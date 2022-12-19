using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Core.Aspects.Autofac.Caching;
using StudentAttendanceSystem.Core.Utilities.Business;
using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

using System.Linq.Expressions;

namespace StudentAttendanceSystem.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        private readonly IFacultyService _facultyService;
        public DepartmentManager(IDepartmentDal departmentDal, IFacultyService facultyService)
        {
            _departmentDal = departmentDal;
            _facultyService = facultyService;
        }
        private IResult CheckIfDepartmentExists(Guid departmentId)
        {
            Department addedDepartment = GetById(departmentId).Data;
            if (addedDepartment == null)
                return new ErrorResult("Yazilan ID'ye bagli bir departman yok");
            
            return new SuccessResult();
        }
        public IResult CheckIfFacultyExists(Guid facultyId)
        {
            Faculty faculty = _facultyService.GetById(facultyId).Data;
            if (faculty == null)
                return new ErrorResult("Yazilan ID'ye bagli bir fakulte yok");

            return new SuccessResult();
        }
        private IResult CheckIfDepartmentNameIsNotAlreadyTaken(string departmentName)
        {
            var department = GetSingle(x => x.DepartmentName == departmentName).Data;
            if (department != null)
                return new ErrorResult("Bu isimde bir department zaten kayitlidir");
           
            return new SuccessResult();
        }

        [CacheRemoveAspect
            ($"{nameof(IGenericService<Department>)}.{nameof(Get)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByDetail)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByDetailAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetById)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByIdAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetWhere)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetWhereAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetSingle)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetSingleAsync)}")]
        public IResult Add(Department department)
        {
            var result = BusinessRules.Run(
                CheckIfDepartmentNameIsNotAlreadyTaken(department.DepartmentName),
                CheckIfFacultyExists(department.Faculty.FacultyId)
                );
            if (!result.Success) return result;

            _departmentDal.Add(department);

            return new SuccessResult("Departman basariyla eklendi");
        }
        [CacheRemoveAspect
            ($"{nameof(IGenericService<Department>)}.{nameof(Get)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByDetail)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByDetailAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetById)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByIdAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetWhere)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetWhereAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetSingle)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetSingleAsync)}")]
        public async Task<IResult> AddAsync(Department department)
        {
            var result = BusinessRules.Run(
                CheckIfDepartmentNameIsNotAlreadyTaken(department.DepartmentName),
                CheckIfFacultyExists(department.Faculty.FacultyId)
                );
            if (!result.Success) return result;

            await _departmentDal.AddAsync(department);

            return new SuccessResult("Departman basariyla eklendi");
        }
        [CacheRemoveAspect
            ($"{nameof(IGenericService<Department>)}.{nameof(Get)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByDetail)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByDetailAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetById)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByIdAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetWhere)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetWhereAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetSingle)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetSingleAsync)}")]
        public IResult Delete(Guid id)
        {
            var result = BusinessRules.Run(CheckIfDepartmentExists(id));
            if(!result.Success) return result;

            _departmentDal.Delete(GetById(id).Data);

            return new SuccessResult("Departman basariyla silindi");
        }

        [CacheRemoveAspect
            ($"{nameof(IGenericService<Department>)}.{nameof(Get)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByDetail)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByDetailAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetById)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByIdAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetWhere)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetWhereAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetSingle)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetSingleAsync)}")]
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var result = BusinessRules.Run(CheckIfDepartmentExists(id));
            if (!result.Success) return result;

            IDataResult<Department> departmentResult = await GetByIdAsync(id);
            await _departmentDal.DeleteAsync(departmentResult.Data);

            return new SuccessResult("Departman basariyla silindi");
        }

        [CacheAspect(60)]
        public IDataResult<List<Department>> Get()
        {
            return new SuccessDataResult<List<Department>>(_departmentDal.Get());
        }

        [CacheAspect(60)]
        public async Task<IDataResult<List<Department>>> GetAsync()
        {
            return new SuccessDataResult<List<Department>>(await _departmentDal.GetAsync());
        }

        [CacheAspect(60)]
        public IDataResult<List<Department>> GetByDetail()
        {
            return new SuccessDataResult<List<Department>>(_departmentDal.GetByDetail());
        }

        [CacheAspect(60)]
        public async Task<IDataResult<List<Department>>> GetByDetailAsync()
        {
            return new SuccessDataResult<List<Department>>(await _departmentDal.GetByDetailAsync());
        }

        [CacheAspect(60)]
        public IDataResult<Department> GetById(Guid id)
        {
            return new SuccessDataResult<Department>(_departmentDal.GetById(id));
        }

        [CacheAspect(60)]
        public async Task<IDataResult<Department>> GetByIdAsync(Guid id)
        {
            return new SuccessDataResult<Department>(await _departmentDal.GetByIdAsync(id));
        }

        [CacheAspect(60)]
        public IDataResult<Department> GetByIdDetail(Guid id)
        {
            return new SuccessDataResult<Department>(_departmentDal.GetByIdDetail(id));
        }

        [CacheAspect(60)]
        public async Task<IDataResult<Department>> GetByIdDetailAsync(Guid id)
        {
            return new SuccessDataResult<Department>(await _departmentDal.GetByIdDetailAsync(id));
        }

        [CacheAspect(60)]
        public IDataResult<Department> GetSingle(Expression<Func<Department, bool>> predicate)
        {
            return new SuccessDataResult<Department>(_departmentDal.GetSingle(predicate));
        }

        [CacheAspect(60)]
        public async Task<IDataResult<Department>> GetSingleAsync(Expression<Func<Department, bool>> predicate)
        {
            return new SuccessDataResult<Department>(await _departmentDal.GetSingleAsync(predicate));
        }

        [CacheAspect(60)]
        public IDataResult<List<Department>> GetWhere(Expression<Func<Department, bool>> predicate)
        {
            return new SuccessDataResult<List<Department>>(_departmentDal.GetWhere(predicate));
        }

        [CacheAspect(60)]
        public async Task<IDataResult<List<Department>>> GetWhereAsync(Expression<Func<Department, bool>> predicate)
        {
            return new SuccessDataResult<List<Department>>(await _departmentDal.GetWhereAsync(predicate));
        }

        [CacheRemoveAspect
            ($"{nameof(IGenericService<Department>)}.{nameof(Get)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByDetail)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByDetailAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetById)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByIdAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetWhere)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetWhereAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetSingle)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetSingleAsync)}")]
        public IResult Update(Department department)
        {
            var result = CheckIfDepartmentExists(department.DepartmentId);
            if (!result.Success) return result;

            _departmentDal.Update(department);

            return new SuccessResult("Departman basariyla guncellendi");
        }

        [CacheRemoveAspect
            ($"{nameof(IGenericService<Department>)}.{nameof(Get)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByDetail)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByDetailAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetById)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetByIdAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetWhere)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetWhereAsync)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetSingle)}," +
            $"{nameof(IGenericService<Department>)}.{nameof(GetSingleAsync)}")]
        public async Task<IResult> UpdateAsync(Department department)
        {
            var result = CheckIfDepartmentExists(department.DepartmentId);
            if (!result.Success) return result;

            await _departmentDal.UpdateAsync(department);

            return new SuccessResult("Departman basariyla guncellendi");
        }

    }
}
