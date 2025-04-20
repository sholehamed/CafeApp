using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Interfaces
{
    public interface IMaterialService:IBaseService<MaterialEntity,MaterialDto,MaterialDetailModel>
    {
        Task UpdatePrice(UpdateMaterialPriceParameter parameter);
        Task<ICollection<PriceLogDto>> MaterialPriceLogs(Guid Id, DatePeriodParameter date);
    }
}
