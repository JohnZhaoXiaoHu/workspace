using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using Prism.Mvvm;

namespace MachineVision.Defect.Models.Result
{
    /// <summary>
    /// 缺陷检测结果
    /// </summary>
    public class DeformableInspectResult : BindableBase
    {
        private bool isNoDeformable;

        /// <summary>
        /// 是否无缺陷
        /// </summary>
        public bool IsNoDeformable
        {
            get { return isNoDeformable; }
            set
            {
                isNoDeformable = value;
                RaisePropertyChanged();
            }
        }

        private string message;

        /// <summary>
        /// 结果信息
        /// </summary>
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                RaisePropertyChanged();
            }
        }

        private int defomableCount;

        public int DefomableCount
        {
            get { return defomableCount; }
            set { defomableCount = value; RaisePropertyChanged(); }
        }


        private HObject deformableRegion;

        /// <summary>
        /// 缺陷区域
        /// </summary>
        public HObject DeformableRegion
        {
            get { return deformableRegion; }
            set
            {
                deformableRegion = value;
                RaisePropertyChanged();
            }
        }

        private HWindow editWindow;

        /// <summary>
        /// 结果显示对应的窗口
        /// </summary>
        public HWindow EditWindow
        {
            get { return editWindow; }
            set
            {
                editWindow = value;
                RaisePropertyChanged();
            }
        }

        private HObject rectifiedImage;

        /// <summary>
        /// 形变纠正图像
        /// </summary>
        public HObject RectifiedImage
        {
            get { return rectifiedImage; }
            set
            {
                rectifiedImage = value;
                RaisePropertyChanged();
            }
        }

        private HObject teamplateImage;

        /// <summary>
        ///  模板图像
        /// </summary>
        public HObject TeamplateImage
        {
            get { return teamplateImage; }
            set { teamplateImage = value;RaisePropertyChanged(); }
        }


        /// <summary>
        /// 检测区域
        /// </summary>
        public InsectRegionModel InspectRegionModel { get; set; }

    }
}
