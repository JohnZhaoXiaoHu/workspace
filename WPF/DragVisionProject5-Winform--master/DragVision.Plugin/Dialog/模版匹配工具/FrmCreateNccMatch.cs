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
using DragVision.Plugin.Params.模版匹配;
using HalconDotNet;

namespace DragVision.Plugin.Dialog.模版匹配工具
{
    public partial class FrmCreateNccMatch : Form
    {
        public FrmCreateNccMatch(FlowNode flowNode)
        {
            InitializeComponent();
            this.node = flowNode;
        }

        private HWindow hWindow;
        private FlowNode node;
        private HObject image;
        private HTuple nccModleID = null;
        private HObject nccRegion = null;
        private HObject reducedImage;

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void FrmCreateNccMatch_Load(object sender, EventArgs e)
        {
            hWindow = halconDisplayControl1.GetHWindow();
            if (node.InputParam != null && node.InputParam.ImageParam != null)
            {
                image = node.InputParam.ImageParam;
                hWindow.DispObj(image);
            }
            if (node.InputParam != null && node.InputParam.RegionParam != null)
            {
                nccRegion = node.InputParam.RegionParam;
            }
        }

        /// <summary>
        /// 创建NCC模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            if (nccRegion != null)
            {
                HOperatorSet.ReduceDomain(image, nccRegion, out reducedImage);

                CreateNccMatchParam param = new CreateNccMatchParam();
                param.NumLevels = cbNumLevels.Text;
                param.AngleStart = new HTuple(double.Parse(textAngleStart.Text)).TupleRad();
                param.AngleExtent = new HTuple(double.Parse(textAngleStop.Text)).TupleRad();
                param.AngleStep = new HTuple(double.Parse(textAngleStep.Text));
                param.Metric = cbMetric.Text;

                HOperatorSet.CreateNccModel(
                    reducedImage,
                    param.NumLevels,
                    param.AngleStart,
                    param.AngleExtent,
                    param.AngleStep,
                    param.Metric,
                    out nccModleID
                );

                hWindow.ClearWindow();
                hWindow.DispObj(reducedImage);
            }
        }

        /// <summary>
        /// 保存NCC模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            if (nccModleID != null)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "NCC Model|*.ncm";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    HOperatorSet.WriteNccModel(nccModleID, fileDialog.FileName);
                    MessageBox.Show($"{fileDialog.FileName}保存成功！");
                }
            }
        }

        /// <summary>
        /// 绘制ROI区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDrawROI_Click(object sender, EventArgs e)
        {
            HTuple[] hTuples = new HTuple[4];
            HWindow hWindow = halconDisplayControl1.GetHWindow();
            HOperatorSet.SetColor(hWindow, "red");
            await Task.Run(() =>
            {
                HOperatorSet.DrawRectangle1(
                    hWindow,
                    out hTuples[0],
                    out hTuples[1],
                    out hTuples[2],
                    out hTuples[3]
                );

                HOperatorSet.GenRectangle1(
                    out nccRegion,
                    hTuples[0],
                    hTuples[1],
                    hTuples[2],
                    hTuples[3]
                );

                
                HOperatorSet.SetDraw(hWindow, "margin");
                hWindow.DispObj(nccRegion);
            });
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            hWindow.ClearWindow();
            hWindow.DispObj(image);
            nccModleID = null;
        }


        /// <summary>
        /// 执行完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcuteComplete_Click(object sender, EventArgs e)
        {
            if(nccModleID != null)
            {
                node.OutputParam.ImageParam= image;
                node.OutputParam.HandleParam= nccModleID;
                node.OutputParam.RegionParam = nccRegion;
                PluginFactory.PluginViewAction?.Invoke(new List<HObject>() { reducedImage });
                PluginFactory.PluginMessageAction?.Invoke("NCC模板创建完成!");
                MessageBox.Show("NCC模板创建完成！");
            }
        }
    }
}
