using HslCommunication.Core.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MTHCollection.Common.Communication
{
    public class DeviceFactory
    {
        /// <summary>
        /// 获取网口设备通讯对象
        /// </summary>
        /// <param name="net"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static DeviceTcpNet GetNetDevice(INetDevice net,string ip, int port)
        {
            return net.GetDevice(ip, port);
        }

        /// <summary>
        /// 获取网口设备通讯对象
        /// </summary>
        /// <param name="netType">网口设备的协议类型</param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static DeviceTcpNet GetNetDevice(NetType netType, string ip, int port)
        {
            //获取当前项目的程序集
            var assembly = Assembly.GetExecutingAssembly();

            //获取实现了INetDevice接口并且实现了NetDeviceAttribute这个特性，并且特性的属性值与netType相等的类
            var type = assembly.GetTypes().Where(t => typeof(INetDevice).IsAssignableFrom(t) && !t.IsInterface).
                FirstOrDefault(t =>
                {
                    var netTypeAttr = t.GetCustomAttribute<NetDeviceAttribute>();
                    return netTypeAttr != null && netTypeAttr.NetType == netType;
                });

            if(type != null)
            {
                //创建该类的实例
                var instance = Activator.CreateInstance(type);

                //调用GetDevice方法获取设备
                var methodInfo = type.GetMethod("GetDevice");
                return (DeviceTcpNet)(methodInfo.Invoke(instance, new object[] { ip, port }));
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 获取串口设备通讯对象
        /// </summary>
        /// <param name="serial">具体的串口通讯类对象</param>
        /// <param name="portName"></param>
        /// <param name="baudrate"></param>
        /// <param name="parity"></param>
        /// <param name="databits"></param>
        /// <param name="stopbits"></param>
        /// <returns></returns>
        public static DeviceSerialPort GetSerialDevice(ISerialDevice serial)
        {
            return serial.GetDevice();
        }

        /// <summary>
        /// 获取串口设备通讯对象
        /// </summary>
        /// <param name="serialType">串口的协议类型</param>
        /// <param name="portName"></param>
        /// <param name="baudrate"></param>
        /// <param name="parity"></param>
        /// <param name="databits"></param>
        /// <param name="stopbits"></param>
        /// <returns></returns>
        public static DeviceSerialPort GetSerialDevice(SerialType serialType)
        {
            ///获取当前执行的程序集
            var assembly = Assembly.GetExecutingAssembly();

            //获取实现了ISerialDevice接口并且实现了SerialDeviceAttribute这个特性，并且特性的属性值与serialType相等的类
            var type = assembly.GetTypes().Where(t => typeof(ISerialDevice).IsAssignableFrom(t) && !t.IsInterface).
                FirstOrDefault(t =>
                {
                    var serialTypeAttr = t.GetCustomAttribute<SerialDeviceAttribute>();
                    return serialTypeAttr != null && serialTypeAttr.SerialType == serialType;
                });

            if (type != null)
            {
                //创建该类的实例
                var instance = Activator.CreateInstance(type);

                //调用GetDevice方法获取设备
                var methodInfo = type.GetMethod("GetDevice");
                return (DeviceSerialPort)(methodInfo.Invoke(instance,null));
            }
            else
            {
                return null;
            }
                
        }

    }
}
