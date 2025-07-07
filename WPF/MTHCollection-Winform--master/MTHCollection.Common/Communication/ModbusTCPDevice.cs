using HslCommunication.Core.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.ModBus;

namespace MTHCollection.Common.Communication
{
    [NetDevice(NetType.ModbusTcp)]
    public class ModbusTCPDevice : INetDevice
    {
        
        public DeviceTcpNet GetDevice(string ip, int port)
        {
            return new ModbusTcpNet(ip, port);
        }
    }
}
