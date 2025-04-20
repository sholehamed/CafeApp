using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers.Specifications
{
    internal class MaterialPriceLogSpecifications : BaseSpecification<MaterialPriceLogEntity>
    {
        public MaterialPriceLogSpecifications AddFilters(Guid id, DatePeriodParameter? date)
        {
            SetFilterCondition(x => x.MaterialId == id);
            if (date is DatePeriodParameter dp)
            {
                if (dp.StartDate is DateTime dps)
                    SetFilterCondition(x => x.StartTime >= dps && x.EndTime <= dps);
                if (dp.StartDate is DateTime dpe)
                    SetFilterCondition(x => (x.StartTime <= dpe && !x.EndTime.HasValue) || (x.StartTime <= dpe && x.EndTime <= dpe));
            }
            return this;
        }
        public MaterialPriceLogSpecifications LastPrice(Guid id)
        {
            ApplyOrderByDescending(x=>x.Id);
            SetFilterCondition(x=>x.MaterialId == id);
            SetFilterCondition(x => !x.EndTime.HasValue);
            return this;
        }
    }
}
