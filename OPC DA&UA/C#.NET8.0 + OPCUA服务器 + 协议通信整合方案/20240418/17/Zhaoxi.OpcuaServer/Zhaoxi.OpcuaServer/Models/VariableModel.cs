using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Zhaoxi.OpcuaServer.Models
{
    public class VariableModel
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Address { get; set; }
        [XmlAttribute]
        public string Unit { get; set; }
        [XmlAttribute]
        public double Offset { get; set; }
    }
}
