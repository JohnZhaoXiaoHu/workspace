using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VaribleConfig.Common
{
    public class DataValidationHelper
    {
        /// <summary>
        /// 判断是否为IP地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIPAddress(string ip)
        {
            return Regex.IsMatch(ip, @"\d+\.\d+\.\d+\.\d+");
        }

        /// <summary>
        /// 判断是否为端口号
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool IsPort(string port)
        {
            return Regex.IsMatch(port, @"^\d+$");
        }

        /// <summary>
        /// 判断是否为非负整数
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsNonnegativeInteger (string number)
        {
            return Regex.IsMatch(number, @"^\d+$");
        }

        /// <summary>
        /// 判断是否为数字(整数、负数和小数)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsNumber(string number)
        {
            return Regex.IsMatch(number, @"^(\-|\+)?\d+(\.\d+)?$");
        }

        public static bool IsPositiveFloatingPointNumber(string number)
        {
            return Regex.IsMatch(number, @"^[1-9]\d*\.\d*|0\.\d*[1-9]\d*$");
        }
    }
}
