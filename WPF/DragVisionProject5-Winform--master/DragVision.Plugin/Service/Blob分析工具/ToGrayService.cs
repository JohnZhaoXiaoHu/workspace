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
    [DisplayName("转灰度图")]
    public  class ToGrayService:BasePluginService
    {
        public override void ShowPluginWindow(FlowNode node)
        {
           FrmToGray frm= new FrmToGray(node);
           frm.ShowDialog();
        }
    }
}
