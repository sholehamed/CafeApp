using CafeApp.Business.Helpers.Common;
using CafeApp.Domain.Common;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Interfaces
{

    public interface IBaseService<TEntity, TDto, TDetailedDto> where TDto : class where TEntity : IEntityBase
    {
        Task CreateAsync<TParameter>(TParameter parameters);
        Task UpdateAsync<TParameter>(TParameter parameters);
        Task DeleteAsync(Guid id,bool softdelete=true);
        Task<TDetailedDto> GetById(Guid id);
        Task<List<TDto>> GetAll(ISpecifications<TEntity> parameters);
        TDetailedDto GetBy(ISpecifications<TEntity> parameters);
        Task<PagedList<TDto>> GetPaged(ISpecifications<TEntity> parameters, PagingParameter pagingParameter);
        Task<ICollection<TEntity>> GetAllForSync(string[]? includes=null);
        Task WriteSync(TEntity entity);
        Task Apply();
    }

    public interface IBaseService<TEntity, TDto> : IBaseService<TEntity, TDto, TDto> where TDto : class where TEntity : EntityBase
    {

    }

}
