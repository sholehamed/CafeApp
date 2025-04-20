using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Interfaces
{
    public interface IProductCategoryService:IBaseService<ProductCategoryEntity,ProductCategoryDto>
    {
        Task UpdateOrder(UpdateCategoryOrderParameterCollection parameters);
        Task<ICollection<ProductDto>> GetProducts(Guid id);
        Task<ICollection<MenuCategoryModel>> GetMenu();
        Task<ICollection<DashboardCategoryModel>> GetForDashboard();
    }
}
