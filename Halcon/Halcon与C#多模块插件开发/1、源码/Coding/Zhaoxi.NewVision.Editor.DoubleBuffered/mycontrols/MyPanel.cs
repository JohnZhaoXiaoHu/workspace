using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.NewVision.Editor.mycontrols
{
    /// <summary>
    /// 自定义容器面板控件
    /// </summary>
    public class MyPanel : Panel
    {
        public MyPanel() : base()
        {
            // 开启控件的双缓冲机制
            DoubleBuffered = true;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }
    }
}
