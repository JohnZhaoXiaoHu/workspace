using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineVision.Defect.Service;
using MachineVision.Defect.Services;
using MachineVision.Defect.Services.Table;
using MachineVision.Defect.ViewModels;
using MachineVision.Defect.ViewModels.Dialog;
using MachineVision.Defect.Views;
using MachineVision.Defect.Views.Dialog;
using MachineVision.Shared2.Services.AutoMapper;
using Prism.Ioc;
using Prism.Modularity;

namespace MachineVision.Defect
{
    public class DefectModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider) { }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DefectMatchView, DefectMatchViewModel>();
            containerRegistry.RegisterForNavigation<
                DefectMatchEditView,
                DefectMatchEditViewModel
            >();

            containerRegistry.RegisterDialog<AddProjectView, AddProjectViewModel>();
            containerRegistry.RegisterDialog<UpdateProjectView, UpdateProjectViewModel>();
            containerRegistry.RegisterDialog<TrainManageView, TrainManageViewModel>();

            containerRegistry.Register<IAppMapper, AppMapper>();
            containerRegistry.Register<ProjectService>();
            containerRegistry.Register<InspectRegionService>();
            containerRegistry.Register<InspectionService>();
        }
    }
}
