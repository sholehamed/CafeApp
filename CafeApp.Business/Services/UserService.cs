using AutoMapper;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Services
{
    internal class UserService(IRepository<UserEntity> repository, IMapper mapper) : BaseService<UserEntity, UserDto>(repository, mapper), IUserService
    {
        public bool Login(string username, string password)
        {
            var user = _repository.Get(x => x.Username == username).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("کاربری یافت نشد");
            }
            if (user.Password != password)
                throw new Exception("نام کاربری و مرزعبور مطابقت ندارد");
            return true;

        }
    }
}
