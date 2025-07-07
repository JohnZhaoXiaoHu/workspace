using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHCollection.Common.Communication
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SerialDeviceAttribute:Attribute
    {
        public SerialType SerialType { get; set; }

        public SerialDeviceAttribute(SerialType serialType)
        {
            SerialType = serialType;
        }
    }
}
