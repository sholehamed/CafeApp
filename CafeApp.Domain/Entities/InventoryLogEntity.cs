using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class InventoryLogEntity:EntityBase
    {
        public Guid MaterialId { get; set; }
        public MaterialEntity? Material { get; set; }
        public InventoryLogState State { get; set; }
        public double Amount { get; set; }
        public DateTime Time { get; set; }
        public InventoryLogDescription? Description { get; set; }
    }
}
