using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zhaoxi.NewVision.Editor.helper;
using Zhaoxi.NewVision.Editor.mycontrols;

namespace Zhaoxi.Vision.Flow.Proj.VFrame
{
    public partial class CreateModelFrm : Form
    {
        private FlowNode preNode;
        private FlowNode currentNode;
        private HWindow hv_Handle;

        /// <summary>
        /// 创建模板窗口的构造函数
        /// </summary>
        /// <param name="preNode"></param>
        /// <param name="currentNode"></param>
        public CreateModelFrm(FlowNode currentNode)
        {
            InitializeComponent();
            this.preNode = FlowNodeTool.GetPreNode(currentNode);
            this.currentNode = currentNode;
        }
        /// <summary>
        /// 加载模板图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateModelFrm_Load(object sender, EventArgs e)
        {
            
            myModelHW.DisplayImage(preNode.Output);
        }
        /// <summary>
        /// 创建模板的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            HTuple hv_ModelID = null;
            // 获取设置的参数
            var numLevels = new HTuple(cmbNumLevels.Text);
            var startAngle = new HTuple(Convert.ToInt32(txtStartangle.Text));
            var extentAngle = new HTuple(Convert.ToInt32(txtExtentAngle.Text));
            var stepAngle = new HTuple(txtStepangle.Text);
            var optiamize = txtOptimization.Text;
            var metric = txtMetric.Text;
            var constrast = new HTuple(Convert.ToInt32(txtContrast.Text));
            var minConstrast = new HTuple(Convert.ToInt32(txtMincontrast.Text)); 

            var modelImg = preNode.Output;
            // 创建模板
            HOperatorSet.CreateShapeModel(modelImg, numLevels, startAngle.TupleRad(), extentAngle.TupleRad()
                , stepAngle, optiamize, metric, constrast, minConstrast, out hv_ModelID);
            // 获取对应的轮廓
            HOperatorSet.GetShapeModelContours(out HObject ho_ModelContours, hv_ModelID, 1);
            // 保存模板及轮廓
            HOperatorSet.WriteShapeModel(hv_ModelID, "model.shm");
            HOperatorSet.WriteObject(ho_ModelContours, "model_xld");
            // 设置输入与输出
            currentNode.Output = preNode.Output;
            MessageBox.Show("创建模板成功~~");
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
