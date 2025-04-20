using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class ProductAdditiveEntity : EntityBase
    {
        public Guid ProductId { get; set; }
        public ProductEntity? Product { get; set; }
        public Guid AdditiveId { get; set; }
        public AdditiveEntity? Additive { get; set; }

        public ProductAdditiveEntity(ProductEntity product, Guid additiveId)
        {
            Product = product;
            AdditiveId = additiveId;
        }

        public ProductAdditiveEntity()
        {
        }
        public ProductAdditiveEntity(Guid id, Guid productId, Guid additiveId) : base(id)
        {
            ProductId = productId;
            AdditiveId = additiveId;
        }

        public ProductAdditiveEntity(Guid productId, Guid additiveId)
        {
            ProductId = productId;
            AdditiveId = additiveId;
        }
    }
}