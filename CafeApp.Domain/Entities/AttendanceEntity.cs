using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class AttendanceEntity:EntityBase
    {
        public Guid UserId { get; set; }
        public UserEntity? User { get; set; }
        public AttendaceType Type { get; set; }
        public DateTime Time { get; set; }
        public TimeSpan? Soon { get; set; }
        public TimeSpan? Late { get; set; }
    }
}
