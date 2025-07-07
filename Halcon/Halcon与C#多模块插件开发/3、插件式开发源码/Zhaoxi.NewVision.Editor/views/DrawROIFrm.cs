using HalconDotNet;
using Zhaoxi.NewVision.Editor.helper;
using Zhaoxi.NewVision.Editor.mycontrols;

namespace Zhaoxi.Vision.Flow.Proj.VFrame
{
    public partial class DrawROIFrm : Form
    {
        private FlowNode currentNode;
        private FlowNode preNode;
        private double row1;
        private double column1;
        private double row2;
        private double column2;
        private HWindow hv_Handle;
        private HObject ImageReduced;
        private HObject ImagePart;

        public DrawROIFrm()
        {
            InitializeComponent();
        }

        public DrawROIFrm(FlowNode currentNode) : this()
        {
            this.currentNode = currentNode;
            this.preNode = FlowNodeTool.GetPreNode(currentNode);
        }

        private void DrawROIFrm_Load(object sender, EventArgs e)
        {
            hv_Handle = roiWd.HalconWindow;
            hv_Handle.SetColor("yellow");
            hv_Handle.SetLineWidth(2);
            hv_Handle.SetDraw("margin");
            if (preNode != null) 
            {
                // 获取输出的图像
                roiWd.DisplayImage(preNode.Output);
            }
            
        }
        /// <summary>
        /// 绘制ROI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDrawROI_Click(object sender, EventArgs e)
        {
            roiWd.Focus();
            // 点击按钮后按住鼠标左键绘制矩形ROI，右键结束绘制
            hv_Handle.DrawRectangle1(out row1, out column1, out row2, out column2);
            // 显示绘制后的ROI
            hv_Handle.DispRectangle1(row1, column1, row2, column2);
        }
        /// <summary>
        /// 修改模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            // 清空窗体内容
            hv_Handle.ClearWindow();
            // 显示输出的图像
            roiWd.DisplayImage(preNode.Output);
            // 执行绘制矩形
            roiWd.Focus();
            // 使用halcon交互式的方式在同一个ROI的位置重新绘制一个ROI
            hv_Handle.DrawRectangle1Mod(row1, column1, row2, column2, out row1, out column1, out row2, out column2);
            // 显示重新绘制的ROI
            hv_Handle.DispRectangle1(row1, column1, row2, column2);
        }
        /// <summary>
        /// 截取模板图像显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDropModelImage_Click(object sender, EventArgs e)
        {
            // 清空窗体内容
            hv_Handle.ClearWindow();
            // 生成矩形
            HOperatorSet.GenRectangle1(out HObject rect, row1, column1, row2, column2);
            // 显示模板图像
            HOperatorSet.ReduceDomain(preNode.Output, rect, out ImageReduced);
            HOperatorSet.CropDomain(ImageReduced, out ImagePart);
            // 显示输出的图像
            roiWd.DisplayImage(ImagePart);
            
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            // 设置当前节点的输入与输出
            currentNode.Input = preNode.Output;
            currentNode.Output = ImagePart;
            currentNode.RoiOutput = [row1, column1, row2, column2];

            Dispose();
        }
    }
}
