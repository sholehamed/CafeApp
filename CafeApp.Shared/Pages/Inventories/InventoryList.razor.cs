using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using MudBlazor;

namespace CafeApp.Shared.Pages.Inventories
{
    public partial class InventoryList
    {

        MudDataGrid<InventoryDto> _dataGrid;
        ListInventoryParameter _filter = new ListInventoryParameter();
        public async Task<GridData<InventoryDto>> LoadData(GridState<InventoryDto> state)
        {
            try
            {

            _filter.PageSize = state.PageSize;
                _filter.Page = state.Page+1;
            var res = await _unit.Inventories.GetPaged(_filter.GetSpecifications(), _filter);
            return new GridData<InventoryDto> { Items = res.Items, TotalItems = res.TotalItems };
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public void GoToCreatePAge()
        {
            _navigation.NavigateTo("/dashboard/inventories/new");
        }
        public void Edit(Guid id)
        {
            _navigation.NavigateTo("/dashboard/inventories/" + id);

        }
        public async Task Delete(Guid id)
        {
            var res = await _dialogService.ShowMessageBox("تایید", "آیا اطمینان دارید", "تایید", null, "لغو");
            if (res.Value)
            {
                await _unit.Inventories.DeleteAsync(id);
                _notification.NotifySuccess();
                await _dataGrid.ReloadServerData();
            }
        }
        public async Task Sync()
        {
            try
            {
                ICollection<InventoryEntity> dbEntities = await _unit.Inventories.GetAllForSync();

                foreach (InventoryEntity dbEntity in dbEntities)
                {
                    await _restUnit.Inventories.WriteSync(dbEntity);
                }
                await _restUnit.Inventories.Apply();
                ICollection<InventoryEntity> _apiEntities = await _restUnit.Inventories.Sync();

                foreach (InventoryEntity dbEntity in _apiEntities)
                {
                    await _unit.Inventories.WriteSync(dbEntity);
                }
                await _unit.Inventories.Apply();
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
