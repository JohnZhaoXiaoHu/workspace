using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Shared2.Info
{

    public class ReferPointDrawInfo
    {
        /// <summary>
        /// 绘制颜色
        /// </summary>
        public string Color { get; set;}

        /// <summary>
        /// 绘制的坐标信息
        /// </summary>
        public HTuple[] HTuples { get; set;}

        /// <summary>
        /// 已绘制对象
        /// </summary>
        public HDrawingObject DrawingObject { get; set;}
    }
}
