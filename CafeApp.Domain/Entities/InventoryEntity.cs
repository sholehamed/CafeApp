using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class InventoryEntity:EntityBase
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
