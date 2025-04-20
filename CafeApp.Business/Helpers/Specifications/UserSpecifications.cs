using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers.Specifications
{
    internal class UserSpecifications : BaseSpecification<UserEntity>
    {
        public static UserSpecifications GetByUsername(string username)
        {
            UserSpecifications specifications = new UserSpecifications();
            specifications.SetFilterCondition(x=>x.Username == username);
            return specifications;
        }
        private void FromParameterMethod(ListUserParameter parameter)
        {
            if (!string.IsNullOrEmpty(parameter.FirstName))
                SetFilterCondition(x => x.FirstName.Contains(parameter.FirstName));
            if (!string.IsNullOrEmpty(parameter.LastName))
                SetFilterCondition(x => x.FirstName.Contains(parameter.LastName));
            if (!string.IsNullOrEmpty(parameter.Username))
                SetFilterCondition(x => x.FirstName.Contains(parameter.Username));
            if (parameter.Gender is byte g)
                SetFilterCondition(x => (byte)x.Gender==g);
            if (parameter.IsActive is bool ia)
                SetFilterCondition(x => x.IsActive);
            if (!string.IsNullOrEmpty(parameter.Email))
                SetFilterCondition(x => x.Email!.Contains(parameter.Email));
        }
        private void GetMethod(Guid id)
        {
            SetFilterCondition(x => x.Id == id);
            AddInclude(nameof(UnitEntity.Parent));
        }
        public static UserSpecifications FromParameter(ListUserParameter listParameter)
        {
            UserSpecifications specs = new UserSpecifications();
            specs.FromParameterMethod(listParameter);
            return specs;
        }
        public static UserSpecifications Get(GetUserParameter parameter)
        {
            UserSpecifications specs = new UserSpecifications();
            specs.GetMethod(parameter.Id);
            return specs;
        }


    }
}
