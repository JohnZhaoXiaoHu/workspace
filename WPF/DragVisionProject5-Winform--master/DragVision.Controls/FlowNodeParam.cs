using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragVision.Controls
{

    public enum ROIType
    {
        Circle,
        Rectangle1,     
        Ellipse,
    }

    /// <summary>
    /// 流程节点参数类
    /// </summary>
    public class FlowNodeParam
    {
        /// <summary>
        /// 图像参数
        /// </summary>
        public HObject ImageParam { get; set; }

        

        /// <summary>
        /// 区域参数
        /// </summary>
        public HObject RegionParam { get; set; }


        /// <summary>
        /// ROI类型
        /// </summary>
        public ROIType ROIType { get; set; }

        /// <summary>
        /// ROI坐标参数
        /// </summary>
        public HTuple[] CoordinateParam { get; set; }


        /// <summary>
        /// 结果参数
        /// </summary>
        public List<HTuple> ResultParam { get; set; }= new List<HTuple>();

        /// <summary>
        /// 句柄参数
        /// </summary>
        public HTuple HandleParam { get; set; }
    }
}
