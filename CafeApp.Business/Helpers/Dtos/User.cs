using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CafeApp.Business.Helpers.Dtos
{
    public class Login
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public byte Gender { get; set; }
        public string GenderStr { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string? BirthdayStr { get; set; }

        public string Username { get; set; }
        public string? Image { get; set; }
        public bool IsActive { get; set; }
        public string? Address { get; set; }
        public string Token { get; set; }
        public UserDto()
        {

        }
    }
    public class CreateUserRoleParameter
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
    public class CreateUserParameter
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public byte Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Image { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CreateUserRoleParameter>? Roles { get; set; }
        public CreateUserParameter()
        {

        }
    }
    public class UpdateUserParameter:CreateUserParameter
    {
        public Guid Id { get; set; }
       
        public UpdateUserParameter()
        {

        }
    }

    public class GetUserParameter : IGetParameter<UserEntity>
    {
        public Guid Id { get; set; }

        public GetUserParameter(Guid id)
        {
            Id = id;
        }

        public ISpecifications<UserEntity> GetSpecifications()
        {
            return UserSpecifications.Get(this);
        }
    }
    public class ListUserParameter : PagingParameter, IGetParameter<UserEntity>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }

        public ISpecifications<UserEntity> GetSpecifications()
        {
            return UserSpecifications.FromParameter(this);
        }
        public override string ToString()
        {
            string _parameter = $"Page={Page}&PageSize={PageSize}";
            if (!string.IsNullOrEmpty(FirstName))
                _parameter += $"FirstName={FirstName}";
            if (!string.IsNullOrEmpty(LastName))
                _parameter += $"LastName={LastName}";
            if (Gender is byte g)
                _parameter += $"Gender={g}";
            if (!string.IsNullOrEmpty(PhoneNumber))
                _parameter += $"PhonenUmber={PhoneNumber}";
            if (!string.IsNullOrEmpty(Email))
                _parameter += $"Email={Email}";
            return _parameter;
        }
    }
}
