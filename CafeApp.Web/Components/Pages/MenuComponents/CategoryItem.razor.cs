using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components;

namespace CafeApp.Web.Components.Pages.MenuComponents
{
    public partial class CategoryItem
    {
        [Parameter]
        public ProductCategoryDto Item { get; set; }
    }
}
