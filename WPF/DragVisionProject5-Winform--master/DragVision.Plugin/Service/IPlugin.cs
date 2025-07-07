using DragVision.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragVision.Plugin.Service
{
    /// <summary>
    /// 插件服务接口
    /// </summary>
    public interface IPlugin
    {
        public void RunProcess();

        public void ShowPluginWindow(FlowNode node);
    }
}
