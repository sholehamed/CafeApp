using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class UserEntity:EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string Username { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
        public string? Image { get; set; }
        public ICollection<UserRoleEntity>? UserRoles { get; set; }
    }
}
