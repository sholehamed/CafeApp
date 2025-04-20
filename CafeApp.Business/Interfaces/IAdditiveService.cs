using CafeApp.Business.Interfaces;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers.Dtos
{
    public interface IAdditiveService:IBaseService<AdditiveEntity,AdditiveDto,AdditiveDetailModel>
    {
        Task UpdatePrice(UpdateAdditivePriceParameter parameter);
        Task<ICollection<PriceLogDto>> AdditivePriceLogs(Guid    Id, DatePeriodParameter date);
    }
}
