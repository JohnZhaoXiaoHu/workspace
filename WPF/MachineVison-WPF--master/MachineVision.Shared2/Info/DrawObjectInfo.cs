using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Shared2
{
    public enum Shape
    {
        Circle,
        Rectangle,
        Ellipse,
        Region
    }
    public class DrawObjectInfo
    {
        /// <summary>
        /// 一个枚举,绘制的形状
        /// </summary>
        public Shape DrawShape { get; set; }

        /// <summary>
        /// 绘制的形状的坐标
        /// </summary>
        public HTuple[] DrawHTuples {  get; set; }

        /// <summary>
        ///已经绘制的形状的halcon对象
        /// </summary>
        public HObject ShapeObject { get; set; }
    }
}
