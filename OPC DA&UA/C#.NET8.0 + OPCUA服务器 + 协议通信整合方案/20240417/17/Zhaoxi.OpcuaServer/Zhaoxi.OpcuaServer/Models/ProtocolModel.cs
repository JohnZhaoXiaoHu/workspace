using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Zhaoxi.OpcuaServer.Models
{
    public class ProtocolModel
    {
        [XmlAttribute]
        public string Name { get; set; }

        public List<DeviceModel> DeviceList { get; set; }
    }
}
