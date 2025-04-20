using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Helpers.Dtos
{
    public class MaterialDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public Guid UnitId { get; set; }
        public string UnitPrice { get; set; }
        public bool IsActive { get; set; }
    }
    public class MaterialSelectModel
    {
        public MaterialSelectModel()
        {
            
        }
        public MaterialSelectModel(Guid id, string title,Guid unitId, string unit, long value)
        {
            Id = id;
            Title = title;
            Unit = unit;
            Amount = value;
            UnitId = unitId;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public Guid UnitId { get; set; }
        public long Amount { get; set; }


    }
    public class MaterialDetailModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid UnitId { get; set; }
        public long UnitPrice { get; set; }
        public bool IsActive { get; set; }
    }
    public class CreateMaterialParameter
    {
        public string Title { get; set; }
        public Guid UnitId { get; set; }
        public long UnitPrice { get; set; }
        public bool IsActive { get; set; }
    }
    public class UpdateMaterialParameter
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid UnitId { get; set; }
        public long UnitPrice { get; set; }
        public bool IsActive { get; set; }
    }
    public class GetMaterialParameter:IGetParameter<MaterialEntity>
    {
        public Guid Id { get; set; }

        public GetMaterialParameter(Guid id)
        {
            Id = id;
        }

        public ISpecifications<MaterialEntity> GetSpecifications()
        {
            return MaterialSpecifications.Get(this);
            
        }
    }
    public class ListMaterialParameter : PagingParameter,IGetParameter<MaterialEntity>
    {
        public string? Title { get; set; }
        public Guid? UnitId { get; set; }
        public bool? IsActive { get; set; }

        public ISpecifications<MaterialEntity> GetSpecifications()
        {
            MaterialSpecifications materialSpecifications = new MaterialSpecifications();
            materialSpecifications.AddFilters(this);
            return materialSpecifications;
        }

        public override string ToString()
        {
            string? route = string.Empty;
            if (!string.IsNullOrEmpty(Title))
                route = string.Format(string.Format("{0}={1}",nameof(Title),Title));
            if (IsActive.HasValue)
                route = route + "&" + string.Format("{0}={1}", nameof(IsActive), IsActive);
            if (UnitId.HasValue)
                route = route + "&" + string.Format("{0}={1}", nameof(UnitId), UnitId);
            return route + base.ToString();
        }
    }

    public class UpdateMaterialPriceParameter
    {
        public Guid MaterialId { get; set; }
        public long BuyPrice { get; set; }
        public long SellPrice { get; set; }
    }

}
