using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers.Specifications
{
    internal class ProductPriceLogSpecifications : BaseSpecification<ProductPriceLogEntity>
    {
        public ProductPriceLogSpecifications AddFilters(Guid id, DatePeriodParameter? date)
        {
            SetFilterCondition(x => x.ProductId == id);
            if (date is DatePeriodParameter dp)
            {
                if (dp.StartDate is DateTime dps)
                    SetFilterCondition(x => x.StartTime >= dps && x.EndTime <= dps);
                if (dp.StartDate is DateTime dpe)
                    SetFilterCondition(x => (x.StartTime <= dpe && !x.EndTime.HasValue) || (x.StartTime <= dpe && x.EndTime <= dpe));
            }
            return this;
        }
        public ProductPriceLogSpecifications LastPrice(Guid id)
        {
            ApplyOrderByDescending(x=>x.Id);
            SetFilterCondition(x=>x.ProductId == id);
            SetFilterCondition(x => !x.EndTime.HasValue);
            return this;
        }
    }
}
