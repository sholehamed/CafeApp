using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class ProductEntity : EntityBase
    {
        public int Order { get;  set; }
        public Guid CategoryId { get;  set; }
        public ProductCategoryEntity? Category { get;  set; }
        public string Title { get;  set; }
        public string? Description { get;  set; }
        public string Image { get;  set; }
        public bool IsNew { get;  set; }
        public long Price { get;  set; }
        public long  Cost { get;  set; }

        public bool IsActive { get;  set; }
        public ICollection<ProductMaterialEntity>? Materials { get;  set; }
        public ICollection<ProductAdditiveEntity>? Additives { get;  set; }
        public void UpdatePrice(long price) => Price = price;
        public void ChangeOrder(int order)=>Order = order;
        public void SetMaterials(ICollection<ProductMaterialEntity> materials) => Materials = materials;
        public void SetAdditives(ICollection<ProductAdditiveEntity> additives) => Additives = additives;

        public void ClearRelations()
        {
            Category=null;
            Materials=null;
            Additives=null;
        }

        public ProductEntity()
        {
            Title = string.Empty;
            Image = string.Empty;
            Category = null;
        }

        public ProductEntity(int order, Guid categoryId, string title, string? description, string image, bool isNew, long price, bool isActive)
        {
            Order = order;
            CategoryId = categoryId;
            Title = title;
            Description = description;
            Image = image;
            IsNew = isNew;
            Price = price;
            IsActive = isActive;

        }
        public ProductEntity(Guid id, int order, Guid categoryId, string title, string? description, string image, bool isNew, long price, bool isActive) : base(id)
        {
            Order = order;
            CategoryId = categoryId;
            Title = title;
            Description = description;
            Image = image;
            IsNew = isNew;
            Price = price;
            IsActive = isActive;

        }
    }
}