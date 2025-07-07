using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Zhaoxi.OpcuaServer.Models
{
    public class DeviceModel
    {
        [XmlAttribute]
        public int DID { get; set; }
        [XmlAttribute]
        public string DName { get; set; }

        // 关于属性：
        // List  集合
        //public string IP { get; set; }
        //public int Port { get; set; }
        public List<PropertyModel> PropertyList { get; set; }

        // 变量集合
        public List<VariableModel> VariableList { get; set; }
    }
}
