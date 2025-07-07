using HslCommunication.Core.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.ModBus;

namespace MTHCollection.Common.Communication
{
    [SerialDevice(serialType:SerialType.ModbusRtu)]
    public class ModbusRtuDevice : ISerialDevice
    {
        public DeviceSerialPort GetDevice()
        {
           //引发异常了
           return new ModbusRtu();
        }
    }
}
