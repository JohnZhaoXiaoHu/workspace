using MachineVision.TeamplateMach.ViewModels;
using MachineVision.TeamplateMach.Views;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.TeamplateMach
{
    public class DrawShapeService : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DrawShapeView, DrawShapeViewModel>();
        }
    }
}
