using HslCommunication.Core.Device;
using MTHCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHCollection.Project
{
    public class CommonParam
    {
        /// <summary>
        /// 当前用户
        /// </summary>
        public static UserModel CurrentUser { get; set; } = null;

        /// <summary>
        /// 当前设备
        /// </summary>
        public static DeviceModel CurrentDevice { get; set; }= new DeviceModel();

        /// <summary>
        /// 当前通讯协议对象
        /// </summary>
        public static DeviceTcpNet Modbus { get; set; } = null;

        /// <summary>
        /// 添加日志的委托
        /// </summary>
        public static Action<int,string> AddLogAction { get; set; } = null;


        /// <summary>
        /// 当前应用的配方信息
        /// </summary>
        public static RecipeInfoModel CurrentRecipeInfo { get; set; } = new RecipeInfoModel();


        /// <summary>
        /// 通用写入方法
        /// </summary>
        /// <param name="varibleName">变量名称</param>
        /// <param name="value">写入的值</param>
        /// <returns></returns>
        public static bool WriteData(string varibleName, object value)
        {
            bool result = false;
            if (Modbus != null &&CurrentDevice.GroupList.Count>0)
            {              
                    //根据变量名称获取变量
                    var varible = CurrentDevice?.GetVarible(varibleName);
                    if(varible != null)
                    {
                        //根据变量类型写入数据
                        DataTypeEnum dataType= (DataTypeEnum)Enum.Parse(typeof(DataTypeEnum), varible.VaribleType);
                        switch (dataType)
                        {
                            case DataTypeEnum.Bool:
                               result= Modbus.Write(varible.StartIndex.ToString(), (bool)value).IsSuccess;
                                break;
                            case DataTypeEnum.Short:
                                result = Modbus.Write(varible.StartIndex.ToString(), (short)value).IsSuccess;
                                break;
                            case DataTypeEnum.Int:
                                result=Modbus.Write(varible.StartIndex.ToString(), (int)value).IsSuccess;
                                break;
                            case DataTypeEnum.Float:
                                result = Modbus.Write(varible.StartIndex.ToString(), (float)value).IsSuccess;
                                break;
                            case DataTypeEnum.Uint:
                                result = Modbus.Write(varible.StartIndex.ToString(), (uint)value).IsSuccess;
                                break;
                            case DataTypeEnum.Ushort:
                                result = Modbus.Write(varible.StartIndex.ToString(), (ushort)value).IsSuccess;
                                break;
                            case DataTypeEnum.Double:
                                result = Modbus.Write(varible.StartIndex.ToString(), (double)value).IsSuccess;
                                break;
                            case DataTypeEnum.Long:
                                result = Modbus.Write(varible.StartIndex.ToString(), (long)value).IsSuccess;
                                break;
                            default:
                                break;

                        }
                    

                }

            }

            return result;
        }
    }
}
