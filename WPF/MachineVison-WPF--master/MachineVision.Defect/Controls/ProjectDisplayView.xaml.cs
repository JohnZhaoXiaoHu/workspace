using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HalconDotNet;
using MachineVision.Core.TeamplateMatch;
using MachineVision.Defect.Paramters.Macth;
using MachineVision.Shared2.Extensions;
using MachineVision.Shared2.Info;

namespace MachineVision.Defect.Controls
{
    /// <summary>
    /// ProjectDisplayView.xaml 的交互逻辑
    /// </summary>
    public partial class ProjectDisplayView : UserControl
    {
        public ProjectDisplayView()
        {
            InitializeComponent();
        }

        #region 依赖属性


        #region 当前检测的图片
        /// <summary>
        /// 当前检测的图片
        /// </summary>
        public HImage EidtImage
        {
            get { return (HImage)GetValue(EidtImageProperty); }
            set { SetValue(EidtImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EidtImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EidtImageProperty = DependencyProperty.Register(
            "EidtImage",
            typeof(HImage),
            typeof(ProjectDisplayView),
            new PropertyMetadata(null, OnImageChanged)
        );

        private static void OnImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ProjectDisplayView p = d as ProjectDisplayView;
            if (p != null)
            {
                p.DisplayImage(e.NewValue as HImage);
            }
        }

        private void DisplayImage(HImage image)
        {
            if (image != null)
            {
                hsmart.HalconWindow.DispObj(image);
                hsmart.HalconWindow.SetPart(0, 0, -2, -2);
                HMWindow = hsmart.HalconWindow;
            }
        }
        #endregion

        #region 当前的窗口对象


        public HWindow HMWindow
        {
            get { return (HWindow)GetValue(HMWindowProperty); }
            set { SetValue(HMWindowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HMWindow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HMWindowProperty = DependencyProperty.Register(
            "HMWindow",
            typeof(HWindow),
            typeof(ProjectDisplayView),
            new PropertyMetadata(null)
        );

        #endregion


        #region 绘制信息


        public ObservableCollection<ReferPointDrawInfo> ReferPointDrawInfos
        {
            get
            {
                return (ObservableCollection<ReferPointDrawInfo>)
                    GetValue(ReferPointDrawInfosProperty);
            }
            set { SetValue(ReferPointDrawInfosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReferPointDrawInfosProperty =
            DependencyProperty.Register(
                "ReferPointDrawInfos",
                typeof(ObservableCollection<ReferPointDrawInfo>),
                typeof(ProjectDisplayView),
                new PropertyMetadata(new ObservableCollection<ReferPointDrawInfo>())
            );

        #endregion

        #region  更新模版参数的命令


        public ICommand UpdateTemplateCommand
        {
            get { return (ICommand)GetValue(UpdateTemplateCommandProperty); }
            set { SetValue(UpdateTemplateCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UpdateTemplateCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UpdateTemplateCommandProperty =
            DependencyProperty.Register(
                "UpdateTemplateCommand",
                typeof(ICommand),
                typeof(ProjectDisplayView),
                new PropertyMetadata(null)
            );

        #endregion


        #region  匹配结果参数

        public MatchResultParamter ResultParamter
        {
            get { return (MatchResultParamter)GetValue(ResultParamterProperty); }
            set { SetValue(ResultParamterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResultParamterProperty =
            DependencyProperty.Register(
                "ResultParamter",
                typeof(MatchResultParamter),
                typeof(ProjectDisplayView),
                new PropertyMetadata(null)
            );
        #endregion


        #region 显示匹配结果

        public bool ShowMatchResult
        {
            get { return (bool)GetValue(ShowMatchResultProperty); }
            set { SetValue(ShowMatchResultProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowMatchResult.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowMatchResultProperty =
            DependencyProperty.Register(
                "ShowMatchResult",
                typeof(bool),
                typeof(ProjectDisplayView),
                new PropertyMetadata(false, OnShowMatchResultChanged)
            );

        private static void OnShowMatchResultChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e
        )
        {
            ProjectDisplayView p = d as ProjectDisplayView;
            if (p != null)
            {
                //若为true,界面去刷新显示匹配到的结果
                p.DisplayMatchResult((bool)e.NewValue);
            }
        }

        private async void DisplayMatchResult(bool match)
        {
            if (match)
            {
                //根据匹配结果参数，绘制所有匹配到的结果
                int length = ResultParamter.NccParamter.Row1.Length;
                HTuple[] htuples = new HTuple[4];
                for (int i = 0; i < length; i++)
                {
                    htuples[0] = ResultParamter.NccParamter.Row1.DArr[i];
                    htuples[1] = ResultParamter.NccParamter.Column1.DArr[i];
                    htuples[2] = ResultParamter.NccParamter.Row2.DArr[i];
                    htuples[3] = ResultParamter.NccParamter.Column2.DArr[i];

                    HObject contours = null;
                    ClearWindowDisplay();//清空窗口显示
                    await Task.Run(() =>
                    {
                        HOperatorSet.GenRectangle1(out HObject rectangle, htuples[0], htuples[1], htuples[2], htuples[3]);
                        HOperatorSet.GenContourRegionXld(rectangle, out  contours, "border");
                       
                    });

                    HOperatorSet.SetColor(HMWindow, "blue");
                    HOperatorSet.DispObj(contours, HMWindow);

                }
                    
            }
            textMessage.Text = $"参考点匹配成功,共{ResultParamter.NccParamter.Row1.Length}个结果";
            ShowMatchResult = false;
        }
        #endregion

        #region  更新检测区域参数的命令


        public ICommand UpdateInsectRegionCommand
        {
            get { return (ICommand)GetValue(UpdateInsectRegionCommandProperty); }
            set { SetValue(UpdateInsectRegionCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UpdateInsectRegionCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UpdateInsectRegionCommandProperty =
            DependencyProperty.Register("UpdateInsectRegionCommand", typeof(ICommand), typeof(ProjectDisplayView), new PropertyMetadata(null));



        #endregion

        #endregion

        #region 绘制事件
        private void DrawReferPoint_Click(object sender, RoutedEventArgs e)
        {
            DrawRectangle("green");
        }

        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="color"></param>
        /// <param name="hTuples"></param>
        private async void DrawRectangle(string color)
        {
            textMessage.Text = "鼠标左键拖动开始绘制，右键结束绘制";

            HTuple[] hTuples = new HTuple[4];
            HObject drawRectangel = null;
            HTuple drawID = null;
            hsmart.HZoomContent = HSmartWindowControlWPF.ZoomContent.Off; //绘制期间禁止缩放
            HOperatorSet.SetColor(hsmart.HalconWindow, color); //设置绘制颜色

            //绘制矩形
            await Task.Run(() =>
            {
                HOperatorSet.DrawRectangle1(
                    hsmart.HalconWindow,
                    out hTuples[0],
                    out hTuples[1],
                    out hTuples[2],
                    out hTuples[3]
                );
                drawRectangel = hTuples.GenRectangle1(); //保存绘制对象
            });

            //根据绘制参数创建矩形对象并附加到窗口进行显示
            AttachDrawingObjectToWindow(color, hTuples);

            //恢复窗口缩放权限
            hsmart.HZoomContent = HSmartWindowControlWPF.ZoomContent.WheelBackwardZoomsIn;

            textMessage.Text = "绘制完成";
        }

        private void AttachDrawingObjectToWindow(string color, HTuple[] hTuples)
        {
            var drawObject = HDrawingObject.CreateDrawingObject(
                HDrawingObject.HDrawingObjectType.RECTANGLE1,
                hTuples
            );

            drawObject.SetDrawingObjectParams("color", color);

            var drawInfo = new ReferPointDrawInfo()
            {
                Color = color,
                HTuples = hTuples,
                DrawingObject = drawObject
            };

            drawObject.OnDrag(DrawObject_OnDrag); //绘制对象发生拖动时,刷新参考点坐标信息
            drawObject.OnResize(DrawObject_OnDrag); //绘制对象发生缩放时,刷新参考点坐标信息

            ReferPointDrawInfos.Add(drawInfo);
            HMWindow.AttachDrawingObjectToWindow(drawObject);
        }

        private void DrawObject_OnDrag(HDrawingObject obj, HWindow window, string type)
        {
            //刷新保存参考点绘制信息
            RefreshDrawObject(obj);
        }

        /// <summary>
        /// 刷新参考点的坐标信息
        /// </summary>
        /// <param name="drawingObject"></param>
        private void RefreshDrawObject(HDrawingObject drawingObject)
        {
            if (drawingObject == null)
                return;
            var hv_type = drawingObject.GetDrawingObjectParams("type"); //获取当前对象的绘制类型
            var htuples = drawingObject.GetHtuples(DrawShape.Rectangle);
            var drawInfo = ReferPointDrawInfos.FirstOrDefault(r =>
                r.DrawingObject != null && r.DrawingObject.ID == drawingObject.ID
            );
            if (drawInfo != null)
            {
                drawInfo.HTuples = htuples;
            }
        }
        #endregion

        #region 参考点参数更新事件
        private void UpdateReferPointParamter_Click(object sender, RoutedEventArgs e)
        {
            UpdateTemplateCommand?.Execute(this);
        }

        #endregion


        #region 绘制检测区域事件
        private void DrawInspectRegion_Click(object sender, RoutedEventArgs e)
        {
            DrawRectangle("red");
        }
        #endregion


        #region 更新检测区域事件
        private void UpdateInspectRegion_Click(object sender, RoutedEventArgs e)
        {
            UpdateInsectRegionCommand?.Execute(this);
        }
        #endregion

        #region 清空窗口事件

        /// <summary>
        /// 清空事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearWindow_Click(object sender, RoutedEventArgs e)
        {
            ClearWindowDisplay();
        }

        /// <summary>
        /// 清空窗口上的所有绘制和匹配显示
        /// </summary>
        private void ClearWindowDisplay()
        {
            if (ReferPointDrawInfos.Count > 0)
            {
                for (int i = 0; i < ReferPointDrawInfos.Count; i++)
                {
                    var obj = ReferPointDrawInfos[i];
                    var item = ReferPointDrawInfos[i].DrawingObject;
                    item.Dispose();
                    ReferPointDrawInfos.Remove(obj);
                }
            }

            HMWindow.ClearWindow();
            HMWindow.DispObj(EidtImage);
            textMessage.Text = "";
        }

        #endregion

       
    }
}
