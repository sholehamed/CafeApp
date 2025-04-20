using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class AdditiveEntity : EntityBase
    {
        public string Title { get; set; }
        public Guid MaterialId { get; set; }
        public MaterialEntity? Material { get; set; }
        public long Price { get; set; }
        public long Amount { get; set; }
        public bool IsActive { get; set; }

        public void ClearRelations()
        {
            Material = null;
        }
     
        public AdditiveEntity()
        {
            Title=string.Empty;
        }

        public AdditiveEntity(Guid id, string title, Guid materialId, long amount,long price,bool isActive) : base(id)
        {
            Title = title;
            MaterialId = materialId;
            IsActive = isActive;
            Amount = amount;
            Price=price;
        }
        public AdditiveEntity(string title, Guid materialId, long amount,long price,bool isActive)
        {
            Title = title;
            MaterialId = materialId;
            IsActive = isActive;
            Amount = amount;
            Price=price;
        }
    }
    public class UpdateAdditivePriceParameter
    {
        public Guid AdditiveId { get; set; }
        public long Price { get; set; }
    }
}