using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Shared2.Extensions
{
    public static class HtupleExtension
    {

        /// <summary>
        /// 扩展方法，生成获取圆形区域
        /// </summary>
        /// <param name="htuples"></param>
        /// <returns></returns>
        public static HObject GenCircle(this HTuple[] htuples)
        {
            HObject ho_circle;
            HOperatorSet.GenEmptyObj(out ho_circle);
            if (htuples[0].D!=0 && htuples[1].D!=0 && htuples[2].D!=0)
            {
                HOperatorSet.GenCircle(out ho_circle, htuples[0], htuples[1], htuples[2]);
                return ho_circle;
            }
            return null;
            
        }

        /// <summary>
        /// 扩展方法，生成获取矩形区域
        /// </summary>
        /// <param name="htuples"></param>
        /// <returns></returns>
        public static HObject GenRectangle1(this HTuple[] htuples)
        {
            HObject ho_rectangle;
            HOperatorSet.GenEmptyObj(out ho_rectangle);
            if (htuples[0].D!=0 && htuples[1].D!=0 && htuples[2].D!=0 && htuples[3].D!=0)
            {
                HOperatorSet.GenRectangle1(out ho_rectangle, htuples[0], htuples[1], htuples[2], htuples[3]);
                return ho_rectangle;
            }
            return null;
        }

        /// <summary>
        /// 扩展方法，生成获取椭圆区域
        /// </summary>
        /// <param name="htuples"></param>
        /// <returns></returns>
        public static HObject GenEllipse(this HTuple[] htuples)
        {
            HObject ho_ellipse;
            HOperatorSet.GenEmptyObj(out ho_ellipse);
            if (htuples[0].D!=0 && htuples[1].D!=0 && htuples[2].D!=0 && htuples[3].D!=0 && htuples[4].D!=0)
            {
                HOperatorSet.GenEllipse(out ho_ellipse, htuples[0], htuples[1], htuples[2], htuples[3], htuples[4]);
                return ho_ellipse;
            }
            return null;
        }
    }
}
