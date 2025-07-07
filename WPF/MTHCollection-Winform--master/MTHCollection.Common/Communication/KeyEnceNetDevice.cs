using HslCommunication.Core.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.Profinet.Keyence;

namespace MTHCollection.Common.Communication
{
    [NetDevice(NetType.基恩士上位链路)]
    public class KeyEnceNetDevice : INetDevice
    {
        
        public DeviceTcpNet GetDevice(string ip, int port)
        {
            return new KeyenceNanoSerialOverTcp(ip, port);
        }
    }
}
