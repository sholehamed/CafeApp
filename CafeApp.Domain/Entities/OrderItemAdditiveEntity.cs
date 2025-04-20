
using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class OrderItemAdditiveEntity:EntityBase
    {
        public Guid OrderItemId { get; set; }
        public OrderItemEntity? OrderItem { get; set; }
        public Guid AdditiveId { get; set; }
        public AdditiveEntity? Additive { get; set; }
        public int Amount { get; set; }
    }
}