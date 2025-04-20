using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class CustomerEntity:EntityBase
    {
        public int Code { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get{ return $"{FirstName} {LastName}"; } }
        public Gender Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        private string GenderTitle()
        {
            return Gender switch
            {
                Gender.Female => "خانم",
                Gender.Male => "آقای",
                _ => string.Empty,
            };
        }
    }
}
