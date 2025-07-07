using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DragVision.Controls;
using HalconDotNet;

namespace DragVision.Plugin.Dialog.ROI工具
{
    public partial class FrmDrawROI : Form
    {
        public FrmDrawROI(FlowNode flowNode)
        {
            InitializeComponent();
            node = flowNode;
        }

        private FlowNode node;
        private HObject image;
        private HWindow hWindow;
        private HTuple[] roiParam = null;
        private ROIType roiType;
        private HObject roiRegion = null;

        private void FrmDrawROI_Load(object sender, EventArgs e)
        {
            hWindow = halconDisplayControl1.GetHWindow();
           
            if (node.InputParam != null && node.InputParam.ImageParam != null)
            {
                image = node.InputParam.ImageParam;
                hWindow.DispObj(node.InputParam.ImageParam);
            }
        }

        /// <summary>
        /// 绘制ROI
        /// </summary>
        private async void DrawROI(ROIType rOIType)
        {
            HOperatorSet.SetColor(hWindow, "red");
            await Task.Run(() =>
            {
                switch (rOIType)
                {
                    case ROIType.Circle:
                        roiParam = new HTuple[3];
                        HOperatorSet.DrawCircle(
                            hWindow,
                            out roiParam[0],
                            out roiParam[1],
                            out roiParam[2]
                        );
                        HOperatorSet.GenCircle(
                            out roiRegion,
                            roiParam[0],
                            roiParam[1],
                            roiParam[2]
                        );
                        break;
                    case ROIType.Rectangle1:
                        roiParam = new HTuple[4];
                        HOperatorSet.DrawRectangle1(
                            hWindow,
                            out roiParam[0],
                            out roiParam[1],
                            out roiParam[2],
                            out roiParam[3]
                        );
                        HOperatorSet.GenRectangle1(
                            out roiRegion,
                            roiParam[0],
                            roiParam[1],
                            roiParam[2],
                            roiParam[3]
                        );
                        break;
                    case ROIType.Ellipse:
                        roiParam = new HTuple[5];
                        HOperatorSet.DrawEllipse(
                            hWindow,
                            out roiParam[0],
                            out roiParam[1],
                            out roiParam[2],
                            out roiParam[3],
                            out roiParam[4]
                        );
                        HOperatorSet.GenEllipse(
                            out roiRegion,
                            roiParam[0],
                            roiParam[1],
                            roiParam[2],
                            roiParam[3],
                            roiParam[4]
                        );
                        break;
                }
            });
            roiType = rOIType;

            HOperatorSet.SetDraw(hWindow, "margin");
            hWindow.DispObj(image);
            hWindow.DispObj(roiRegion);
        }

            /// <summary>
            /// 绘制ROI按钮事件
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
        private void btnDraw_Click(object sender, EventArgs e)
        {
            if(rbCircle.Checked)
            {
                DrawROI(ROIType.Circle);
            }
            else if(rbRectangle.Checked)
            {
                DrawROI(ROIType.Rectangle1);
            }
            else if(rbEliipse.Checked)
            {
                DrawROI(ROIType.Ellipse);
            }
        }

        /// <summary>
        /// 清除ROI按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e) 
        {
            hWindow.ClearWindow();
            hWindow.DispObj(image);
            roiRegion = null;
            roiParam= null;
        }

        /// <summary>
        /// 完成按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComplete_Click(object sender, EventArgs e)
        {
            node.OutputParam.ROIType= roiType;
            node.OutputParam.CoordinateParam= roiParam;
            node.OutputParam.ImageParam=image;
            if (roiRegion != null)
            {
                node.OutputParam.RegionParam = roiRegion;
                PluginFactory.PluginViewAction?.Invoke(new List<HObject>() { roiRegion });
                PluginFactory.PluginMessageAction?.Invoke("ROI区域绘制成功");
                MessageBox.Show("ROI区域绘制完成!");
            }
        }
    }
}
