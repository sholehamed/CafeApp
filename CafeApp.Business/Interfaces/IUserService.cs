using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Interfaces
{
    public interface IUserService:IBaseService<UserEntity,UserDto>
    {
        bool Login(string username, string password);
    }
}
