using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragVision.Shared.Helper
{
    public enum MouseEventType
    {
        MouseMove,
        MouseDown,
        
    }

    public class RegisterMouseEventHandlerHelper
    {
        public static void RegisterMouseEventHandler(
            Control control,
            MouseEventHandler mouseEventHandler,
            MouseEventType eventType
        )
        {
            foreach(Control childcontrol in control.Controls)
            {

                switch (eventType)
                {
                    case MouseEventType.MouseDown:
                        childcontrol.MouseDown += mouseEventHandler;
                        break;
                    case MouseEventType.MouseMove:
                        childcontrol.MouseMove += mouseEventHandler;
                        break;


                    default:
                        break;
                }

                //递归
                RegisterMouseEventHandler(childcontrol, mouseEventHandler, eventType);
            }
        }
    }
}
