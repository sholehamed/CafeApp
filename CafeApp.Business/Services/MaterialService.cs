using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Exceptions;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Services
{
    internal class MaterialService(IRepository<MaterialEntity> repository, IMapper mapper) : BaseService<MaterialEntity, MaterialDto,MaterialDetailModel>(repository, mapper), IMaterialService
    {
        public async Task<ICollection<PriceLogDto>> MaterialPriceLogs(Guid id, DatePeriodParameter date)
        {
            MaterialPriceLogSpecifications materialPriceLogSpecifications = new();
            materialPriceLogSpecifications.AddFilters(id, date);
            var res = _repository.DataUnit.MaterialPriceLogs.Get(materialPriceLogSpecifications)
                 .ProjectTo<PriceLogDto>(_mapper.ConfigurationProvider)
                 .ToList();
            return await Task.FromResult(res);
        }

        public async Task UpdatePrice(UpdateMaterialPriceParameter parameter)
        {
            await SetPrice(parameter);
            await UpdtePriceLog(parameter);
            await _repository.DataUnit.SaveChangesAsync();
        }

        private async Task SetPrice(UpdateMaterialPriceParameter parameter)
        {
            MaterialEntity entity = await _repository.GetByIdAsync(parameter.MaterialId) ?? throw new NotFoundException(nameof(AdditiveEntity), parameter.MaterialId);
            entity.UnitPrice=parameter.BuyPrice;
            entity.Update(Guid.Empty);
            await _repository.DataUnit.SaveChangesAsync();

        }
        private async Task UpdtePriceLog(UpdateMaterialPriceParameter parameter)
        {
            MaterialPriceLogEntity materialPrice = new(parameter.MaterialId, parameter.BuyPrice, parameter.SellPrice);
            MaterialPriceLogEntity? entity = _repository.DataUnit.MaterialPriceLogs.Get(x => x.MaterialId == parameter.MaterialId && x.EndTime == null).FirstOrDefault();
            entity!.PriceEnded();
            await _repository.DataUnit.MaterialPriceLogs.UpdateAsync(materialPrice);
            await _repository.DataUnit.MaterialPriceLogs.CreateAsync(materialPrice);
        }
    }
}
