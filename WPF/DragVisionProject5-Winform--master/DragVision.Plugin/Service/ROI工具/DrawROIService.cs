using DragVision.Controls;
using DragVision.Plugin.Dialog.ROI工具;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragVision.Plugin.Service.ROI工具
{
    [Category("ROI工具")]
    [DisplayName("绘制ROI")]
    public class DrawROIService:BasePluginService
    {
        public override void ShowPluginWindow(FlowNode node)
        {
            FrmDrawROI frm = new FrmDrawROI(node);
            frm.ShowDialog();
        }
    }
}
