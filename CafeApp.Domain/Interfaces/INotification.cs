namespace CafeApp.Domain.Interfaces
{
    public interface INotification
    {
        void NotifySuccess(string message = "");
        void Error(string message);
    }
}
