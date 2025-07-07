using Opc.Ua;
using Opc.Ua.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Zhaoxi.OpcuaServer.Base;
using Zhaoxi.OpcuaServer.Models;
using Zhaoxi.OpcuaServer.Opcua;

namespace Zhaoxi.OpcuaServer.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public List<ProtocolModel> ProtocolList { get; set; }

        public DeviceModel CurrentDevice { get; set; }

        public Command DeviceCommand { get; set; }

        public Command StartCommand { get; set; }

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


            DeviceCommand = new Command(DoDeviceSelected);
            StartCommand = new Command(DoStart);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void DoDeviceSelected(object model)
        {
            this.CurrentDevice = model as DeviceModel;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentDevice"));
        }

        private async void DoStart(object obj)
        {
            // 开启 OPC UA 服务器
            ApplicationInstance applicationInstance = new ApplicationInstance();

            // 网络配置信息
            ApplicationConfiguration configuration = new ApplicationConfiguration();

            // 应用基本信息
            configuration.ApplicationName = "Zhaoxi Opcua Server";
            configuration.ApplicationType = ApplicationType.Server;
            configuration.ApplicationUri = Utils.Format($"urn:{System.Net.Dns.GetHostName()}:ZhaoxiOpcua");

            // 启动监听地址
            configuration.ServerConfiguration = new ServerConfiguration
            {
                BaseAddresses = new string[] { "opc.tcp://127.0.0.1:9090", "opc.tcp://127.0.0.1:9091" }
            };

            // 安全性配置（证书生成地址）
            configuration.SecurityConfiguration = new SecurityConfiguration
            {
                ApplicationCertificate = new CertificateIdentifier
                {
                    StoreType = "Directory",
                    // %CommonApplicationData% = C:\ProgramData
                    StorePath = @"%CommonApplicationData%\Zhaoxi OPC\CertificateStores\Default",
                    SubjectName = Utils.Format(@"CN={0}, DC={1}", "ZhaoxiOpcua", System.Net.Dns.GetHostName())
                }
            };

            // 安全策略的配置
            configuration.ServerConfiguration.SecurityPolicies.Add(new ServerSecurityPolicy
            {
                SecurityMode = MessageSecurityMode.None,
                SecurityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#None"
            });

            // 异常: Opc.Ua.ServiceResultException:“Unexpected error starting application”
            configuration.TransportQuotas = new TransportQuotas { OperationTimeout = 15000 };
            // 
            await configuration.Validate(ApplicationType.Server);

            applicationInstance.ApplicationConfiguration = configuration;

            // 解决异常：:“Server does not have an instance certificate assigned.”
            await applicationInstance.CheckApplicationInstanceCertificate(false, 0);

            await applicationInstance.Start(new OpcServer(this.ProtocolList));
        }
    }
}
