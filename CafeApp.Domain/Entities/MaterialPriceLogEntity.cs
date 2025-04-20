using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class MaterialPriceLogEntity : EntityBase
    {
        public Guid MaterialId { get; private set; }
        public MaterialEntity? Material { get; private set; }
        public long BuyPrice { get; private set; }
        public long SellPrice { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }
        public MaterialPriceLogEntity()
        {
        }
        public MaterialPriceLogEntity(Guid materialId, long buyPrice, long sellPrice)
        {
            MaterialId = materialId;
            SellPrice = sellPrice;
            BuyPrice = buyPrice;
            StartTime = DateTime.Now;
        }
        public void PriceEnded()
        {
            EndTime = DateTime.Now;
        }
    }
}
