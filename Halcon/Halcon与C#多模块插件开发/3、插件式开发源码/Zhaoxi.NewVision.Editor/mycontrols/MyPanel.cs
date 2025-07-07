using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.NewVision.Editor.mycontrols
{
    /// <summary>
    /// 自定义容器面板控件，主要是开启双缓冲
    /// </summary>
    public class MyPanel : Panel
    {
        public MyPanel() : base()
        {
            // 开启控件的双缓冲机制
            DoubleBuffered = true;
        }
    }
}
