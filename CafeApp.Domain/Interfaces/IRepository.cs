using CafeApp.Domain.Common;
using System.Linq.Expressions;

namespace CafeApp.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntityBase
    {
        IDataUnit DataUnit { get; }
        Task CreateRangeAsync(ICollection<TEntity> entities);
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task UpdateStateAsync(TEntity entity);
        //Task ExecuteUpdateAsync(Expression<Func<TEntity, bool>> expression, params (string, object?)[] parameter);
        Task DeleteAsync(Guid id,bool softDelete=true);

        Task<TEntity> GetByIdAsync(Guid id);
        IQueryable<TEntity> Get(ISpecifications<TEntity> specifications);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
        T GetLastValue<T>(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, T>> property);
        //Task ExecuteDeleteAsync(Expression<Func<TEntity, bool>> expression);
    }
}
