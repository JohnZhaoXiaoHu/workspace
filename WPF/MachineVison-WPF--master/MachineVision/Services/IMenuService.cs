using MachineVision.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Services
{
    // 定义一个接口，用于定义菜单服务的行为
    public interface IMenuService
    {
        public ObservableCollection<MenuItem> MenuItems { get; set; }
        void Init();
    }
}
