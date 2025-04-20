using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class OrderItemEntity:EntityBase
    {
        public Guid OrderId { get; set; }
        public OrderEntity? Order { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity? Product { get; set; }
        public bool HasAdditive { get; set; }
        public string? Description { get; set; }
        public ICollection<OrderItemAdditiveEntity>? ItemAdditives { get; set; }

    }
}