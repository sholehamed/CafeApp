using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers.Specifications
{
    public class CustomerSpecifications : BaseSpecification<CustomerEntity>
    {
        private CustomerSpecifications AddFilters(ListCustomerParameter parameter)
        {
            if (!string.IsNullOrEmpty(parameter.FirstName))
                SetFilterCondition(x => !string.IsNullOrEmpty(x.FirstName) && x.FirstName.Contains(parameter.FirstName));
            if (!string.IsNullOrEmpty(parameter.LastName))
                SetFilterCondition(x => x.LastName.Contains(parameter.LastName));
            if (!string.IsNullOrEmpty(parameter.PhoneNumber))
                SetFilterCondition(x => !string.IsNullOrEmpty(x.PhoneNumber) && x.PhoneNumber.Contains(parameter.PhoneNumber));
            if (parameter.Gender.HasValue)
                SetFilterCondition(x =>(byte) x.Gender == parameter.Gender.Value);
            if (parameter.Birthday.HasValue)
                SetFilterCondition(x => x.Birthday == parameter.Birthday.Value);
            return this;
        }

        public static CustomerSpecifications FromParameter(ListCustomerParameter parameter)
        {
            CustomerSpecifications customerSpecifications = new CustomerSpecifications();
            customerSpecifications.AddFilters(parameter);
            return customerSpecifications;
        }
    }
}
