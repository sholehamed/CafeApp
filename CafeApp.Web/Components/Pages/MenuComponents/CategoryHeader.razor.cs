using CafeApp.Business.Helpers.Dtos;

namespace CafeApp.Web.Components.Pages.MenuComponents
{
    public partial class CategoryHeader
    {
        private ICollection<ProductCategoryDto> _categories;
        public CategoryHeader()
        {
            _categories = new List<ProductCategoryDto>
            {
                new ProductCategoryDto{Id=Guid.NewGuid(),Title="1"},
                new ProductCategoryDto{Id=Guid.NewGuid(),Title="2"},
                new ProductCategoryDto{Id=Guid.NewGuid(),Title="3"},
                new ProductCategoryDto{Id=Guid.NewGuid(),Title="4"},
            };
        }
    }
}
