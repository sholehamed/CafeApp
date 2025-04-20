using AutoMapper;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Services
{
    internal class CustomerService(IRepository<CustomerEntity> repository, IMapper mapper) : BaseService<CustomerEntity, CustomerDto>(repository, mapper), ICustomerService
    {
        public override async Task CreateAsync<TParameter>(TParameter parameter)
        {
            if (parameter is CreateCustomerParameter p)
            {
                int? code = _repository.GetLastValue(x => x.IsActive == true, x => x.Code);
                if (code == null)
                    code = 0;
                p.Code = code.Value + 1;
                await base.CreateAsync(p);
            }
            await Task.CompletedTask;
        }
    }
}
