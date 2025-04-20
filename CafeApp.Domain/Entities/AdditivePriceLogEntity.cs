using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class AdditivePriceLogEntity : EntityBase
    {
        public Guid AdditiveId { get; private set; }
        public AdditiveEntity? Additive { get; private set; }
        public long Price { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }
        public AdditivePriceLogEntity()
        {
            
        }
        public AdditivePriceLogEntity(Guid additiveId, long price, DateTime startTime)
        {
            AdditiveId = additiveId;
            Price = price;
            StartTime = startTime;
        }
        public void PriceEnded()
        {
            EndTime = DateTime.Now;
        }
    }
}
