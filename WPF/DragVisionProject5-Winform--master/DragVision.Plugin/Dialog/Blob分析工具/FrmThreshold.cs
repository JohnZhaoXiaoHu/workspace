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

namespace DragVision.Plugin.Dialog.Blob分析工具
{
    public partial class FrmThreshold : Form
    {
        public FrmThreshold(FlowNode flowNode)
        {
            InitializeComponent();
            this.node = flowNode;
        }

        private FlowNode node;
        private HObject thresholdRegion;

        private void FrmThreshold_Load(object sender, EventArgs e)
        {
            HWindow hWindow = halconDisplayControl1.GetHWindow();
            if (node.OutputParam != null && node.OutputParam.ImageParam != null)
            {
                hWindow.DispObj(node.OutputParam.RegionParam);
            }
            else if (node.InputParam != null && node.InputParam.ImageParam != null)
            {
                hWindow.DispObj(node.InputParam.ImageParam);
            }
        }

        private bool DoThreshold(int minValue, int maxValue)
        {
            if (maxValue > minValue)
            {
               try
                {
                    HOperatorSet.Threshold(
                       node.InputParam.ImageParam,
                       out thresholdRegion,
                       minValue,
                       maxValue
                   );
                        HWindow hWindow = halconDisplayControl1.GetHWindow();
                        hWindow.DispObj(thresholdRegion);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("二值化失败，请确认是不是灰度图像"+ex.Message);
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private void trackBar_ValueChanged(object sender, EventArgs e) 
        {
            HWindow hWindow= halconDisplayControl1.GetHWindow();
            HOperatorSet.SetColor(hWindow,"red");
            textMinGray.Text= trackBarMinGray.Value.ToString();
            textMaxGray.Text = trackBarMaxGray.Value.ToString();
            DoThreshold(trackBarMinGray.Value, trackBarMaxGray.Value);
        }

        private void btnExcuteComplete_Click(object sender, EventArgs e) 
        {
            
           bool result= DoThreshold(trackBarMinGray.Value, trackBarMaxGray.Value);
           if (result)
            {
                node.OutputParam.RegionParam= thresholdRegion;
                node.OutputParam.ImageParam = node.InputParam.ImageParam;
                PluginFactory.PluginViewAction?.Invoke(new List<HObject>() { thresholdRegion });
                PluginFactory.PluginMessageAction?.Invoke("二值化完成");
                MessageBox.Show("二值化完成");
            }
        }
    }
}
