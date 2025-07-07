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

namespace DragVision.Plugin.Dialog.图像采集工具
{
    public partial class FrmHkImageCollect : Form
    {
        public FrmHkImageCollect(FlowNode flowNode)
        {
            InitializeComponent();
            node = flowNode;
        }

        private FlowNode node;
        private HImage image = null;

        private void FrmHkImageCollect_Load(object sender, EventArgs e)
        {
            if (node.OutputParam!=null&&node.OutputParam.ImageParam != null)
            {
                HWindow hWindow = halconDisplayControl1.GetHWindow();
                HObject currentImage = node.OutputParam.ImageParam;
                hWindow.DispObj(currentImage);
            }
        }

        private void btnLoadeImage_Click(object sender, EventArgs e)
        {
            HWindow hWindow = halconDisplayControl1.GetHWindow();

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "图像文件|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff;*.gif;*.pgm;*.ppm;*.pbm;";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                image = new HImage();
                image.ReadImage(fileDialog.FileName);
                hWindow.DispObj(image);
            }
        }

        private void btnExcuteComplete_Click(object sender, EventArgs e)
        {
            node.OutputParam.ImageParam = image;

            PluginFactory.PluginViewAction?.Invoke(new List<HObject>() { image });

            PluginFactory.PluginMessageAction?.Invoke("图像采集执行完成");

            MessageBox.Show("图像采集完成");


        }
    }
}
