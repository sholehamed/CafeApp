using AutoMapper;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Services
{
    internal class UnitService(IRepository<UnitEntity> repository, IMapper mapper) : BaseService<UnitEntity, UnitDto, UnitDetailModel>(repository, mapper), IUnitService
    {
       
    }
}
