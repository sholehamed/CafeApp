using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;
using MudBlazor;
namespace CafeApp.Shared.Pages.Category
{
    public partial class CategoryList
    {
        private ListProductCategoryParameter _filter = new();
        private async Task<GridData<ProductCategoryDto>> LoadData(GridState<ProductCategoryDto> gridState)
        {
            _filter.PageSize=gridState.PageSize;
            _filter.Page=gridState.Page+1;
            var res = await _unit.Categories.GetPaged(_filter.GetSpecifications(), _filter);
            if (res.Items is null)
                res = new PagedList<ProductCategoryDto>(new List<ProductCategoryDto>(), res.TotalItems);
            return new GridData<ProductCategoryDto> { Items = res.Items, TotalItems = res.TotalItems };
        }
        public void GoToCreatePAge()
        {
            _navigation.NavigateTo("/dashboard/categories/new");
        }
        public void Edit(Guid id)
        {
            _navigation.NavigateTo("/dashboard/categories/" + id);

        }
        public async Task Delete(Guid id)
        {
            var res = await _dialogService.ShowMessageBox("تایید", "آیا اطمینان دارید", "تایید", null, "لغو");
            if (res.Value)
            {
                await _unit.Categories.DeleteAsync(id);
                _notification.NotifySuccess();
                await _dataGrid.ReloadServerData();
            }
        }
        public async Task Sync()
        {
            try
            {
                ICollection<ProductCategoryEntity> dbEntities = await _unit.Categories.GetAllForSync();
                foreach (ProductCategoryEntity dbEntity in dbEntities)
                {
                    await _restUnit.Categories.WriteSync(dbEntity);
                }
                await _restUnit.Categories.Apply();
                ICollection<ProductCategoryEntity> apiEntities = await _restUnit.Categories.Sync();
                foreach (ProductCategoryEntity dbEntity in apiEntities)
                {                 
                    dbEntity.Products=null;
                    await _unit.Categories.WriteSync(dbEntity);
                }
                await _unit.Categories.Apply();
                _notification.NotifySuccess();
                await _dataGrid.ReloadServerData();
            }
            catch (Exception e)
            {

                throw;
            }
           
        }
    }

}
