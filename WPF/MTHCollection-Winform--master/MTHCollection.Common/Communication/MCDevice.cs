using HslCommunication.Core.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.Profinet.Melsec;

namespace MTHCollection.Common.Communication
{
    [NetDevice(NetType.MC)]
    public class MCDevice : INetDevice
    {
        
        public DeviceTcpNet GetDevice(string ip, int port)
        {
            return new MelsecMcNet(ip, port);
        }
    }
}
