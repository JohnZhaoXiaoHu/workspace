using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYPlugin
{
    /// <summary>
    /// 插件信息类
    /// </summary>
    public class PluginInfo
    {
        public string PluginCategory { get; set; } // 插件类别
        public string PluginName { get; set; } // 插件名称，必须唯一
        public Type PluginType { get; set; } // 插件类型
    }
}
