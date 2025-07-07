using HalconDotNet;
using MachineVision.Core;
using MachineVision.Core.TeamplateMatch;
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
    public class NccMatchViewModel:NavigationViewModel
    {
        #region 字段和属性
        private ITeamplateMatchService teamplateService;

        /// <summary>
        /// 模板匹配服务
        /// </summary>
        public ITeamplateMatchService TeamplateService
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

        private TeamplateMatchResult _matchResult;

        /// <summary>
        /// 匹配结果,绑定用户控件的依赖属性，去通知用户控件拿匹配去做显示和图像标记处理
        /// </summary>
        public TeamplateMatchResult MatchResult
        {
            get { return _matchResult; }
            set
            {
                _matchResult = value;
                RaisePropertyChanged();
            }
        }

        private HObject maskObject;

        /// <summary>
        /// 掩膜对象,通过绑定用户控件的依赖属性获取
        /// </summary>
        public HObject MaskObject
        {
            get { return maskObject; }
            set
            {
                maskObject = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region 命令
        /// <summary>
        /// 创建匹配模板命令
        /// </summary>
        public DelegateCommand CreateTeamplateCommand { get; set; }

        /// <summary>
        /// 查找匹配模板命令
        /// </summary>
        public DelegateCommand FindTeamplateCommand { get; set; }

        public DelegateCommand SetROICommand { get; set; }

        #endregion


        #region 构造函数
        public NccMatchViewModel()
        {
            TeamplateService = ContainerLocator.Current.Resolve<ITeamplateMatchService>(
                nameof(TeamplateMatchType.NccMatch)
            );

            CreateTeamplateCommand = new DelegateCommand(CreateTeamplate);

            FindTeamplateCommand = new DelegateCommand(FindTeamplate);

            MatchResult = new TeamplateMatchResult();

            SetROICommand = new DelegateCommand(SetROI);
        }
        #endregion


        #region 方法
        /// <summary>
        /// 创建匹配模板
        /// </summary>

        private async void CreateTeamplate()
        {
            if (DrawObjectInfos == null)
            {
                MessageBox.Show("您还没有绘制匹配区域!");
                return;
            }
            var d = DrawObjectInfos.FirstOrDefault().ShapeObject;
            if (d != null)
            {
                if (MaskObject != null)
                {
                    HOperatorSet.Difference(d, MaskObject, out HObject diffrence);
                    d = diffrence;
                }
                try
                {
                    await TeamplateService.CreateMachTeamplate(EditImage, d);
                    MessageBox.Show("模板创建成功!");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private async void FindTeamplate()
        {
            try
            {
                MatchResult = new TeamplateMatchResult();
                MatchResult = await TeamplateService.FindMatchTeamplate(EditImage);
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
        #endregion
    }
}
