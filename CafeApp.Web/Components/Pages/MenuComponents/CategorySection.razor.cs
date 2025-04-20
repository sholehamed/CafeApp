using CafeApp.Business.Helpers.Dtos;

namespace CafeApp.Web.Components.Pages.MenuComponents
{
    public partial class CategorySection
    {
        ICollection<MenuCategoryModel> _categories;
        public CategorySection()
        {
            _categories = new List<MenuCategoryModel>();
        }
    }
}
