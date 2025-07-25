﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xbd.DataConvertLib
{
    /// <summary>
    /// Long类型数据转换类
    /// </summary>
    [Description("Long类型数据转换类")]
    public class LongLib
    {
        /// <summary>
        /// 字节数组中截取转成64位整型
        /// </summary>
        /// <param name="value">字节数组</param>
        /// <param name="start">开始索引</param>
        /// <param name="dataFormat">数据格式</param>
        /// <returns>返回一个Long类型</returns>
        [Description("字节数组中截取转成64位整型")]
        public static long GetLongFromByteArray(byte[] value, int start = 0, DataFormat dataFormat = DataFormat.ABCD)
        {
            byte[] data = ByteArrayLib.Get8BytesFromByteArray(value, start, dataFormat);
            return BitConverter.ToInt64(data, 0);
        }

        /// <summary>
        /// 将字节数组中截取转成64位整型数组
        /// </summary>
        /// <param name="value">字节数组</param>
        /// <param name="dataFormat">数据格式</param>
        /// <returns>返回Long数组</returns>
        [Description("将字节数组中截取转成64位整型数组")]
        public static long[] GetLongArrayFromByteArray(byte[] value, DataFormat dataFormat = DataFormat.ABCD)
        {
            if (value == null) throw new ArgumentNullException("检查数组长度是否为空");

            if (value.Length % 8 != 0) throw new ArgumentNullException("检查数组长度是否为8的倍数");

            long[] values = new long[value.Length / 8];

            for (int i = 0; i < value.Length / 8; i++)
            {
                values[i] = GetLongFromByteArray(value, 8 * i, dataFormat);
            }
            return values;
        }

        /// <summary>
        /// 将字符串转转成64位整型数组
        /// </summary>
        /// <param name="value">字节数组</param>
        /// <param name="spilt">分隔符</param>
        /// <returns>返回Long数组</returns>
        [Description("将字符串转转成64位整型数组")]
        public static long[] GetLongArrayFromString(string value, string spilt = " ")
        {
            value = value.Trim();

            List<long> result = new List<long>();

            try
            {
                if (value.Contains(spilt))
                {
                    string[] str = value.Split(new string[] { spilt }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var item in str)
                    {
                        result.Add(Convert.ToInt64(item.Trim()));
                    }
                }
                else
                {
                    result.Add(Convert.ToInt64(value.Trim()));
                }

                return result.ToArray();
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("数据转换失败：" + ex.Message);
            }

        }
    }
}
