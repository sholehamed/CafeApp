using AutoMapper;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Services
{
    internal class InventoryService(IRepository<InventoryEntity> repository, IMapper mapper) : BaseService<InventoryEntity, InventoryDto>(repository, mapper), IInventoryService
    {
    }
}
