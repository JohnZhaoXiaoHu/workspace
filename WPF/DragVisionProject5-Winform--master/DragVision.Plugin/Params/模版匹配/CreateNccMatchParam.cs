using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragVision.Plugin.Params.模版匹配
{
    /// <summary>
    /// 创建NCC模版匹配参数
    /// </summary>
    public class CreateNccMatchParam
    {
        /// <summary>
        /// 金字塔层级
        /// </summary>
        public string NumLevels { get; set; }

        /// <summary>
        /// 起始角度
        /// </summary>
        public double AngleStart { get; set; }

        /// <summary>
        /// 角度范围
        /// </summary>
        public double AngleExtent { get; set; }


        /// <summary>
        /// 角度步长
        /// </summary>
        public double AngleStep { get; set; }

        /// <summary>
        /// 极性
        /// </summary>
        public string Metric { get; set; }

    }
}
