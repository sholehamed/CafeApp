using CafeApp.Domain.Common;

namespace CafeApp.Domain.Entities
{
    public class ProductCategoryEntity:EntityBase
    {
        public int Order { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public string? Image { get; set; }

        public ICollection<ProductEntity>? Products { get; set; }


    }
}
