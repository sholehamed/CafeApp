using CafeApp.Domain.Common;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Web.Util
{
    public class PlatformService : IPlatform
    {
        private bool _isConnected=false;

        public void Connected()
        {
            throw new NotImplementedException();
        }

        public void Disconnected()
        {
            throw new NotImplementedException();
        }

        public Platform GetPlatform()
        {
            return Platform.Web;
        }

        public bool IsConnected()
        {
            throw new NotImplementedException();
        }
    }
}
