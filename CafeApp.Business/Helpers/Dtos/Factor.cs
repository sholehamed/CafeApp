using CafeApp.Business.Helpers.Common;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Helpers.Dtos
{
    public class FactorDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string User { get; set; }
        public string Inventory { get; set; }
        public string TotalPrice { get; set; }
        public FactorDto()
        {
            
        }
    }
    public class CreateFactorParameter
    {
        public string Number { get; set; }
        public int UserId { get; set; }
        public int InventoryId { get; set; }
        public CreateFactorParameter()
        {
            
        }
    }

    public class ListFactorParameter: PagingParameter,IGetParameter<InventoryFactorEntity>
    {
        public string? Number { get; set; }
        public Guid? UserId { get; set; }
        public Guid? InventoryId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public ListFactorParameter()
        {
            
        }

        public ISpecifications<InventoryFactorEntity> GetSpecifications()
        {
            throw new NotImplementedException();
        }
    }
}
