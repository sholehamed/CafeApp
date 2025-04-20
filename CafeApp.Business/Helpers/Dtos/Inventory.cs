using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Domain.Common;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Helpers.Dtos
{
    public class InventoryDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public InventoryDto()
        {
            
        }
    }
    public class CreateInventoryParameter
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public CreateInventoryParameter()
        {
            
        }
    }
    public class UpdateInventoryParameter
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetInventoryParameter : IGetParameter<InventoryEntity>
    {
        public Guid Id { get; set; }

        public GetInventoryParameter(Guid id)
        {
            Id = id;
        }

        public ISpecifications<InventoryEntity> GetSpecifications()
        {
            return InventorySpecifications.Get(this);
        }
    }

    public class ListInventoryParameter:PagingParameter,IGetParameter<InventoryEntity>
    {
        public string? Title { get; set; }
        public bool? IsActive { get; set; }

        public ISpecifications<InventoryEntity> GetSpecifications()
        {
            var inventorySpecifications = new InventorySpecifications();
            inventorySpecifications.AddFilters(this);
            return inventorySpecifications;
        }
        public override string ToString()
        {
            string _parameter = $"Page={Page}&PageSize={PageSize}";
            if (!string.IsNullOrEmpty(Title))
                _parameter += $"Title={Title}";
            if (IsActive is bool ia)
                _parameter += $"IsActive={ia}";
            return _parameter;
        }
    }
}
