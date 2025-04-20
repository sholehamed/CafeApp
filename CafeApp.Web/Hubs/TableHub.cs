using Microsoft.AspNetCore.SignalR;

namespace CafeApp.Hubs
{
    public class TableHub : Hub
    {
        public async Task SendTableAlert(string tableId,string connectionId)
        {
            //await Clients.All.SendAsync(tableId,connectionId);
            await Clients.All.SendAsync("TableAlert", tableId, connectionId);
        }
        public async Task ResponseTableAlert(string id)
        {
            await Clients.Client(id).SendAsync("ResponseAlert", id);
        }
    }
}
