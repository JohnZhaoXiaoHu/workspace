using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.NewVision.Editor.helper
{
    /// <summary>
    /// 鼠标注册事件工具类
    /// </summary>
    public class MouseEventHelper
    {
        /// <summary>
        /// 给指定的控件注册对应的鼠标事件及处理事件的方法
        /// </summary>
        public static void RegistryMouseEvent(Control control, MouseEventHandler del,
            MouseEventName eventName)
        {
            if (control.Controls.Count > 0)
            {
                foreach (Control item in control.Controls)
                {
                    switch (eventName)
                    {
                        case MouseEventName.MouseDown:
                            item.MouseDown += new MouseEventHandler(del);
                            break;
                        case MouseEventName.MouseMove:
                            item.MouseMove += new MouseEventHandler(del);
                            break;
                        case MouseEventName.MouseUp:
                            item.MouseUp += new MouseEventHandler(del);
                            break;
                    }
                    // 递归给子当前控件对象的子控件继续注册鼠标对应事件
                    RegistryMouseEvent(item, del, eventName);
                }
            }
        }
    }

    /// <summary>
    /// 定义鼠标事件名称枚举
    /// </summary>
    public enum MouseEventName
    {
        MouseDown,
        MouseMove,
        MouseUp
    }
}
