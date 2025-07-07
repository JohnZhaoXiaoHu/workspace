using HslCommunication.Core.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHCollection.Common.Communication
{
    public interface INetDevice
    {
        public DeviceTcpNet GetDevice(string ip, int port);

    }
}
