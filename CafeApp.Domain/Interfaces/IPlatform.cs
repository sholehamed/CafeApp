using CafeApp.Domain.Common;

namespace CafeApp.Domain.Interfaces
{
    public interface IPlatform
    {
        Platform GetPlatform();
        bool IsConnected();
        void Connected();
        void Disconnected();
    }
}
