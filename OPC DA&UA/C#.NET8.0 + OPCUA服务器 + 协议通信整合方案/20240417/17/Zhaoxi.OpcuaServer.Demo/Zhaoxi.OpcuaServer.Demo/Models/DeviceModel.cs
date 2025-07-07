using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Zhaoxi.OpcuaServer.Demo.Models
{
    public class DeviceModel
    {
        [XmlIgnore]
        public bool IsCurrent { get; set; }
        [XmlAttribute]
        public int DID { get; set; }
        [XmlAttribute]
        public string DName { get; set; }
        //public string IP { get; set; }
        //public int Port { get; set; }
        //public string PortName { get; set; }
        public List<PropertyModel> PropertyList { get; set; }

        public List<VariableModel> VariableList { get; set; }
    }
}
