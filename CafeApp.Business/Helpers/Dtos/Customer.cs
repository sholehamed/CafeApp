using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Helpers.Dtos
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public byte Gender { get; set; }
        public string GenderStr { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string? BirthdayStr { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        public CustomerDto()
        {

        }

    }
    public class CreateCustomerParameter
    {
        public int Code { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public byte Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
    }
    public class UpdateCustomerParameter:CreateCustomerParameter
    {
        public Guid Id { get; set; }
    }

    public class GetCategoryParameter : IGetParameter<ProductCategoryEntity>
    {
        public Guid Id { get; set; }

        public GetCategoryParameter(Guid id)
        {
            Id = id;
        }

        public ISpecifications<ProductCategoryEntity> GetSpecifications()
        {
            return ProductCategorySpecifications.Get(this);
        }
    }
    public class ListCustomerParameter : PagingParameter, IGetParameter<CustomerEntity>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }

        public ISpecifications<CustomerEntity> GetSpecifications()
        {
            return CustomerSpecifications.FromParameter(this);
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
            if (Birthday is DateTime bd)
                _parameter += $"Birthday={Birthday}";
            return _parameter;
        }
    }
}
