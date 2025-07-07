using DragVision.Controls;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragVision.Plugin.Service
{
    public abstract class BasePluginService : IPlugin
    {
        
        public virtual void RunProcess()
        {
            throw new NotImplementedException();
        }


        public virtual void ShowPluginWindow(FlowNode node)
        {
            throw new NotImplementedException();
        }
    }
}
