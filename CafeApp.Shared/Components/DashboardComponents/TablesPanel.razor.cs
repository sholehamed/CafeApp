using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;

namespace CafeApp.Shared.Components.DashboardComponents
{
    public partial class TablesPanel
    {
        HubConnection hubConnection;
        private List<DashboardCategoryModel> _defaultCategories = new List<DashboardCategoryModel>();
        private IJSObjectReference? _module;
        public List<DashboardTableModel> _tables { get; set; }
        private bool _changeTable;
        private Guid _sourceTable;
        private DashboardFactorModel _order;
        public DashboardFactorModel Factor { get { return _order; } }
        public TablesPanel()
        {

            _tables = new List<DashboardTableModel>();


        }
        public bool ChangeTable { get { return _changeTable; } }
        public void EnableTableChange(Guid sourceTable,DashboardFactorModel order)
        {
            _changeTable = true;
            _sourceTable = sourceTable;
            _order= order;
        }
        public void DisableTableChange()
        {
            _sourceTable = Guid.Empty;
            _changeTable = false;
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
                _module = await _js.InvokeAsync<IJSObjectReference>("import", "/_content/CafeApp.Shared/scripts/TablesPanel.js");
        }
        protected async override Task OnInitializedAsync()
        {

            try
            {
                hubConnection = new HubConnectionBuilder()
             .WithUrl($"{_server.Url}TableHub")
             .WithAutomaticReconnect(new[]
             {
             TimeSpan.Zero,
             TimeSpan.FromSeconds(10),
             TimeSpan.FromSeconds(30)
             })
             .Build();
                hubConnection.On<string, string>("TableAlert", Alert);
                hubConnection.Reconnecting += HubConnection_Reconnecting;
                hubConnection.Reconnected += HubConnection_Reconnected;
                hubConnection.Closed += HubConnection_Closed;
                await hubConnection.StartAsync();

                if (hubConnection.State == HubConnectionState.Connected)
                {
                    IsConnected = true;
                    await InvokeAsync(StateHasChanged);

                }
                _tables = (await _restUnit.Tables.GetDashboardTables()).ToList();
                for (int i = 0; i < _tables.Count; i++)
                {
                    var db_table = await _unit.Tables.GetDashboardTable(_tables[i].Id);
                    if (db_table is DashboardTableModel t)
                        _tables[i] = t;
                }
            }

            catch (Exception e)
            {
                if (hubConnection.State != HubConnectionState.Connected)
                    await Task.Run(TryToConnect);
            }
        }

        private async Task TryToConnect()
        {
            while (true)
            {
                try
                {
                    if (hubConnection.State == HubConnectionState.Connected && !IsConnected)
                    {
                        IsConnected = true;
                        InvokeAsync(StateHasChanged);
                    }
                    else
                    {
                        await hubConnection.StartAsync();

                    }
                    await Task.Delay(10000);
                }
                catch (Exception)
                {
                    await Task.Delay(10000);

                }
            }

        }

        private Task HubConnection_Closed(Exception? arg)
        {
            Task.Run(TryToConnect);
            return Task.CompletedTask;
        }

        private async Task HubConnection_Reconnected(string? arg)
        {
            IsConnected = true;
            await InvokeAsync(StateHasChanged);

        }

        private async Task HubConnection_Reconnecting(Exception? arg)
        {
            IsConnected = false;
            await InvokeAsync(StateHasChanged);
        }

        private async void Alert(string tableId, string connectionId)
        {
            _tables.FirstOrDefault(x => x.Number == int.Parse(tableId))!.LastState = _tables.FirstOrDefault(x => x.Number == int.Parse(tableId))!.State;

            _tables.FirstOrDefault(x => x.Number == int.Parse(tableId))!.State = TableState.requesting;
            _tables.FirstOrDefault(x => x.Number == int.Parse(tableId))!.LastConnectionId = connectionId;
            if (_module != null)
            {
                await _module!.InvokeVoidAsync("PlayAlert");
            }
            await InvokeAsync(StateHasChanged);
        }

        public async Task FillTable(Guid id)
        {
            var filledTable = _tables.FirstOrDefault(x => x.Id == id);
            filledTable!.State = TableState.filled;
            await InvokeAsync(StateHasChanged);
        }
        public async Task EmptyTable(Guid id)
        {
            var filledTable = _tables.FirstOrDefault(x => x.Id == id);
            filledTable!.State = TableState.empty;
            await InvokeAsync(StateHasChanged);
        }
        public async Task ReloadTables()
        {
            _tables = (await _restUnit.Tables.GetDashboardTables()).ToList();
            for (int i = 0; i < _tables.Count; i++)
            {
                _tables[i] = await _unit.Tables.GetDashboardTable(_tables[i].Id);
            }
            _tables = _tables.ToList();
            await InvokeAsync(StateHasChanged);
        }
        public async Task<DashboardTableModel> GetTable(Guid tableId)
        {
            return await Task.FromResult(_tables.FirstOrDefault(x => x.Id == tableId)!);
        }


    }
}
