using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHCollection.Common.Communication
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NetDeviceAttribute:Attribute
    {
        public NetType NetType { get; set; }

        public NetDeviceAttribute(NetType netType)
        {
            NetType = netType;
        }
    }
}
