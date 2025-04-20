using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CafeApp.Shared.Components.DashboardComponents
{
    public partial class CategoriesSection
    {
        [Parameter]
        public DashboardTableModel Table { get; set; } =new DashboardTableModel();
        private bool _isNew=true;

        [Parameter]
        public Action<DashboardCategoryModel> ShowItemsMethod { get; set; }
        public CategoriesSection()
        {
        }
        private Guid _tableId;
        public async void SyncItems(DashboardTableModel table)
        {
            //Categories = _tableCategories[table.Id];
            //i
            //if (factor.Items.Count == 0)
            //{
            //    _tableId = factor.TableId;
                
            //    Categories = (await _unit.Categories.GetForDashboard()).ToList();
            //    await InvokeAsync(StateHasChanged);
            //}
            //else
            //{
            //    foreach (var item in factor.Items)
            //    {
            //        int _catIndex = Categories!.IndexOf(Categories.FirstOrDefault(x => x.Id == item.CategoryId)!);
            //        var c = Categories[_catIndex];
            //        int _itemIndex = c.Items.IndexOf(c.Items.FirstOrDefault(x => x.Id == item.ProductId)!);
            //        Categories[_catIndex].Items[_itemIndex].Amount = item.TotalAmount;
            //    }

            //}
            //if (factor.Items.Count > 0)
            //    _first = false;
            await Task.CompletedTask;
        }
        
        public void NotNew()
        {

        }

        public async Task Reload()
        {
            await OnInitializedAsync();
        }
        public void ShowItems(DashboardCategoryModel category)
        {
            Table.SelectedCategory = category;
            this.ShowItemsMethod.Invoke(category);
        }
        private bool _first = true;

        

    }
}
