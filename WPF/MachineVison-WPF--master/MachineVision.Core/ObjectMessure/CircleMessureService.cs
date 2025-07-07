using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using MachineVision.Core.Extension;
using MachineVision.Core.Ocr;
using MachineVision.Core.TeamplateMatch;
using MachineVision.Core.TeamplateMatch.Common;
using Prism.Mvvm;

namespace MachineVision.Core.ObjectMessure
{
    public class CircleMessureService : BindableBase
    {
        #region 字段和属性

        private ROIParamter roi;
        public ROIParamter ROI
        {
            get { return roi; }
            set
            {
                roi = value;
                RaisePropertyChanged();
            }
        }

        private CircleFindParamter findParamter;

        /// <summary>
        /// 查找匹配参数
        /// </summary>
        public CircleFindParamter FindParamter
        {
            get { return findParamter; }
            set
            {
                findParamter = value;
                RaisePropertyChanged();
            }
        }

        #endregion



        #region 中间变量(私有字段)

        //测量对象的数据结构
        HTuple hv_MetrologyHandle = null;

        #endregion


        #region 构造函数
        public CircleMessureService()
        {
            FindParamter = new CircleFindParamter();
            HOperatorSet.CreateMetrologyModel(out hv_MetrologyHandle);
        }

        #endregion

        #region 方法
        public async Task<ObjectMessureResult> FindMatchTeamplate(
            HObject EditImage,
            HWindow hWindow
        )
        {
            HObject ho_ReducedImage = new HObject(),
                ho_Contour = new HObject(),
                ho_Contours = new HObject(),
                ho_Contour1 = new HObject();
            HTuple hv_Parameter = null;

            ObjectMessureResult messureResult=null;

            //图像转为灰度图
            HOperatorSet.Rgb1ToGray(EditImage, out HObject ho_GrayImage);

            //提取ROI区域，确定检测范围
            if (ROI != null)
            {
                HOperatorSet.ReduceDomain(ho_GrayImage, ROI.ROIRegion, out ho_ReducedImage);
            }
            else
            {
                ho_ReducedImage = ho_GrayImage;
            }

            if(FindParamter.Radius>0)
            {
                //查找匹配内容
                var timeSpan = await TimerHelper.GetTimer(() =>
                {
                    //添加圆形测量对象，主要参数包括圆心坐标，半径以及边缘系数，边缘阈值等
                    HOperatorSet.AddMetrologyObjectCircleMeasure(
                        hv_MetrologyHandle,
                        FindParamter.Row,
                        FindParamter.Column,
                        FindParamter.Radius,
                        FindParamter.MeasureLength1,
                        FindParamter.MeasureLength2,
                        FindParamter.MeasureSigma,
                        FindParamter.MeasureThreshold,
                        new HTuple(),
                        new HTuple(),
                        out HTuple hv_Index
                    );

                    //获取测量对象的轮廓
                    HOperatorSet.GetMetrologyObjectModelContour(
                        out ho_Contour,
                        hv_MetrologyHandle,
                        0,
                        1.5
                    );

                    //获取测量区域和计量模型的计量对象的边缘位置结果(获取每个卡尺的坐标)
                    HOperatorSet.GetMetrologyObjectMeasures(
                        out ho_Contours,
                        hv_MetrologyHandle,
                        "all",
                        "all",
                        out HTuple hv_Row1,
                        out HTuple hv_Column1
                    );

                    //测量并拟合计量模型中所有计量对象的几何形状。(通过卡尺的坐标拟合出圆的轮廓)
                    HOperatorSet.ApplyMetrologyModel(ho_ReducedImage, hv_MetrologyHandle);

                    //获取测量结果，输出到Param中，圆形测量目标输出圆的圆心坐标以及半径
                    HOperatorSet.GetMetrologyObjectResult(
                        hv_MetrologyHandle,
                        0,
                        "all",
                        "result_type",
                        "all_param",
                        out hv_Parameter
                    );

                    //获取拟合完成的圆的轮廓
                    HOperatorSet.GetMetrologyObjectResultContour(
                        out ho_Contour1,
                        hv_MetrologyHandle,
                        0,
                        "all",
                        1.5
                    );
                });

                //获取匹配结果的文字信息
                 messureResult = new ObjectMessureResult()
                {
                    IsSuccess = true,
                    Message =
                        $"圆心坐标:({Math.Round(hv_Parameter.DArr[0], 3)},"
                        + $"{Math.Round(hv_Parameter.DArr[1])}),半径:{Math.Round(hv_Parameter.DArr[2])}" +
                        $",匹配耗时:{timeSpan}ms",
                    TimeSpan = timeSpan
                };

                //显示匹配结果
                if (hWindow != null)
                {
                    //在窗体上显示匹配结果
                    HOperatorSet.SetColor(hWindow, "red");
                    HOperatorSet.DispObj(ho_Contour, hWindow); //显示测量轮廓

                    HOperatorSet.SetColor(hWindow, "pink");
                    HOperatorSet.DispObj(ho_Contours, hWindow); //显示所有卡尺

                    HOperatorSet.SetColor(hWindow, "green");
                    HOperatorSet.SetLineWidth(hWindow, 6);
                    HOperatorSet.DispObj(ho_Contour1, hWindow); //显示拟合的圆轮廓

                    HOperatorSet.SetColor(hWindow, "blue");
                    HOperatorSet.SetLineWidth(hWindow, 3);
                    HOperatorSet.DispCross(hWindow, hv_Parameter.DArr[0], hv_Parameter.DArr[1], 20, 0); //用准星标记圆心
                }
            }
           

            return messureResult;
        }
        #endregion
    }
}
