using CafeApp.Business.Helpers.Dtos;
using Microsoft.JSInterop;
using System.Reflection;

namespace CafeApp.Shared.Components.MenuComponents
{
    public partial class CategoryHeader
    {
        private IJSObjectReference? _module;

        private ICollection<MenuCategoryModel> _categories;
        public CategoryHeader()
        {
           _categories = new List<MenuCategoryModel>();
        }
        protected override async Task OnInitializedAsync()
        {

             _categories = await _unit.Categories.GetMenu();
        }
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
                _module = await _js.InvokeAsync<IJSObjectReference>("import", "/_content/CafeApp.Shared/scripts/CatSelectt.js");

        }
        public async Task GoToCategory(Guid catId)
        {
           await _module.InvokeVoidAsync("GoToCategory", catId);
        }
    }
}
