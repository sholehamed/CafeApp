using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers.Specifications
{
    internal class TableSpecification :BaseSpecification<TableEntity>
    {
        private void FromParaemterMethod(ListTableParameter parameter)
        {
            if(parameter.IsActive is bool ia)
                SetFilterCondition(x=>x.IsActive==ia);
            if(!string.IsNullOrEmpty(parameter.Title))
                SetFilterCondition(x=>x.Title.Contains(parameter.Title));
            ApplyOrderBy(x => x.Number);
        }
        private void GetMethod(Guid id)
        {
            SetFilterCondition(x=>x.Id==id);
        }
        public static TableSpecification FromParameter(ListTableParameter listParameter)
        {
            TableSpecification tableSpecification = new TableSpecification();
            tableSpecification.FromParaemterMethod(listParameter);
            return tableSpecification;
        }
        public static TableSpecification Get(Guid id)
        {
            TableSpecification tableSpecification= new TableSpecification();
            tableSpecification.GetMethod(id);
            return tableSpecification;
        }


    }
}
