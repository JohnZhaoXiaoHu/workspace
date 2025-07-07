using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Zhaoxi.OpcuaServer.Models;

namespace Zhaoxi.OpcuaServer.ViewModels
{
    internal class MainViewModel
    {
        public List<ProtocolModel> ProtocolList { get; set; }

        public MainViewModel()
        {
            //ProtocolList = new List<ProtocolModel>();

            //// 第一个协议
            //var p = new ProtocolModel() { Name = "ModbusTCP" };
            //ProtocolList.Add(p);

            //p.DeviceList = new List<DeviceModel>();

            //var d = new DeviceModel
            //{
            //    DName = "设备一",
            //    PropertyList = new List<PropertyModel>
            //    {
            //        new PropertyModel() { Name = "IP", Value = "127.0.0.1" },
            //        new PropertyModel() { Name = "Port", Value = "502" },
            //    },
            //    VariableList = new List<VariableModel>
            //    {
            //        new VariableModel{ Name="温度",Address="40001",Unit="%",Offset=1000},
            //        new VariableModel{ Name="湿度",Address="40002",Unit="%",Offset=1000},
            //    }
            //};
            //p.DeviceList.Add(d);

            //d = new DeviceModel
            //{
            //    DName = "设备二",
            //    PropertyList = new List<PropertyModel>
            //    {
            //        new PropertyModel() { Name = "IP", Value = "127.0.0.2" },
            //        new PropertyModel() { Name = "Port", Value = "503" },
            //    },
            //    VariableList = new List<VariableModel>
            //    {
            //        new VariableModel{ Name="流量",Address="40001"},
            //        new VariableModel{ Name="压力",Address="40001"},
            //    }
            //};
            //p.DeviceList.Add(d);





            //// 第二个协议
            //p = new ProtocolModel() { Name = "ModbusRTU" };
            //ProtocolList.Add(p);

            //p.DeviceList = new List<DeviceModel>();

            //d = new DeviceModel
            //{
            //    DName = "设备三",
            //    PropertyList = new List<PropertyModel>
            //    {
            //        new PropertyModel() { Name = "PortName", Value = "COM1" },
            //        new PropertyModel() { Name = "BaudRate", Value = "9600" },
            //    },
            //    VariableList = new List<VariableModel>
            //    {
            //        new VariableModel{ Name="温度",Address="40001"},
            //        new VariableModel{ Name="湿度",Address="40001"},
            //    }
            //};
            //p.DeviceList.Add(d);

            //d = new DeviceModel
            //{
            //    DName = "设备四",
            //    PropertyList = new List<PropertyModel>
            //    {
            //        new PropertyModel() { Name = "PortName", Value = "COM2" },
            //        new PropertyModel() { Name = "BaudRate", Value = "19200" },
            //    },
            //    VariableList = new List<VariableModel>
            //    {
            //        new VariableModel{ Name="流量",Address="40001"},
            //        new VariableModel{ Name="压力",Address="40001"},
            //    }
            //};
            //p.DeviceList.Add(d);

            //XmlSerializer serializer = new XmlSerializer(typeof(List<ProtocolModel>));
            //using (var stream = new FileStream("datas.xml", FileMode.Create))
            //{
            //    serializer.Serialize(stream, ProtocolList);
            //}



            XmlSerializer serializer = new XmlSerializer(typeof(List<ProtocolModel>));
            using (var stream = new FileStream("datas.xml", FileMode.Open))
            {
                ProtocolList = (List<ProtocolModel>?)serializer.Deserialize(stream);
            }
        }
    }
}
