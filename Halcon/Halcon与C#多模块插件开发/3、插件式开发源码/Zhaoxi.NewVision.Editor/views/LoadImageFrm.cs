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
using Zhaoxi.NewVision.Editor.mycontrols;

namespace Zhaoxi.Vision.Flow.Proj.VFrame
{
    public partial class LoadImageFrm : Form
    {
        private FlowNode currentNode;
        private FlowNode preNode;
        private HImage himg;

        public LoadImageFrm(FlowNode preNode, FlowNode currentNode)
        {
            InitializeComponent();
            this.currentNode = currentNode;
            this.preNode = preNode;
        }
        /// <summary>
        /// 初始化当前窗口的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadImageFrm_Load(object sender, EventArgs e)
        {
            if (currentNode.Input != null) 
            {
                // 把图像显示到当前的窗口
                myhWindowControl1.DisplayImage(currentNode.Input);
            }
        }

        /// <summary>
        /// 加载图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "加载图像 | *.png;*.jpg;*.bmp";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var url = dialog.FileName;
                himg = new HImage(url);

                // 把图像显示到当前的窗口
                myhWindowControl1.DisplayImage(himg);
            }
        }

        /// <summary>
        /// 设置当前节点输入和输出过程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFinish_Click(object sender, EventArgs e)
        {
            if (preNode != null)
            {
                // 设置输入
                currentNode.Input = preNode.Output;
                currentNode.Outputs = preNode.Outputs;
            }
            else
            {
                currentNode.Input = himg;
            }


            // 设置输出
            currentNode.Output = himg;

            Dispose();
        }
    }
}
