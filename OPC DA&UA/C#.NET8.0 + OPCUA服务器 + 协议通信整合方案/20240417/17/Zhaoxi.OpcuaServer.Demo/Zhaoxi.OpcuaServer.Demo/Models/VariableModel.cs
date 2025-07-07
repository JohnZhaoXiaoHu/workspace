using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Zhaoxi.OpcuaServer.Demo.Models
{
    public class VariableModel
    {
        [XmlAttribute]
        public string VarName { get; set; }
        [XmlAttribute]
        public string Address { get; set; }

        public object Value { get; set; }
        [XmlAttribute]
        public int Offset { get; set; }
    }
}
