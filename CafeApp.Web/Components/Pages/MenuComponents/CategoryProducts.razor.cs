using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components;

namespace CafeApp.Web.Components.Pages.MenuComponents
{
    public partial class CategoryProducts
    {
        [Parameter]
        public MenuCategoryModel Item { get; set; }
    }
}
