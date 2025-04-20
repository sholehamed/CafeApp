using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using MudBlazor;
namespace CafeApp.Shared.Components.DashboardComponents
{
    public partial class TableItem
    {
        [Parameter]
        public DashboardTableModel Item { get; set; }
        [Parameter]
        public TablesPanel TablesPanel { get; set; }

        HubConnection connection;
        public TableItem()
        {

        }
        public async void Click()
        {
            if (Item.State == Business.Helpers.Dtos.TableState.requesting && !string.IsNullOrEmpty(Item.LastConnectionId))
            {
                await connection.InvokeAsync("ResponseTableAlert", Item.LastConnectionId);
                Item.State = Item.LastState;

            }

            else
            {

                if (TablesPanel.ChangeTable)
                {
                    bool isFull = Item.State != Business.Helpers.Dtos.TableState.empty;
                    if (isFull)
                    {
                        _notification.Error("میز انتخابی پر است");
                        return;
                    }
                    else
                    {
                        Item.Factor = TablesPanel.Factor;
                        Item.Factor.TableId = Item.Id;
                        Item.Factor.TableTitle = Item.Title;

                        await _unit.Orders.ChangeTable(Item.Factor.Id, Item.Id);
                        await TablesPanel.ReloadTables();
                        TablesPanel.DisableTableChange();
                    }

                }
                //if (Item.State == TableState.empty)
                //{
                Navigation.NavigateTo("/dashboard/tableOrder/" + Item.Id);
                //}
                //if (Item.State == TableState.filled && Item.Factor != null)
                //{
                //    Navigation.NavigateTo($"dashboard/order/{Item.Factor.Id}");

                //}
            }
            StateHasChanged();
        }
        protected async override Task OnInitializedAsync()
        {
            connection = new HubConnectionBuilder().WithUrl($"{_server.Url}TableHub",
        opt =>
        {

        }).WithAutomaticReconnect().Build();

            await connection.StartAsync();
            await base.OnInitializedAsync();
        }
        void Test(string g)
        {

        }
    }
}
