using MachineVision.Models;
using MachineVision.Services;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MachineVision.ViewModels
{
    public class DashboardViewModel
    {
        public IMenuService MenuService { get;private set; }

        private IRegionManager _regionManager;

        public DelegateCommand<MenuItem> NavigateCommand { get; set; }
        public DashboardViewModel(IRegionManager regionManager,IMenuService menuService)
        {
            _regionManager = regionManager;
            MenuService = menuService;
            NavigateCommand = new DelegateCommand<MenuItem>(Navigate);
        }

        private void Navigate(MenuItem item)
        {
            if(!string.IsNullOrEmpty(item.PageName))
            {
                _regionManager.RequestNavigate("MainViewRegion", item.PageName);
            }
        }
    }
}
