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
    public partial class FrmReadNccMatch : Form
    {
        public FrmReadNccMatch(FlowNode flowNode)
        {
            InitializeComponent();
            node = flowNode;
        }

        private FlowNode node;
        private HTuple nccModleID = null;

        private void FrmReadNccMatch_Load(object sender, EventArgs e) { }

        private void btnChooseRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Ncc模板文件|*.ncm";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                HOperatorSet.ReadNccModel(fileDialog.FileName, out nccModleID);
                textNccModle.Text = fileDialog.FileName;
            }
        }

        private void btnExcuteComplete_Click(object sender, EventArgs e)
        {
            if (nccModleID != null)
            {
                node.OutputParam.ImageParam = node.InputParam.ImageParam;
                node.OutputParam.HandleParam = nccModleID;
                PluginFactory.PluginMessageAction?.Invoke("读取NCC模版成功!");
                MessageBox.Show("读取NCC模版成功!");
            }
        }
    }
}
