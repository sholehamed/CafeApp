using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class UnitEntity:EntityBase
    {
        public string Title { get; set; }
        public Guid? ParentId { get; set; }
        public UnitEntity? Parent { get; set; }
        public long? Relation { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UnitEntity>? Childs { get; set; }

        public void ClearRelations()
        {
            Parent = null;
            Childs = null;
        }

    }
}
