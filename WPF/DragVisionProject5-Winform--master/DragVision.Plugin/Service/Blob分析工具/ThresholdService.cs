using DragVision.Controls;
using DragVision.Plugin.Dialog.Blob分析工具;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragVision.Plugin.Service.Blob分析工具
{
    [Category("Blob分析工具")]
    [DisplayName("二值化")]
    public class ThresholdService:BasePluginService
    {
        public override void ShowPluginWindow(FlowNode node)
        {
           FrmThreshold frm = new FrmThreshold(node);
           frm.ShowDialog();
        }
    }
}
