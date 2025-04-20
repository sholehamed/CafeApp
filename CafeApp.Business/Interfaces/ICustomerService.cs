using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Interfaces
{
    public interface ICustomerService:IBaseService<CustomerEntity,CustomerDto>
    {
    }
}
