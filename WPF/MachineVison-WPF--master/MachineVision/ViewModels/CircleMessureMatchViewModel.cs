using HalconDotNet;
using MachineVision.Core;
using MachineVision.Core.ObjectMessure;
using MachineVision.Core.Ocr;
using MachineVision.Shared2;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Ioc;

namespace MachineVision.ViewModels
{
    public class CircleMessureMatchViewModel:NavigationViewModel
    {
        #region 字段和属性
        private CircleMessureService teamplateService;

        /// <summary>
        /// 模板匹配服务
        /// </summary>
        public CircleMessureService TeamplateService
        {
            get { return teamplateService; }
            set
            {
                teamplateService = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 图像源，通过绑定用户控件的依赖属性获取
        /// </summary>
        public HImage EditImage { get; set; }

        /// <summary>
        /// 已绘制区域,通过绑定用户控件的依赖属性获取
        /// </summary>
        public ObservableCollection<DrawObjectInfo> DrawObjectInfos { get; set; }

        private ObjectMessureResult _matchResult;

        /// <summary>
        /// 匹配结果,绑定用户控件的依赖属性，去通知用户控件拿匹配去做显示和图像标记处理
        /// </summary>
        public ObjectMessureResult MatchResult
        {
            get { return _matchResult; }
            set
            {
                _matchResult = value;
                RaisePropertyChanged();
            }
        }


        private HWindow halconWindow;

        /// <summary>
        /// halcon窗口，通过绑定用户控件的依赖属性获取
        /// </summary>
        public HWindow HalconWindow
        {
            get { return halconWindow; }
            set { halconWindow = value; RaisePropertyChanged(); }
        }


        #endregion

        #region 命令


        /// <summary>
        /// 查找匹配模板命令
        /// </summary>
        public DelegateCommand FindTeamplateCommand { get; set; }

        public DelegateCommand SetROICommand { get; set; }

        public DelegateCommand ExtractParamteCommand { get; set; }

        #endregion

        #region 构造函数
        public CircleMessureMatchViewModel()
        {
            TeamplateService = ContainerLocator.Current.Resolve<CircleMessureService>();



            FindTeamplateCommand = new DelegateCommand(FindTeamplate);

            MatchResult = new ObjectMessureResult();

            SetROICommand = new DelegateCommand(SetROI);

            ExtractParamteCommand = new DelegateCommand(ExtractParamte);
        }

       
        #endregion


        #region 方法

        /// <summary>
        /// 查找匹配模板
        /// </summary>
        private async void FindTeamplate()
        {
            try
            {
                MatchResult = new ObjectMessureResult();
                MatchResult = await TeamplateService.FindMatchTeamplate(EditImage, HalconWindow);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// 设置ROI区域
        /// </summary>
        private void SetROI()
        {
            var d = DrawObjectInfos.FirstOrDefault(d =>
                d.ShapeObject != null && d.DrawHTuples != null
            );
            if (d == null)
            {
                MessageBox.Show("您还没有绘制ROI区域");
                return;
            }
            TeamplateService.ROI = new Core.TeamplateMatch.Common.ROIParamter()
            {
                HTuples = d.DrawHTuples,
                Shape = (Core.TeamplateMatch.Enum.Shape)d.DrawShape,
                ROIRegion = d.ShapeObject
            };
            MessageBox.Show("ROI区域设置成功!");
        }


        //提取圆的参数
        private void ExtractParamte()
        {
            var d = DrawObjectInfos.FirstOrDefault(d => d.DrawShape == Shape.Circle);
            if(d!=null)
            {
                TeamplateService.FindParamter.Row = d.DrawHTuples[0].D;
                TeamplateService.FindParamter.Column = d.DrawHTuples[1].D;
                TeamplateService.FindParamter.Radius = d.DrawHTuples[2].D;
            }
        }
        #endregion
    }
}
