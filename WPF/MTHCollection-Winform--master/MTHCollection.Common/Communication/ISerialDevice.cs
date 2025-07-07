using HslCommunication.Core.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHCollection.Common.Communication
{
    public interface ISerialDevice
    {
        public DeviceSerialPort GetDevice();
    }
}
