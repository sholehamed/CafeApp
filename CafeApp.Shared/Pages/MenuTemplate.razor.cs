using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;

namespace CafeApp.Shared.Pages
{
    public partial class MenuTemplate
    {
        private IJSObjectReference? _module;
        HubConnection hubConnection;
        private string _title = "کافه لاین";
        private DateTime _lastRing;

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
                _module = await _js.InvokeAsync<IJSObjectReference>("import", "/_content/CafeApp.Shared/scripts/MenuTemplate.js");

        }
        protected async override Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(TableId))
                _title = $"{_title}-میز شماره{TableId}";
            hubConnection = new HubConnectionBuilder()
                     .WithUrl($"{_server.Url}TableHub")
                     .Build();
            await hubConnection.StartAsync();
            hubConnection.On<string>("ResponseAlert", Response);
        }
        public async void Alert()
        {
            if (string.IsNullOrEmpty(TableId))
                await _module.InvokeVoidAsync("ShowDialog", "با اسکن بارکد میزتان را انتخاب کرده و مجدد زنگ بزنید");
            else
            {
                if ((DateTime.Now - _lastRing).TotalMinutes >= 2)
                {
                    await hubConnection.InvokeAsync("SendTableAlert", TableId, hubConnection.ConnectionId);
                    _lastRing = DateTime.Now;
                }
                await _module.InvokeVoidAsync("ShowDialog", "پیام شما ارسال شد");

            }
        }
        public async void Response(string msg)
        {
            await _module.InvokeVoidAsync("ShowDialog", "درخواست شما مشاهده شد");
        }
    }
}
