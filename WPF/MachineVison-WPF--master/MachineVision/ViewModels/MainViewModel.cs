using MachineVision.Core;
using MachineVision.Models;
using MachineVision.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;

namespace MachineVision.ViewModels
{
    public class MainViewModel:NavigationViewModel
    {
        //菜单服务
        public IMenuService MenuService { get;}

        //区域管理
        private IRegionManager _regionManager;


		private bool _isTopDrawerOpen;

        /// <summary>
        /// 顶部折叠栏是否打开
        /// </summary>
		public bool IsTopDrawerOpen
        {
			get { return _isTopDrawerOpen; }
			set { _isTopDrawerOpen = value; RaisePropertyChanged(); }
		}

        /// <summary>
        /// 导航命令
        /// </summary>
        public DelegateCommand<MenuItem> NavigateCommand { get; set; }

		public MainViewModel(IRegionManager regionManager, IMenuService menuService) 
        {
            _regionManager = regionManager;
            MenuService = menuService;
            /* MenuService=ContainerLocator.Current.Resolve<IMenuService>();*/ //第二种取注入实例的方法，从容器定位器中取
            NavigateCommand = new DelegateCommand<MenuItem>(Navigate);
        }

        /// <summary>
        /// 导航事件
        /// </summary>
        /// <param name="item"></param>
        private void Navigate(MenuItem item)
        {
            

            if(item.Name.Equals("全部"))
                IsTopDrawerOpen = true;
            
            if (string.IsNullOrEmpty(item.PageName))
                return;

            _regionManager.RequestNavigate("MainViewRegion", item.PageName);
            
        }

        public void InitNavigate()
        {
            _regionManager.RequestNavigate("MainViewRegion", "DashboardView");
        }
    }
}
