using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class MaterialEntity:EntityBase
    {
        public string Title { get; set; }
        public Guid UnitId { get; set; }
        public UnitEntity? Unit { get; set; }
        public long UnitPrice{ get; set; }
        public bool IsActive { get; set; }
        public void ClearRelations()
        {
            Unit = null;
        }
    }
}
