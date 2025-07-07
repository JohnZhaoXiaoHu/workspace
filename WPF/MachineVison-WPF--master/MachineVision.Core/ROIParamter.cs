using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using MachineVision.Core.TeamplateMatch.Enum;
using Prism.Mvvm;

namespace MachineVision.Core.TeamplateMatch.Common
{
    /// <summary>
    /// ROI参数
    /// </summary>
    public class ROIParamter : BindableBase
    {
        private HTuple[] htuples;
        private Shape shape;
        private HObject roiRegion;

        /// <summary>
        /// ROI区域有关的坐标参数
        /// </summary>
        public HTuple[] HTuples
        {
            get { return htuples; }
            set
            {
                htuples = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// ROI区域的形状
        /// </summary>
        public Shape Shape
        {
            get { return shape; }
            set
            {
                shape = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// ROI区域
        /// </summary>
        public HObject ROIRegion
        {
            get { return roiRegion; }
            set
            {
                roiRegion = value;
                RaisePropertyChanged();
            }
        }

        public ROIParamter()
        {
            HOperatorSet.GenEmptyObj(out roiRegion);
        }
    }
}
