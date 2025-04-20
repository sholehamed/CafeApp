using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class InventoryFactorEntity:EntityBase
    {
        public string Number { get; set; }
        public DateTime Time { get; set; }
        public Guid UserId { get; set; }
        public UserEntity? User { get; set; }
        public Guid InventoryId { get; set; }
        public InventoryEntity? Inventory { get; set; }
        public long TotalPrice{ get; set; }
        public ICollection<InventoryLogEntity>? Items { get; set; }
        public InventoryFactorEntity()
        {
            
        }

        public InventoryFactorEntity(string number, Guid userId,Guid inventoryId, ICollection<InventoryLogEntity>? items)
        {
            InventoryId = inventoryId;
            Number = number;
            UserId = userId;
            Items = items;
        }
    }
}
