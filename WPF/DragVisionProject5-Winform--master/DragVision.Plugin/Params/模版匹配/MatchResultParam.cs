using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragVision.Plugin.Params.模版匹配
{
    public class MatchResultParam
    {
        /// <summary>
        /// 匹配中心点横坐标
        /// </summary>
        public double Row { get; set; }

        /// <summary>
        /// 匹配中心点纵坐标
        /// </summary>
        public double Column { get; set; }


        /// <summary>
        /// 匹配中心点角度
        /// </summary>
        public double Angle { get; set; }

        /// <summary>
        /// 匹配得分
        /// </summary>
        public double Score { get; set; }


        /// <summary>
        /// 耗时
        /// </summary>
        public double TimeSpend { get; set; }
    }
}
