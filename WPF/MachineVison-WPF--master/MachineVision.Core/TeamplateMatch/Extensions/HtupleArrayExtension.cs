using HalconDotNet;
using MachineVision.Core.TeamplateMatch.Common;
using MachineVision.Core.TeamplateMatch.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace MachineVision.Core.TeamplateMatch.Extensions
{
    public static class HtupleArrayExtension
    {
        /// <summary>
        /// 扩展方法，获取ROI图像
        /// </summary>
        /// <param name="roi">ROI对象类</param>
        /// <param name="Image">底图</param>
        public static HObject GetROiImage(this ROIParamter roi,HObject Image)
        {
            HTuple[] hTuples = roi.HTuples;
            
            HObject ho_Gen=null;
            HObject ho_ReducedImage = null;
            HOperatorSet.GenEmptyObj(out ho_Gen);
            HOperatorSet.GenEmptyObj(out ho_ReducedImage);
            switch (roi.Shape)
            {
                case Shape.Rectangle:
                    HOperatorSet.GenRectangle1(out  ho_Gen, hTuples[0], hTuples[1], hTuples[2], hTuples[3]);
                    HOperatorSet.ReduceDomain(Image, ho_Gen, out  ho_ReducedImage);
                    break;
                case Shape.Circle:
                    HOperatorSet.GenCircle(out ho_Gen, hTuples[0], hTuples[1], hTuples[2]);
                    HOperatorSet.ReduceDomain(Image, ho_Gen, out ho_ReducedImage);
                    break;
                case Shape.Ellipse:
                    HOperatorSet.GenEllipse(out ho_Gen, hTuples[0], hTuples[1], hTuples[2], hTuples[3], hTuples[4]);
                    HOperatorSet.ReduceDomain(Image, ho_Gen, out ho_ReducedImage);
                    break;
                case Shape.Region:
                    HOperatorSet.ReduceDomain(Image, roi.ROIRegion, out ho_ReducedImage);
                    break;
            }
            return ho_ReducedImage;
        }
    }
}
