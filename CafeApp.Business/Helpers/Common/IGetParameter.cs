using CafeApp.Domain.Common;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Helpers.Common
{
    public interface IGetParameter<TEntity> where TEntity : IEntityBase
    {
        ISpecifications<TEntity> GetSpecifications();
    }
}
