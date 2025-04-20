using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers.Specifications
{
    public class AdditiveSpecifications : BaseSpecification<AdditiveEntity>
    {
        public static AdditiveSpecifications Get(GetAdditiveParameter parameter)
        {
            AdditiveSpecifications specs = new AdditiveSpecifications();
            specs.SetFilterCondition(x=>x.Id == parameter.Id);
            return specs;
        }

        public AdditiveSpecifications AddFilter(ListAdditiveParameter parameter)
        {
            if (!string.IsNullOrEmpty(parameter.Title))
                SetFilterCondition(x => x.Title.Contains(parameter.Title));
            if (parameter.IsActive.HasValue)
                SetFilterCondition(x => x.IsActive == parameter.IsActive);

            return this;
        }
        public AdditiveSpecifications AddIncludes()
        {
            AddInclude(nameof(AdditiveEntity.Material));
            return this;
        }
    }
}
