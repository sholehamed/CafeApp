using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class PayoutEntity:EntityBase
    {
        public Guid UserId { get; set; }
        public Guid? User { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public long Amount{ get; set; }
        public bool IsAccepted { get; set; }
        public Guid? AcceptuserId { get; set; }
        public UserEntity? AcceptUser { get; set; }
    }
}
