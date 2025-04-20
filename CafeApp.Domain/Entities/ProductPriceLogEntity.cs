using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class ProductPriceLogEntity:EntityBase
    {
        public Guid ProductId { get; set; }
        public ProductEntity? Product { get; set; }
        public long Price{ get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public ProductPriceLogEntity(Guid productId, long price)
        {
            ProductId = productId;
            Price = price;
            StartTime = DateTime.Now;
        }
        public ProductPriceLogEntity()
        {
            
        }
        public ProductPriceLogEntity(ProductEntity product, long price)
        {
            Product = product;
            Price = price   ;
            StartTime = DateTime.Now;
        }
        public void PriceEnded()
        {
            EndTime = DateTime.Now;
        }
    }
}
