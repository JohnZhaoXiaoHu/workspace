using DragVision.Controls;
using DragVision.Plugin.Dialog.图像采集工具;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragVision.Plugin.Service.图像采集工具
{
    [Category("图像采集工具")]
    [DisplayName("海康相机图像采集")]
    public class HKImageCollectionService:BasePluginService
    {
        public override void ShowPluginWindow(FlowNode node)
        {
            FrmHkImageCollect frm = new FrmHkImageCollect(node);
            frm.ShowDialog();
        }
    }
}
