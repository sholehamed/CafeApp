using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class OrderEntity:EntityBase
    {
        public FactorState State { get; set; }
        public Guid UserId { get; set; }
        public UserEntity? User { get; set; }
        public DateTime Time { get; set; }
        public Guid? CustomerId { get; set; }
        public CustomerEntity? Customer { get; set; }
        public FactorType Type { get; set; }
        public Guid? TableId { get; set; }
        public TableEntity? Table { get; set; }
        public long TotalPrice{ get; set; }
        public bool HasDiscount { get; set; }
        public long PaidAmount { get; set; }
        public long TotalCost { get; set; }
        public string? Description { get; set; }
        public ICollection<OrderDetailEntity>? Details { get; set; }
    }
}
