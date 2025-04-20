using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Exceptions;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Services
{
    internal class AdditiveService(IRepository<AdditiveEntity> repository, IMapper mapper) : BaseService<AdditiveEntity, AdditiveDto,AdditiveDetailModel>(repository, mapper), IAdditiveService
    {
        public async Task<ICollection<PriceLogDto>> AdditivePriceLogs(Guid id, DatePeriodParameter date)
        {
            AdditivePriceLogSpecifications additivePriceLogSpecifications = new();
            additivePriceLogSpecifications.AddFilters(id, date);
            var res = _repository.DataUnit.AdditivePriceLogs.Get(additivePriceLogSpecifications)
                 .ProjectTo<PriceLogDto>(_mapper.ConfigurationProvider)
                 .ToList();
            return await Task.FromResult(res);
        }

        public async Task UpdatePrice(UpdateAdditivePriceParameter parameter)
        {
            await SetPrice(parameter);
            await UpdtePriceLog(parameter.AdditiveId, parameter.Price);
            await _repository.DataUnit.SaveChangesAsync();
        }

        private async Task SetPrice(UpdateAdditivePriceParameter parameter)
        {
            AdditiveEntity entity = await _repository.GetByIdAsync(parameter.AdditiveId) ?? throw new NotFoundException(nameof(AdditiveEntity), parameter.AdditiveId);
            entity.Price=parameter.Price;
            entity.Update(Guid.Empty);
            await _repository.UpdateAsync(entity);
        }
        private async Task UpdtePriceLog(Guid additiveId, long price)
        {
            AdditivePriceLogEntity additivePrice = new(additiveId, price, DateTime.Now);
            AdditivePriceLogEntity? entity = _repository.DataUnit.AdditivePriceLogs.Get(x => x.AdditiveId == additiveId && x.EndTime == null).FirstOrDefault();
            entity!.PriceEnded();
            entity.Update(Guid.Empty);
            await _repository.DataUnit.AdditivePriceLogs.UpdateAsync(entity);
            await _repository.DataUnit.AdditivePriceLogs.CreateAsync(additivePrice);
        }
    }
}
