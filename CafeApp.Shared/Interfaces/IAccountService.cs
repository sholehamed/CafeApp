using CafeApp.Business.Helpers.Dtos;

namespace CafeApp.Shared.Interfaces
{
    public interface IAccountService
    {
        UserDto User { get; }
        Task Initialize();
        Task Login(Login model);
        Task Logout();
        Task<UserDto> GetById(string id);
    }
}
