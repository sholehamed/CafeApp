using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class TableEntity:EntityBase
    {
        public string Title { get; set; }
        public int Number { get; set; }

        public bool IsActive { get; set; }
    }
}
