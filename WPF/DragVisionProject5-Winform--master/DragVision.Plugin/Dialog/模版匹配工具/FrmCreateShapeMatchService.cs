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
    public partial class FrmCreateShapeMatchService : Form
    {
        public FrmCreateShapeMatchService(FlowNode flowNode)
        {
            InitializeComponent();
            node = flowNode;
        }

        private FlowNode node;
        private HObject image;
        private HTuple shapeModelID;
        private HObject shapeRegion;
        private HObject imagePart;

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCreateShapeMatchService_Load(object sender, EventArgs e)
        {
            if (node.InputParam != null && node.InputParam.ImageParam != null)
            {
                HWindow hWindow = halconDisplayControl1.GetHWindow();
                hWindow.DispObj(node.InputParam.ImageParam);
                image = node.InputParam.ImageParam;
                shapeRegion = node.InputParam.RegionParam;
            }
        }

        /// <summary>
        /// 创建模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            CreateShapeMatchParam param = new CreateShapeMatchParam();
            param.NumLevels = cbNumLevels.Text;
            param.AngleStart = new HTuple(double.Parse(textAngleStart.Text)).TupleRad();
            param.AngleExtent = new HTuple(double.Parse(textAngleStop.Text)).TupleRad();
            param.AngleStep = new HTuple(double.Parse(textAngleStep.Text));
            param.Optimization = cbOptimization.Text;
            param.Metric = cbMetric.Text;
            param.Contrast = cbMinContrast.Text;
            param.MinContrast = cbMinContrast.Text;

            if (shapeRegion != null)
            {
                HOperatorSet.ReduceDomain(image, shapeRegion, out imagePart);
                HWindow hWindow = halconDisplayControl1.GetHWindow();
                hWindow.ClearWindow();
                hWindow.DispObj(imagePart);

                HOperatorSet.CreateShapeModel(
                    imagePart,
                    param.NumLevels,
                    param.AngleStart,
                    param.AngleExtent,
                    param.AngleStep,
                    param.Optimization,
                    param.Metric,
                    param.Contrast,
                    param.MinContrast,
                    out shapeModelID
                );
            }
        }

        /// <summary>
        /// 清除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            shapeModelID = null;
            HWindow hWindow = halconDisplayControl1.GetHWindow();
            hWindow.ClearWindow();
            hWindow.DispObj(image);
        }

        /// <summary>
        /// 执行完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcuteComplete_Click(object sender, EventArgs e)
        {
            if (shapeModelID != null)
            {
                node.OutputParam.HandleParam = shapeModelID;
                node.OutputParam.ImageParam = image;
                node.OutputParam.RegionParam = node.InputParam.RegionParam;
                PluginFactory.PluginViewAction?.Invoke(new List<HObject>() { imagePart }); //视图显示模板图像
                PluginFactory.PluginMessageAction?.Invoke("形状匹配模板创建成功!");
                MessageBox.Show("形状匹配模板创建成功!");
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
                    out shapeRegion,
                    hTuples[0],
                    hTuples[1],
                    hTuples[2],
                    hTuples[3]
                );

                HOperatorSet.SetDraw(hWindow, "margin");
                hWindow.DispObj(shapeRegion);
            });
        }

        /// <summary>
        /// 保存模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            if (shapeModelID != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Halcon Shape Model (*.shm)|*.shm";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    HOperatorSet.WriteShapeModel(shapeModelID, saveFileDialog.FileName);
                    MessageBox.Show($"{saveFileDialog.FileName}保存成功!");
                }
            }
        }

        private void halconDisplayControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
