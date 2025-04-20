using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;
using CafeApp.Shared.Components.DashboardComponents;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CafeApp.Shared.Pages.Tables
{
    public partial class TableList
    {
        [CascadingParameter]
        public TablesPanel _table { get; set; }
        private MudDataGrid<TableDto> _dataGrid;

        public async Task<GridData<TableDto>> LoadData(GridState<TableDto> state)
        {
            try
            {

            ListTableParameter parameter = new ListTableParameter();
            parameter.PageSize = state.PageSize;
            parameter.Page = state.Page+1;
            var res = await _unit.Tables.GetPaged(parameter.GetSpecifications(), parameter);
            return new GridData<TableDto> { Items = res.Items, TotalItems = res.TotalItems };
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public void GoToCreatePAge()
        {
            _navigation.NavigateTo("/dashboard/tables/new");
        }
        public void Edit(Guid id)
        {
            _navigation.NavigateTo("/dashboard/tables/"+id);

        }
        public async Task Delete(Guid id)
        {
            var res = await _dialogService.ShowMessageBox("تایید", "آیا اطمینان دارید", "تایید", null, "لغو");
            if (res.Value)
            {
                await _unit.Tables.DeleteAsync(id);
                _notification.NotifySuccess();
                await _dataGrid.ReloadServerData();
            }
        }
        public async Task Sync()
        {
            try
            {
                ICollection<TableEntity> dbEntities = await _unit.Tables.GetAllForSync();

                foreach (TableEntity dbEntity in dbEntities)
                {
                    await _restUnit.Tables.WriteSync(dbEntity);
                }
                await _restUnit.Products.Apply();

                ICollection<TableEntity> _apiTables=await _restUnit.Tables.Sync();
                foreach (var item in _apiTables)
                {
                    await _unit.Tables.WriteSync(item);
                }
                await _unit.Tables.Apply();
                _notification.NotifySuccess();
               await _dataGrid.ReloadServerData();
               await _table.ReloadTables();
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
