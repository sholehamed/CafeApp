using CafeApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Util
{
    internal class PlatformService : IPlatform
    {
        private bool _isConnected=false;
        public void Connected()
        {
            _isConnected = true;
        }

        public void Disconnected()
        {
            _isConnected = false;
        }

        public Domain.Common.Platform GetPlatform()
        {
            return Domain.Common.Platform.App;
        }

        public bool IsConnected()=>_isConnected;
        
    }
}
