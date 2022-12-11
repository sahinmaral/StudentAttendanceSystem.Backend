using StudentAttendanceSystem.Core.Entities.Abstract;
using StudentAttendanceSystem.Core.Utilities.Results;
using StudentAttendanceSystem.Entities.Concrete;
using StudentAttendanceSystem.Entities.DTOs;

using System.Linq.Expressions;

namespace StudentAttendanceSystem.Business.Abstract
{
    public interface IGenericService<T> where T: class,IEntity,new()
    {
        IDataResult<List<T>> Get();
        Task<IDataResult<List<T>>> GetAsync();
        IDataResult<List<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task<IDataResult<List<T>>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        IDataResult<T> GetSingle(Expression<Func<T, bool>> predicate);
        Task<IDataResult<T>> GetSingleAsync(Expression<Func<T, bool>> predicate);
        IDataResult<T> GetById(Guid id);
        Task<IDataResult<T>> GetByIdAsync(Guid id);
        IResult Delete(Guid id);
        Task<IResult> DeleteAsync(Guid id);
    }
}
