using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class UserRoleEntity:EntityBase
    {
        public Guid RoleId { get; set; }
        public RoleEntity? Role { get; set; }
        public Guid UserId { get; set; }
        public UserEntity? User { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowDelete { get; set; }
        public bool AllowGet { get; set; }
        public bool IsActive { get; set; }
    }
}
