using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Services
{
    internal class ProductCategoryService(IRepository<ProductCategoryEntity> repository, IMapper mapper) : BaseService<ProductCategoryEntity, ProductCategoryDto>(repository, mapper), IProductCategoryService
    {
        public async Task UpdateOrder(UpdateCategoryOrderParameterCollection parameters)
        {
            foreach (var item in parameters.Items)
            {
                ProductCategoryEntity productCategory =await _repository.GetByIdAsync(item.CategoryId);
                productCategory.Order=item.Order;
                productCategory.Update(Guid.Empty);
                await _repository.UpdateAsync(productCategory);
            }
            await _repository.DataUnit.SaveChangesAsync();
        }

        async Task<ICollection<ProductDto>> IProductCategoryService.GetProducts(Guid id)
        {
            return await Task.FromResult(_repository.DataUnit.Products.Get(x => x.CategoryId == id).ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToList());
        }

        async Task<ICollection<MenuCategoryModel>> IProductCategoryService.GetMenu()
        {
            try
            {

            ProductCategorySpecifications productCategorySpecifications =new ProductCategorySpecifications();
            productCategorySpecifications
                .AddFilter(x=>x.IsActive)
                .IncludeProduct();
            var res= _repository.Get(productCategorySpecifications).OrderBy(x=>x.Order).ProjectTo<MenuCategoryModel>(_mapper.ConfigurationProvider).ToList();
            
                return await Task.FromResult(res);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<ICollection<DashboardCategoryModel>> GetForDashboard()
        {
            var res= _repository.Get(ProductCategorySpecifications.GetForDashboard()).ProjectTo<DashboardCategoryModel>(_mapper.ConfigurationProvider).ToList();
            return await Task.FromResult(res);
        }
    }
}
