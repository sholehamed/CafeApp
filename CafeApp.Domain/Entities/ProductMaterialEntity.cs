using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class ProductMaterialEntity:EntityBase
    {
        public ProductMaterialEntity(ProductEntity? product,Guid unitId, Guid materialId, long amount)
        {
            UnitId = unitId;
            Product = product;
            MaterialId = materialId;
            Amount = amount;
        }

        public ProductMaterialEntity(Guid productId, Guid materialId, long amount)
        {
            ProductId = productId;
            MaterialId = materialId;
            Amount = amount;
        }
        public ProductMaterialEntity(Guid id, Guid productId, Guid materialId, long amount) : base(id)
        {
            ProductId = productId;
            MaterialId = materialId;
            Amount = amount;
        }

        public Guid ProductId { get; set; }
        public ProductEntity? Product { get; set; }
        public Guid MaterialId { get; set; }
        public MaterialEntity? Material { get; set; }
        public Guid UnitId { get; set; }
        public UnitEntity? Unit { get; set; }
        public long Amount { get; set; }
    }
}