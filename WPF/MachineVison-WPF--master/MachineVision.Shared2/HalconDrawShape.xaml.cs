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
using MachineVision.Shared2.Extensions;
using Microsoft.Win32;

namespace MachineVision.Shared2
{
    /// <summary>
    /// HalconDrawShape.xaml 的交互逻辑
    /// </summary>
    public partial class HalconDrawShape : UserControl
    {
        public HalconDrawShape()
        {
            InitializeComponent();
        }

        #region 依赖属性

        /// <summary>
        /// 要操作的图像类
        /// </summary>
        public HImage EditImage
        {
            get { return (HImage)GetValue(EditImageProperty); }
            set { SetValue(EditImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditImageProperty = DependencyProperty.Register(
            "EditImage",
            typeof(HImage),
            typeof(HalconDrawShape),
            new PropertyMetadata(new HImage())
        );

        /// <summary>
        /// 当前的Halcon窗口
        /// </summary>

        public HWindow HMWindow
        {
            get { return (HWindow)GetValue(HMWindowProperty); }
            set { SetValue(HMWindowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HMWindow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HMWindowProperty = DependencyProperty.Register(
            "HMWindow",
            typeof(HWindow),
            typeof(HalconDrawShape),
            new PropertyMetadata(null)
        );

        /// <summary>
        /// 已绘制的区域信息
        /// </summary>
        public ObservableCollection<DrawObjectInfo> DrawObjectInfos
        {
            get { return (ObservableCollection<DrawObjectInfo>)GetValue(DrawObjectInfosProperty); }
            set { SetValue(DrawObjectInfosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DrawObjectInfosProperty =
            DependencyProperty.Register(
                "DrawObjectInfos",
                typeof(ObservableCollection<DrawObjectInfo>),
                typeof(HalconDrawShape),
                new PropertyMetadata(null)
            );

        /// <summary>
        /// 依赖属性, 用于传递掩膜图像
        /// </summary>
        public HObject MaskObject
        {
            get { return (HObject)GetValue(MaskObjectProperty); }
            set { SetValue(MaskObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaskObject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaskObjectProperty = DependencyProperty.Register(
            "MaskObject",
            typeof(HObject),
            typeof(HalconDrawShape),
            new PropertyMetadata(null)
        );

        /// <summary>
        /// 依赖属性, 用于传递模板匹配的结果
        /// </summary>


        public TeamplateMatchResult MatchResult
        {
            get { return (TeamplateMatchResult)GetValue(MatchResultProperty); }
            set { SetValue(MatchResultProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MatchResult.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MatchResultProperty = DependencyProperty.Register(
            "MatchResult",
            typeof(TeamplateMatchResult),
            typeof(HalconDrawShape),
            new PropertyMetadata(null, MathResultChanged)
        );

        private static void MathResultChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e
        )
        {
            HalconDrawShape h = d as HalconDrawShape;
            if (h != null)
            {
                h.DisplapyMatchResult(e.NewValue as TeamplateMatchResult);
            }
        }

        /// <summary>
        /// 根据模板匹配的结果, 显示匹配结果
        /// </summary>
        /// <param name="t"></param>
        private void DisplapyMatchResult(TeamplateMatchResult t)
        {
            if (t.IsSucess)
            {
                //设置显示颜色
                HOperatorSet.SetColor(hSmart.HalconWindow, "blue");

                //清空
                ClearAll();

                //标记匹配结果
                foreach (var item in t.Results)
                {
                    //显示中心点
                    if (t.IsShowCenter)
                        HOperatorSet.DispCross(
                            hSmart.HalconWindow,
                            item.Row,
                            item.Cloumn,
                            60,
                            item.Angle
                        );

                    //显示文本
                    if (t.IsShowText)
                        //disp_message(hv_WindowHandle, "你好啊，傻帽", "window", 12, 12, "black", "true");
                        hSmart.HalconWindow.disp_message(
                            $"坐标:({Math.Round(item.Row, 2)},{Math.Round(item.Cloumn, 2)})",
                            "image",
                            item.Row,
                            item.Cloumn + 10,
                            "black",
                            "true"
                        );

                    //显示匹配区域轮廓
                    if (t.IsShowMatchRegion)
                        hSmart.HalconWindow.DispObj(item.Contours);
                }
            }
            t.IsSucess = false;
        }

        #endregion


        /// <summary>
        /// 存放已经绘制的区域的列表
        /// </summary>
        public ObservableCollection<DrawObjectInfo> drawObjectInfos =
            new ObservableCollection<DrawObjectInfo>();

        /* HImage image=new HImage();*/

        private void LoadImage_Click(object sender, RoutedEventArgs e)
        {
            HMWindow = hSmart.HalconWindow;
            FileDialog fileDialog = new OpenFileDialog();
            bool result = (bool)fileDialog.ShowDialog();
            if (result && !string.IsNullOrEmpty(fileDialog.FileName))
            {
                EditImage.ReadImage(fileDialog.FileName);
                hSmart.HalconWindow.SetPart(0, 0, -2, -2);
                hSmart.HalconWindow.DispObj(EditImage);
            }
        }

        #region 绘制形状事件
        /// <summary>
        /// 绘制矩形事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DrawRectancle_Click(object sender, RoutedEventArgs e)
        {
            HTuple[] hTuples = new HTuple[4];
            DrawShape(Shape.Rectangle, hTuples);
        }

        /// <summary>
        /// 绘制圆形事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DrawCircle_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(Shape.Circle, new HTuple[3]);
        }

        /// <summary>
        /// 绘制椭圆事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawEllipse_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(Shape.Ellipse, new HTuple[5]);
        }

        /// <summary>
        /// 绘制任意区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawRegion_Click(object sender, RoutedEventArgs e)
        {
            HTuple[] hTuples = null;
            DrawShape(Shape.Region, hTuples);
        }
        #endregion


        #region 绘制屏蔽区域事件

        private bool isMask;

        /// <summary>
        /// 绘制圆形屏蔽区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CircleMask_Click(object sender, RoutedEventArgs e)
        {
            if (!isMask)
            {
                isMask = true;
                DrawShape(Shape.Circle, new HTuple[3]);
            }
        }

        /// <summary>
        /// 绘制矩形屏蔽区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RectangleMask_Click(object sender, RoutedEventArgs e)
        {
            if (!isMask)
            {
                isMask = true;
                DrawShape(Shape.Rectangle, new HTuple[4]);
            }
        }

        /// <summary>
        /// 绘制椭圆屏蔽区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ElliPseMask_Click(object sender, RoutedEventArgs e)
        {
            if (!isMask)
            {
                isMask = true;
                DrawShape(Shape.Ellipse, new HTuple[5]);
            }
        }

        /// <summary>
        /// 任意区域屏蔽区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionMask_Click(object sender, RoutedEventArgs e)
        {
            if (!isMask)
            {
                isMask = true;
                HTuple[] hTuples = null;
                DrawShape(Shape.Region, hTuples);
            }
        }
        #endregion

        #region 绘制函数
        /// <summary>
        /// 绘制函数
        /// </summary>
        /// <param name="shape">要绘制的形状</param>
        /// <param name="hTuples">绘制的坐标参数</param>
        private async void DrawShape(Shape shape, HTuple[] hTuples)
        {
            textDrawInfo.Text = "鼠标左键拖动开始绘制，鼠标右键结束绘制!";

            HObject ho_shape,
                ho_GenShape;
            HOperatorSet.GenEmptyObj(out ho_shape);
            HOperatorSet.GenEmptyObj(out ho_GenShape);

            if (!isMask)
                //设置绘制颜色为红色
                HOperatorSet.SetColor(hSmart.HalconWindow, "red");
            else
                HOperatorSet.SetColor(hSmart.HalconWindow, "green");

            //绘制区域期间禁止缩放
            hSmart.HZoomContent = HSmartWindowControlWPF.ZoomContent.Off;

            //根据不同的形状进行不同的绘制
            await Task.Run(() =>
            {
                switch (shape)
                {
                    case Shape.Rectangle:
                        HOperatorSet.DrawRectangle1(
                            hSmart.HalconWindow,
                            out hTuples[0],
                            out hTuples[1],
                            out hTuples[2],
                            out hTuples[3]
                        );
                        ho_GenShape = hTuples.GenRectangle1();
                        if (ho_GenShape != null && !isMask)
                        {
                            drawObjectInfos.Add(
                                new DrawObjectInfo()
                                {
                                    DrawShape = Shape.Rectangle,
                                    DrawHTuples = hTuples,
                                    ShapeObject = ho_GenShape
                                }
                            );
                        }

                        break;
                    case Shape.Circle:
                        HOperatorSet.DrawCircle(
                            hSmart.HalconWindow,
                            out hTuples[0],
                            out hTuples[1],
                            out hTuples[2]
                        );
                        ho_GenShape = hTuples.GenCircle();
                        if (ho_GenShape != null && !isMask)
                            drawObjectInfos.Add(
                                new DrawObjectInfo()
                                {
                                    DrawShape = Shape.Circle,
                                    DrawHTuples = hTuples,
                                    ShapeObject = ho_GenShape
                                }
                            );
                        break;
                    case Shape.Ellipse:
                        HOperatorSet.DrawEllipse(
                            hSmart.HalconWindow,
                            out hTuples[0],
                            out hTuples[1],
                            out hTuples[2],
                            out hTuples[3],
                            out hTuples[4]
                        );
                        ho_GenShape = hTuples.GenEllipse();
                        if (ho_GenShape != null && !isMask)
                            drawObjectInfos.Add(
                                new DrawObjectInfo()
                                {
                                    DrawShape = Shape.Ellipse,
                                    DrawHTuples = hTuples,
                                    ShapeObject = ho_GenShape
                                }
                            );
                        break;
                    case Shape.Region:
                        HOperatorSet.DrawRegion(out ho_GenShape, hSmart.HalconWindow);
                        if (ho_GenShape != null && !isMask)
                            drawObjectInfos.Add(
                                new DrawObjectInfo()
                                {
                                    DrawShape = Shape.Region,
                                    ShapeObject = ho_GenShape
                                }
                            );
                        break;
                }
            });

            DrawObjectInfos = drawObjectInfos;

            //还窗口缩放权限
            hSmart.HZoomContent = HSmartWindowControlWPF.ZoomContent.WheelBackwardZoomsIn;

            //显示绘制结果
            if (ho_GenShape != null)
            {
                HObject ho_Contours = null;
                HOperatorSet.GenEmptyObj(out ho_Contours);
                HOperatorSet.GenContourRegionXld(ho_GenShape, out ho_Contours, "border");
                HOperatorSet.DispObj(ho_Contours, hSmart.HalconWindow);
                if (isMask)
                {
                    MaskObject = ho_GenShape;
                }
            }

            if (!isMask)
                textDrawInfo.Text = $"当前已绘制:{DrawObjectInfos.Count}";
            else
                textDrawInfo.Text = $"屏蔽区域已经绘制完成:{shape.ToString()}";

            isMask = false;
        }
        #endregion


        #region 清除绘制

        //清除所有绘制区域
        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            if (drawObjectInfos.Count > 0)
            {
                //清除绘制列表存放信息
                drawObjectInfos.Clear();

                textDrawInfo.Text = $"当前已绘制:{DrawObjectInfos.Count}";
            }

            //清除窗口上的所有区域
            hSmart.HalconWindow.ClearWindow();

            //在窗口上显示图像
            hSmart.HalconWindow.DispObj(EditImage);
        }
        #endregion
    }
}
