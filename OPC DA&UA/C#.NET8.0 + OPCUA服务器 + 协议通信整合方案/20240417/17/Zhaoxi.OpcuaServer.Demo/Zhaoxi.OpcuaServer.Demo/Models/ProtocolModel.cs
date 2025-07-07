using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Zhaoxi.OpcuaServer.Demo.Models
{
    public class ProtocolModel
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Ns { get; set; }
        [XmlAttribute]
        public string Dll { get; set; }

        public List<DeviceModel> DeviceList { get; set; }
    }
}
