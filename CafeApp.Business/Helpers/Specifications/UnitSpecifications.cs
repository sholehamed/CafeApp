using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers.Specifications
{
    internal class UnitSpecifications :BaseSpecification<UnitEntity>
    {
        private void FromParaemterMethod(ListUnitParameter parameter)
        {
            if(parameter.IsActive is bool ia)
                SetFilterCondition(x=>x.IsActive==ia);
            if (parameter.ParentId is Guid pi)
                SetFilterCondition(x => x.ParentId == pi);
            if (!string.IsNullOrEmpty(parameter.Title))
                SetFilterCondition(x=>x.Title.Contains(parameter.Title));

        }
        private void GetMethod(Guid id)
        {
            SetFilterCondition(x=>x.Id==id);
            AddInclude(nameof(UnitEntity.Parent));
        }
        public static UnitSpecifications FromParameter(ListUnitParameter listParameter)
        {
            UnitSpecifications specs = new UnitSpecifications();
            specs.FromParaemterMethod(listParameter);
            return specs;
        }
        public static UnitSpecifications Get(Guid id)
        {
            UnitSpecifications specs = new UnitSpecifications();
            specs.GetMethod(id);
            return specs;
        }


    }
}
