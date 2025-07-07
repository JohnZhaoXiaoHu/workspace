using System.Configuration;
using System.Data;
using System.Windows;
using MachineVision.Core.ObjectMessure;
using MachineVision.Core.Ocr;
using MachineVision.Core.TeamplateMatch;
using MachineVision.Core.TeamplateMatch.Common.LocalDeformableMatch;
using MachineVision.Defect;
using MachineVision.Services;
using MachineVision.ViewModels;
using MachineVision.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;

namespace MachineVision
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //依赖注入，菜单服务类
            containerRegistry.RegisterSingleton<IMenuService, MenuService>();

            //依赖注入，视图和视图的对应上下文
            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
            containerRegistry.RegisterForNavigation<DashboardView, DashboardViewModel>();
            containerRegistry.RegisterForNavigation<ShapeMatchView, ShapeMatchViewModel>();
            containerRegistry.RegisterForNavigation<NccMatchView, NccMatchViewModel>();
            containerRegistry.RegisterForNavigation<BarcodeMatchView, BarcodeMatchViewModel>();
            containerRegistry.RegisterForNavigation<QrcodeMatchView, QrcodeMatchViewModel>();
            containerRegistry.RegisterForNavigation<CircleMessureMatchView, CircleMessureMatchViewModel>();
            containerRegistry.RegisterForNavigation<LocalDeformableMatchView, LocalDeformableViewModel>();

            //依赖注入，服务接口和服务类
            containerRegistry.Register<ITeamplateMatchService, ShapeMatchService>(
                nameof(TeamplateMatchType.ShapeMatch)
            );

            containerRegistry.Register<ITeamplateMatchService, NccMatchService>(
                nameof(TeamplateMatchType.NccMatch)
            );
            containerRegistry.Register<ITeamplateMatchService, LocalDeformableService>(
               nameof(TeamplateMatchType.LocalDeformableMatch)
           );

            containerRegistry.Register<BarcodeService>();
            containerRegistry.Register<QrcodeService>();
            containerRegistry.Register<CircleMessureService>();

           
        }

        protected override void OnInitialized()
        {
            var mainVW = App.Current.MainWindow.DataContext as MainViewModel;
            mainVW?.InitNavigate();
            base.OnInitialized();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MachineVision.TeamplateMach.DrawShapeService>();
            moduleCatalog.AddModule<DefectModule>();
            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}
