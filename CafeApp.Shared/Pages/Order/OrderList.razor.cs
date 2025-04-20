using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;
using CafeApp.Shared.Components.DashboardComponents;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CafeApp.Shared.Pages.Order
{
    public partial class OrderList
    {
        [CascadingParameter]
        public TablesPanel _table { get; set; }
        private readonly string _route = "orders";
        private ListOrderParameter _filter = new();
        private async Task<GridData<OrderDto>> LoadData(GridState<OrderDto> gridState)
        {
            _filter.Start = _dateRange!.Start;
            _filter.End = _dateRange!.End;
            _filter.PageSize = gridState.PageSize;
            _filter.Page = gridState.Page + 1;
            var res = await _unit.Orders.GetPaged(_filter.GetSpecifications(), _filter);
            if (res.Items is null)
                res = new PagedList<OrderDto>(new List<OrderDto>(), res.TotalItems);
            return new GridData<OrderDto> { Items = res.Items, TotalItems = res.TotalItems };
        }
        public void GoToCreatePAge()
        {
            _navigation.NavigateTo($"/dashboard/{_route}/new");
        }
        public void Edit(Guid id)
        {
            _navigation.NavigateTo($"/dashboard/{_route}/" + id);

        }
        public async Task Delete(Guid id)
        {
            var res = await _dialogService.ShowMessageBox("تایید", "آیا اطمینان دارید", "تایید", null, "لغو");
            if (res.Value)
            {
                await _unit.Orders.DeleteAsync(id);
                _notification.NotifySuccess();
                await _dataGrid.ReloadServerData();
            }
        }
        public async Task Sync()
        {
            try
            {
                ICollection<OrderEntity> dbEntities = await _unit.Orders.GetAllForSync();
                foreach (OrderEntity dbEntity in dbEntities)
                {
                    await _restUnit.Orders.WriteSync(dbEntity);
                }
                await _restUnit.Orders.Apply();
                ICollection<OrderEntity> _apiEntities = await _restUnit.Orders.Sync();
                foreach (OrderEntity dbEntity in _apiEntities)
                {
                    await _unit.Orders.WriteSync(dbEntity);
                }
                await _unit.Orders.Apply();
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public void GoToDetails(Guid id)
        {
            _navigation.NavigateTo($"/dashboard/order/{id}");
        }
        public string GetChangeStateButtonStyle(string state, string button)
        {
            if (state.Equals(button))
                if (state.Equals("لغو"))
                    return "background-color:red;margin:5px;disabled:true";
                else
                    return "background-color:yellow;margin:5px;disabled:true";
            else
                return "background-color:slategrey;margin:5px";

        }
        public bool GetStateButtonEnable(string state, string button)
        {
            return state.Equals(button);

        }
        public async Task ChangeState(Guid orderId, short state)
        {
            await _unit.Orders.ChangeState(orderId, state);
            await _table.ReloadTables();
            await _dataGrid.ReloadServerData();
        }
    }
}
