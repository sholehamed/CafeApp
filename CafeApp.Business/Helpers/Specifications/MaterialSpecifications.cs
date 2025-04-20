using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers.Specifications
{
    public class MaterialSpecifications:BaseSpecification<MaterialEntity>
    {
        public MaterialSpecifications AddFilters(ListMaterialParameter parameter)
        {
            if(!string.IsNullOrEmpty(parameter.Title))
                SetFilterCondition(x=>x.Title.Contains(parameter.Title));
            if(parameter.UnitId is Guid ui)
                SetFilterCondition(x=>x.UnitId==ui);
            return this;
        }
        public static MaterialSpecifications Get(GetMaterialParameter parameter)
        {
            MaterialSpecifications specs = new MaterialSpecifications();
            specs.SetFilterCondition(x=>x.Id==parameter.Id);
            specs.AddIncludes();
            return specs;
        }
        public MaterialSpecifications AddIncludes()
        {
            AddInclude(nameof(MaterialEntity.Unit));
            return this;
        }
    }
}
