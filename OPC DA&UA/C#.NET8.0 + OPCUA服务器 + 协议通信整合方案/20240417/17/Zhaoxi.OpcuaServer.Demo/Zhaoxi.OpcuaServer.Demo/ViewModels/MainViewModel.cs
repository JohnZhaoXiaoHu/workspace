using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Zhaoxi.OpcuaServer.Demo.Base;
using Zhaoxi.OpcuaServer.Demo.Models;

namespace Zhaoxi.OpcuaServer.Demo.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ProtocolModel> ProtocolList { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public DeviceModel CurrentDevice { get; set; }

        public Command DeviceCommand { get; set; }


        public MainViewModel()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ProtocolModel>));
            //反序列化：从Xml字符串到对象
            using (var stream = new FileStream("protocol.xml", FileMode.Open))
            {
                ProtocolList = new ObservableCollection<ProtocolModel>((List<ProtocolModel>?)serializer.Deserialize(stream));
            }

            CurrentDevice = ProtocolList[0].DeviceList[0];
            CurrentDevice.IsCurrent = true;

            DeviceCommand = new Command(DoDeviceSelected);
        }
        private void DoDeviceSelected(object model)
        {
            this.CurrentDevice = model as DeviceModel;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentDevice"));
        }
    }
}
