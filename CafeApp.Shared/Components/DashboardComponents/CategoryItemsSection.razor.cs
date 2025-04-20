using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace CafeApp.Shared.Components.DashboardComponents
{
    public partial class CategoryItemsSection
    {
        private IJSObjectReference? _module;


        [Parameter]
        public EventCallback<DashboardProductModel> AddFactorItem { get; set; }

        [Parameter]
        public EventCallback<DashboardProductModel> MinusFactorItem { get; set; }

        [Parameter]
        public DashboardTableModel Table { get; set; }

        private string GetStyle()
        {
            string sty = string.Empty;
            if (!Table.IsEditEnabled)
                sty = "opacity:0.5;";
            else
                sty = "opacity:1;";
            return sty;
        }
        public CategoryItemsSection()
        {
            if (Table is null)
            {
                Table = new DashboardTableModel();
                Table.SelectedCategory = new DashboardCategoryModel();
            }
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _module = await _js.InvokeAsync<IJSObjectReference>("import", "/_content/CafeApp.Shared/scripts/CategoryItemsSection.js");
            }
        }
        public void Update() => StateHasChanged();
        public async Task Add(DashboardProductModel dashboardProduct)
        {
            if (Table.IsEditEnabled)
            {
                dashboardProduct.Amount++;
              await  _module.InvokeVoidAsync("Add", $"item-{dashboardProduct.Id}");
               await AddFactorItem.InvokeAsync(dashboardProduct);
            }
        }
        public void Minus(DashboardProductModel dashboardProduct)
        {
            if (Table.IsEditEnabled && dashboardProduct.Amount > 0)
            {
                dashboardProduct.Amount--;
                _module.InvokeVoidAsync("Minus", $"item-{dashboardProduct.Id}");
                MinusFactorItem.InvokeAsync(dashboardProduct);
            }

        }
        private string GetItemDisplay(int amount)
        {
            if (amount == 0)
                return "none";
            else
                return "inline";
        }
        public void EnableEdit()
        {
            Table.IsEditEnabled=true;
            InvokeAsync(StateHasChanged);
        }
        public void DisableEdit()
        {
            Table.IsEditEnabled = false;
            InvokeAsync(StateHasChanged);
        }

    }
}
