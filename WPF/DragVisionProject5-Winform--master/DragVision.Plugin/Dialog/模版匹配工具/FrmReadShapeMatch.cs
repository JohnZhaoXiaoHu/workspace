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

namespace DragVision.Plugin.Dialog.模版匹配工具
{
    public partial class FrmReadShapeMatch : Form
    {
        public FrmReadShapeMatch(FlowNode flowNode)
        {
            InitializeComponent();
            node = flowNode;
        }

        private FlowNode node;
        private HTuple modleId = null;

        private void FrmReadShapeMatch_Load(object sender, EventArgs e) { }

        private void btnChooseRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "形状模板匹配文件|*.shm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textShapeModle.Text = openFileDialog.FileName;
                HOperatorSet.ReadShapeModel(openFileDialog.FileName, out modleId);
            }
        }

        private void btnExcuteComplete_Click(object sender, EventArgs e)
        {
            if (modleId != null)
            {
                node.OutputParam.ImageParam = node.InputParam.ImageParam;
                node.OutputParam.ResultParam = node.InputParam.ResultParam;
                node.OutputParam.CoordinateParam = node.InputParam.CoordinateParam;
                node.OutputParam.HandleParam = modleId;
                PluginFactory.PluginMessageAction?.Invoke("读取形状模板匹配完成");
                MessageBox.Show("读取形状模板匹配完成");
            }
        }
    }
}
