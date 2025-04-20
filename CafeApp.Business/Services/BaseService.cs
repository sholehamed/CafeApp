using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Common;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Services
{
    internal class BaseService<TEntity, TDto, TDetailedDto>(IRepository<TEntity> repository, IMapper mapper) : IBaseService<TEntity, TDto, TDetailedDto> where TDto : class where TEntity : IEntityBase where TDetailedDto : class
    {
        protected readonly IRepository<TEntity> _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        protected readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task Apply()
        {
            await _repository.DataUnit.SaveChangesAsync();
        }

        public virtual async Task CreateAsync<TParameter>(TParameter parameter)
        {
            try
            {

                TEntity entity = _mapper.Map<TParameter, TEntity>(parameter);
                await _repository.CreateAsync(entity);
                await _repository.DataUnit.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual async Task DeleteAsync(Guid id, bool softdelete = true)
        {
            await _repository.DeleteAsync(id,softdelete);
            await _repository.DataUnit.SaveChangesAsync();
        }

        public virtual async Task<List<TDto>> GetAll(ISpecifications<TEntity> specifications)
        {
            List<TDto> dtos = _repository.Get(specifications).ProjectTo<TDto>(_mapper.ConfigurationProvider).ToList();
            return await Task.FromResult(dtos);
        }

        public async Task<ICollection<TEntity>> GetAllForSync(string[]? includes)
        {
            BaseSpecification<TEntity> specifications = new BaseSpecification<TEntity>();
            if (includes is string[])
                foreach (var item in includes)
                {
                    specifications.AddInclude(item);
                }
            ICollection<TEntity> entities = _repository.Get(specifications).ToList();
            return await Task.FromResult(entities);
        }

        public virtual TDetailedDto GetBy(ISpecifications<TEntity> specifications)
        {
            TEntity? entity = _repository.Get(specifications).FirstOrDefault();
            return _mapper.Map<TEntity, TDetailedDto>(entity);
        }

        public async Task<TDetailedDto> GetById(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDetailedDto>(entity);
        }

        public virtual async Task<PagedList<TDto>> GetPaged(ISpecifications<TEntity> specifications, PagingParameter pagingParameter)
        {

                var queryable = _repository.Get(specifications);
            int count = queryable.Count();

            var collection = queryable.Skip((pagingParameter.Page - 1) * pagingParameter.PageSize).Take(pagingParameter.PageSize).ProjectTo<TDto>(_mapper.ConfigurationProvider).ToList();
            PagedList<TDto> result = new(collection, count);
            return await Task.FromResult(result);
        }

        public virtual async Task UpdateAsync<TParameter>(TParameter parameter)
        {
            try
            {

                TEntity entity = _mapper.Map<TParameter, TEntity>(parameter);
                await _repository.UpdateAsync(entity);
                await _repository.DataUnit.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task WriteSync(TEntity entity)
        {
            var t = _repository.Get(x => x.IsDeleted == false).ToList();
            TEntity? existed =  _repository.Get(x=>x.Id==entity.Id).FirstOrDefault();
            if (existed is TEntity)
                await _repository.UpdateAsync(entity);
            else
                await _repository.CreateAsync(entity);
        }
    }
    internal class BaseService<TEntity, TDto>(IRepository<TEntity> repository, IMapper mapper) : BaseService<TEntity, TDto, TDto>(repository, mapper), IBaseService<TEntity, TDto> where TDto : class where TEntity : EntityBase
    {
    }
}
