using CafeApp.Domain.Interfaces;
using MudBlazor;

namespace CafeApp.Shared.Util
{
    internal class NotificationService : INotification
    {
        private readonly ISnackbar _snakbar;

        public NotificationService(ISnackbar snakbar)
        {
            _snakbar = snakbar;
        }

        public void Error(string message)
        {
            _snakbar.Add(message, Severity.Warning);

        }

        public void NotifySuccess(string message = "")
        {
            if (string.IsNullOrEmpty(message))
                _snakbar.Add(StaticMessages.Success, Severity.Success);
            else
                _snakbar.Add(message, Severity.Success);
        }
    }
}
