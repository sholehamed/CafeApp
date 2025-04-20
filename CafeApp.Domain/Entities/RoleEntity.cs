using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class RoleEntity:EntityBase
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
