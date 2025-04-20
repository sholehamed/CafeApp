using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Services
{
    internal class ProductService(IRepository<ProductEntity> repository, IMapper mapper) : BaseService<ProductEntity, ProductDto, ProductDetailModel>(repository, mapper), IProductService
    {
        public override async Task CreateAsync<TParameter>(TParameter parameter)
        {
            if (parameter is CreateProductParameter p)
            {
                ProductEntity entity = _mapper.Map<ProductEntity>(p);
                if (p.Materials is ICollection<CreateProductMaterialParameter> m)
                {
                    var materials = p.Materials.Select(x => new ProductMaterialEntity(entity,x.UnitId, x.MaterialId, x.Amount)).ToList();
                    entity.SetMaterials(materials);
                }
                if (p.Additives is ICollection<Guid> a)
                {
                    var additives = p.Additives.Select(x => new ProductAdditiveEntity(entity, x)).ToList();
                    entity.SetAdditives(additives);
                }
                await SetPrice(entity);
                await _repository.CreateAsync(entity);
                await _repository.DataUnit.SaveChangesAsync();
            }

        }
        private async Task SetPrice(ProductEntity productEntity)
        {
            await _repository.DataUnit.ProductPriceLogs.CreateAsync(new ProductPriceLogEntity(productEntity, productEntity.Price));
        }
        public async Task<ICollection<PriceLogDto>> ProductPriceLogs(Guid id, DatePeriodParameter date)
        {
            ProductPriceLogSpecifications productPriceLogSpecifications = new();
            productPriceLogSpecifications.AddFilters(id, date);
            var res = _repository.DataUnit.ProductPriceLogs.Get(productPriceLogSpecifications)
                 .ProjectTo<PriceLogDto>(_mapper.ConfigurationProvider)
                 .ToList();
            return await Task.FromResult(res);
        }

        public override async Task UpdateAsync<TParameter>(TParameter parameter)
        {
            try
            {
                if (parameter is UpdateProductParameter updateProductParameter)
                {
                    ProductEntity entity = _mapper.Map<ProductEntity>(parameter);
                    if (updateProductParameter.Materials is ICollection<CreateProductMaterialParameter> m)
                    {
                        ICollection<ProductMaterialEntity> productMaterials = _repository.DataUnit.ProductMaterials.Get(x => x.ProductId == entity.Id).ToList();
                        foreach (ProductMaterialEntity material in productMaterials)
                        {
                            await _repository.DataUnit.ProductMaterials.DeleteAsync(material.Id);
                        }
                        var materials = updateProductParameter.Materials.Select(x => new ProductMaterialEntity(entity.Id, x.MaterialId, x.Amount)).ToList();
                        await _repository.DataUnit.ProductMaterials.CreateRangeAsync(materials);

                    }
                    if (updateProductParameter.Additives is ICollection<int> a)
                    {
                        ICollection<ProductAdditiveEntity> productAdditives = _repository.DataUnit.ProductAdditives.Get(x => x.ProductId == entity.Id).ToList();
                        foreach (ProductAdditiveEntity additive in productAdditives)
                        {
                            await _repository.DataUnit.ProductAdditives.DeleteAsync(additive.Id);
                        }
                        var additives = updateProductParameter.Additives.Select(x => new ProductAdditiveEntity(entity.Id, x)).ToList();
                        await _repository.DataUnit.ProductAdditives.CreateRangeAsync(additives);
                    }


                    ProductEntity product = await _repository.GetByIdAsync(updateProductParameter.Id);
                    if (product.Price != updateProductParameter.Price)
                        await UpdatePrice(new UpdateProductPriceParameter(product.Id, updateProductParameter.Price));

                    await _repository.DataUnit.SaveChangesAsync();

                    await _repository.UpdateAsync(entity);
                    await _repository.DataUnit.SaveChangesAsync();

                }
            }
            catch (Exception e)
            {

                throw e;
            }
            

        }

        public async Task UpdatePrice(UpdateProductPriceParameter parameter)
        {
            ProductPriceLogEntity productPriceLogEntity = new(parameter.GetId(), parameter.Price);
            await _repository.DataUnit.ProductPriceLogs.CreateAsync(productPriceLogEntity);
            ProductPriceLogSpecifications productPriceLogSpecifications = new();
            productPriceLogSpecifications.LastPrice(parameter.GetId());

            var lastPrice = _repository.DataUnit.ProductPriceLogs.Get(productPriceLogSpecifications).FirstOrDefault();
            if (lastPrice is ProductPriceLogEntity ppl)
            {
                ppl.PriceEnded();
                await _repository.DataUnit.ProductPriceLogs.UpdateAsync(ppl);
            }
            ProductEntity productEntity = await _repository.GetByIdAsync(parameter.GetId());
            productEntity.UpdatePrice(parameter.Price);
            productEntity.Update(Guid.Empty);
            await _repository.UpdateAsync(productEntity);

        }

        public async Task UpdateOrder(UpdateProductsOrderCollection parameters)
        {
            foreach (var item in parameters.Items)
            {
                ProductEntity product = await _repository.GetByIdAsync(item.ProductId);
                product.ChangeOrder(item.Order);
                product.Update(Guid.Empty);
                await _repository.UpdateAsync(product);
            }
            await _repository.DataUnit.SaveChangesAsync();
        }


    }
}
