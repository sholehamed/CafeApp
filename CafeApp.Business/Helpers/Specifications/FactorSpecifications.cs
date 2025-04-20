using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers.Specifications
{
    public class FactorSpecifications:BaseSpecification<InventoryFactorEntity>
    {
        public FactorSpecifications AddFilters(ListFactorParameter parameter)
        {
            if(parameter.InventoryId is Guid ii)
                SetFilterCondition(x=>x.InventoryId==ii);
            if (parameter.UserId is Guid ui)
                SetFilterCondition(x => x.UserId == ui);
            if (!string.IsNullOrEmpty(parameter.Number) )
                SetFilterCondition(x=>x.Number.Contains(parameter.Number));
            return this;
        }
        public FactorSpecifications AddIncludes()
        {
            AddInclude(nameof(InventoryFactorEntity.Items));
            return this;
        }
    }
}
