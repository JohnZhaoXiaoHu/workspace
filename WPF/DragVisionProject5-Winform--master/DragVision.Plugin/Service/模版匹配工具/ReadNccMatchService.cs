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
    [DisplayName("读取NCC模板")]
    public class ReadNccMatchService:BasePluginService
    {
        public override void ShowPluginWindow(FlowNode node)
        {
            FrmReadNccMatch frm = new FrmReadNccMatch(node);
            frm.ShowDialog();
        }
    }
}
