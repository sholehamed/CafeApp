using AutoMapper;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Services
{
    internal class FactorService(IRepository<InventoryFactorEntity> repository, IMapper mapper) : BaseService<InventoryFactorEntity, FactorDto>(repository, mapper), IFactorService
    {
       
    }
}
