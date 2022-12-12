using StudentAttendanceSystem.Business.Abstract;
using StudentAttendanceSystem.Core.Aspects.Autofac.Caching;
using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.DataAccess.Abstract;
using StudentAttendanceSystem.Entities.Concrete;

using System.Linq.Expressions;

namespace StudentAttendanceSystem.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }
        public IResult CheckIfDepartmentExists(Guid departmentId)
        {
            Department addedDepartment = GetById(departmentId).Data;
            if (addedDepartment == null)
            {
                return new ErrorResult("Yazilan ID'ye bagli bir department yok");
            }

            return new SuccessResult();
        }
        private IResult CheckIfDepartmentNameIsNotAlreadyTaken(string departmentName)
        {
            var department = GetSingle(x => x.DepartmentName == departmentName).Data;
            if (department != null)
            {
                return new ErrorResult("Bu isimde bir department zaten kayitlidir");
            }
            return new SuccessResult();
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
        public IResult Add(Department department)
        {
            _departmentDal.Add(department);

            return new SuccessResult("Department basariyla eklendi");
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
        public async Task<IResult> AddAsync(Department department)
        {
            await _departmentDal.AddAsync(department);

            return new SuccessResult("Department basariyla eklendi");
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
        public IResult Delete(Guid id)
        {
            _departmentDal.Delete(GetById(id).Data);

            return new SuccessResult("Department basariyla silindi");
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
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var department = await GetByIdAsync(id);
            await _departmentDal.DeleteAsync(department.Data);

            return new SuccessResult("Department basariyla silindi");
        }

        [CacheAspect(10)]
        public IDataResult<List<Department>> Get()
        {
            return new SuccessDataResult<List<Department>>(_departmentDal.Get());
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<Department>>> GetAsync()
        {
            return new SuccessDataResult<List<Department>>(await _departmentDal.GetAsync());
        }

        [CacheAspect(10)]
        public IDataResult<List<Department>> GetByDetail()
        {
            return new SuccessDataResult<List<Department>>(_departmentDal.GetByDetail());
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<Department>>> GetByDetailAsync()
        {
            return new SuccessDataResult<List<Department>>(await _departmentDal.GetByDetailAsync());
        }

        [CacheAspect(10)]
        public IDataResult<Department> GetById(Guid id)
        {
            return new SuccessDataResult<Department>(_departmentDal.GetById(id));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<Department>> GetByIdAsync(Guid id)
        {
            return new SuccessDataResult<Department>(await _departmentDal.GetByIdAsync(id));
        }

        [CacheAspect(10)]
        public IDataResult<Department> GetByIdDetail(Guid id)
        {
            return new SuccessDataResult<Department>(_departmentDal.GetByIdDetail(id));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<Department>> GetByIdDetailAsync(Guid id)
        {
            return new SuccessDataResult<Department>(await _departmentDal.GetByIdDetailAsync(id));
        }

        [CacheAspect(10)]
        public IDataResult<Department> GetSingle(Expression<Func<Department, bool>> predicate)
        {
            return new SuccessDataResult<Department>(_departmentDal.GetSingle(predicate));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<Department>> GetSingleAsync(Expression<Func<Department, bool>> predicate)
        {
            return new SuccessDataResult<Department>(await _departmentDal.GetSingleAsync(predicate));
        }

        [CacheAspect(10)]
        public IDataResult<List<Department>> GetWhere(Expression<Func<Department, bool>> predicate)
        {
            return new SuccessDataResult<List<Department>>(_departmentDal.GetWhere(predicate));
        }

        [CacheAspect(10)]
        public async Task<IDataResult<List<Department>>> GetWhereAsync(Expression<Func<Department, bool>> predicate)
        {
            return new SuccessDataResult<List<Department>>(await _departmentDal.GetWhereAsync(predicate));
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
        public IResult Update(Department department)
        {
            var result = CheckIfDepartmentExists(department.DepartmentId);
            if (!result.Success) return result;

            Department updatedDepartment = GetByIdDetail(department.DepartmentId).Data;

            updatedDepartment.DepartmentName = department.DepartmentName;
            updatedDepartment.Lectures = department.Lectures;
            updatedDepartment.Faculty = department.Faculty;

            _departmentDal.Update(updatedDepartment);

            return new SuccessResult("Department basariyla guncellendi");
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
        public async Task<IResult> UpdateAsync(Department department)
        {
            var result = CheckIfDepartmentExists(department.DepartmentId);
            if (!result.Success) return result;

            Department updatedDepartment = GetByIdDetail(department.DepartmentId).Data;

            updatedDepartment.DepartmentName = department.DepartmentName;
            updatedDepartment.Lectures = department.Lectures;
            updatedDepartment.Faculty = department.Faculty;

            await _departmentDal.UpdateAsync(updatedDepartment);

            return new SuccessResult("Department basariyla guncellendi");
        }

    }
}
