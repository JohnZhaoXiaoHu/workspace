using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYBase
{
    public interface IPluginBase
    {
        void RunPlugin(); // 提供执行插件的接口
        void RunForm(); // 运行插件中对应窗口

        long ElseTime(); // 执行时间
    }
}
