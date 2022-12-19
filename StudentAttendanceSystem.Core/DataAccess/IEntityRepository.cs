using Microsoft.EntityFrameworkCore.Storage;

using StudentAttendanceSystem.Core.Entities.Abstract;

using System.Linq.Expressions;

namespace StudentAttendanceSystem.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> Get();
        Task<List<T>> GetAsync();
        List<T> GetWhere(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
        List<T> GetByDetail();
        Task<List<T>> GetByDetailAsync();
        T GetByIdDetail(Guid id);
        Task<T> GetByIdDetailAsync(Guid id);

    }
}
