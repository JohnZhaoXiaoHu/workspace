using DragVision.Controls;
using DragVision.Plugin.Dialog.模版匹配工具;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragVision.Plugin.Service.模版匹配工具
{
    [Category("模版匹配工具")]
    [DisplayName("创建形状模板")]
    public class CreateShapeMatchService:BasePluginService
    {
        public override void ShowPluginWindow(FlowNode node)
        {
            FrmCreateShapeMatchService frm= new FrmCreateShapeMatchService(node);
            frm.ShowDialog();
        }
    }
}
