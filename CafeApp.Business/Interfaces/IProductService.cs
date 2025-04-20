using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Interfaces
{
    public interface IProductService:IBaseService<ProductEntity,ProductDto,ProductDetailModel>
    {
        Task UpdatePrice(UpdateProductPriceParameter parameter);
        Task<ICollection<PriceLogDto>> ProductPriceLogs(Guid Id, DatePeriodParameter date);
        Task UpdateOrder(UpdateProductsOrderCollection parameter);
    }
}
