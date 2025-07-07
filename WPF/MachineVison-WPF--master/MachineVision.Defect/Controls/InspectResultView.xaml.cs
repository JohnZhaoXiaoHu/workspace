using System;
using System.Collections.Generic;
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
using MachineVision.Defect.Models.Result;

namespace MachineVision.Defect.Controls
{
    /// <summary>
    /// InspectResultView.xaml 的交互逻辑
    /// </summary>
    public partial class InspectResultView : UserControl
    {
        public InspectResultView()
        {
            InitializeComponent();
        }

        #region 依赖属性


        #region 当前的窗口句柄


        public HWindow EditWindow
        {
            get { return (HWindow)GetValue(EditWindowProperty); }
            set { SetValue(EditWindowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditWindow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditWindowProperty = DependencyProperty.Register(
            "EditWindow",
            typeof(HWindow),
            typeof(InspectResultView),
            new PropertyMetadata(new HWindow())
        );

        #endregion

      


        #region 检测结果

        public DeformableInspectResult InspectResult
        {
            get { return (DeformableInspectResult)GetValue(InspectResultProperty); }
            set { SetValue(InspectResultProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InspectResultProperty =
            DependencyProperty.Register(
                "InspectResult",
                typeof(DeformableInspectResult),
                typeof(InspectResultView),
                new PropertyMetadata(null,OnResultChanged)
            );

        private static void OnResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            InspectResultView inspectResultView=d as InspectResultView;
            if (inspectResultView != null)
            {
                inspectResultView.ShowResult((DeformableInspectResult)e.NewValue);
            }
        }
        private void ShowResult(DeformableInspectResult result)
        {
            

           if(result!=null)
            {
                result.EditWindow = hSmart.HalconWindow;
                hSmart.HalconWindow.ClearWindow();

                SetMSG(result.IsNoDeformable, result.Message);

                if(result.DefomableCount<=0)
                {
                    SetImage(result.TeamplateImage);
                }
                else
                {
                    SetImage(result.RectifiedImage);
                }

                ShowDeformableRegion(result.DeformableRegion);
            }

            
        }

        #region 中间方法,显示提示信息
        private void SetMSG(bool isNoDefomable,string msg)
        {
            if (isNoDefomable)
            {
                textMSG.Foreground = Brushes.LightGreen;
            }
            else
            {
                textMSG.Foreground = Brushes.Red;
            }
            textMSG.Text = msg;
        }
        #endregion

        #region 中间方法,当前的结果图片

        private void SetImage(HObject image)
        {
            if (image != null)
            {
                
                hSmart.HalconWindow.SetPart(0, 0, -2, -2);
                hSmart.HalconWindow.DispObj(image);
            }
                
            EditWindow = hSmart.HalconWindow;
        }

        #endregion


        #region 中间方法,缺陷区域显示


        /// <summary>
        /// 显示缺陷区域
        /// </summary>
        /// <param name="region"></param>
        private void ShowDeformableRegion(HObject region)
        {
            if (region == null)
                return;

            HOperatorSet.SetColor(EditWindow, "red");
            EditWindow.DispObj(region);
        }

        #endregion

        #endregion


        #region 添加训练图片的命令




        public ICommand AddTrainImageCommand
        {
            get { return (ICommand)GetValue(AddTrainImageCommandProperty); }
            set { SetValue(AddTrainImageCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddTrainImageCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddTrainImageCommandProperty =
            DependencyProperty.Register("AddTrainImageCommand", typeof(ICommand), typeof(InspectResultView), new PropertyMetadata(null));





        #endregion

        #endregion

        #region 用户控件加载事件
        private void Loaded_Click(object sender, RoutedEventArgs e)
        {
            /*EditWindow = hSmart.HalconWindow;*/
        }
        #endregion


        #region 训练图片事件
        private void AddTrainImage_Click(object sender, RoutedEventArgs e)
        {
            if(InspectResult.DefomableCount<=0)
            {
                MessageBox.Show("未产生形变图像,模板图像不可用于模型训练");
                return;
            }
            AddTrainImageCommand?.Execute(InspectResult);
        }
        #endregion
    }
}
