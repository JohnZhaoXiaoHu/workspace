using HslCommunication.Core.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.Profinet.Melsec;

namespace MTHCollection.Common.Communication
{

    [SerialDevice(SerialType.FxSerial)]
    public class FxLinkDevice : ISerialDevice
    {
        public DeviceSerialPort GetDevice()
        {
            var fx = new MelsecFxSerial();
            
            return fx;
        }
    }
}
