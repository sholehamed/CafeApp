using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers.Specifications
{
    public class InventorySpecifications:BaseSpecification<InventoryEntity>
    {

        public static InventorySpecifications Get(GetInventoryParameter parameter)
        {
            InventorySpecifications specifications = new InventorySpecifications();
            specifications.SetFilterCondition(x=> x.Id == parameter.Id);
            return specifications;
        }

        public InventorySpecifications AddFilters(ListInventoryParameter parameter)
        {
            if(!string.IsNullOrEmpty(parameter.Title))
                SetFilterCondition(x=>x.Title.Contains(parameter.Title));
          
            if(parameter.IsActive.HasValue )
                SetFilterCondition(x=>x.IsActive==parameter.IsActive.Value);
            return this;
        }
    }
}
