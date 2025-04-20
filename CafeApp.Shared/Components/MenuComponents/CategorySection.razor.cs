using CafeApp.Business.Helpers.Dtos;

namespace CafeApp.Shared.Components.MenuComponents
{
    public partial class CategorySection
    {
        ICollection<MenuCategoryModel> _categories;
        public CategorySection()
        {
            _categories = new List<MenuCategoryModel>();
        }
        protected override async Task OnInitializedAsync()
        {
            _categories = await _unit.Categories.GetMenu();
        }
    }
}
