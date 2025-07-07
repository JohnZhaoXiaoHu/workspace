using DragVision.Controls;
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

namespace DragVision.Plugin.Dialog.Blob分析工具
{
    public partial class FrmToGray : Form
    {
        public FrmToGray(FlowNode flowNode)
        {
            InitializeComponent();
            node = flowNode;
        }

        private FlowNode node;
        private HObject grayImage;

        private void FrmToGray_Load(object sender, EventArgs e)
        {
            if(node.OutputParam !=null&& node.OutputParam.ImageParam != null)
            {
                HWindow hWindow = halconDisplayControl1.GetHWindow();
                hWindow.DispObj(node.OutputParam.ImageParam);
            }
            else if (node.InputParam!=null&&node.InputParam.ImageParam != null)
            {
                HWindow hWindow = halconDisplayControl1.GetHWindow();
                hWindow.DispObj(node.InputParam.ImageParam);
            }
        }

        private void btnToGray_Click(object sender, EventArgs e)
        {
            if (node.InputParam.ImageParam != null)
            {
                var image = node.InputParam.ImageParam;
                HOperatorSet.Rgb1ToGray(image, out grayImage);
                HWindow hWindow = halconDisplayControl1.GetHWindow();
                hWindow.DispObj(grayImage);
            }
        }

        private void btnExcuteComplete_Click(object sender, EventArgs e)
        {
            if(grayImage != null)
            {
               
                node.OutputParam.ImageParam = grayImage;
                PluginFactory.PluginViewAction?.Invoke(new List<HObject>() { grayImage });
                PluginFactory.PluginMessageAction?.Invoke("灰度图生成成功");
                MessageBox.Show("灰度化完成!");
            }
        }
    }
}
