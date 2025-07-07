using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace MachineVision.Models
{
    /// <summary>
    /// 菜单实体类
    /// </summary>
    public class MenuItem : BindableBase
    {
        public MenuItem(
            string name,
            string icon,
            string pageName,
            ObservableCollection<MenuItem> items = null
        )
        {
            Name = name;
            Icon = icon;
            PageName = pageName;
            Items = items;
        }

        private string _name;
        private string _icon;
        private string _pageNaem;
        private ObservableCollection<MenuItem> _items;

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 菜单要导航的页面名称
        /// </summary>
        public string PageName
        {
            get { return _pageNaem; }
            set
            {
                _pageNaem = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 菜单子项
        /// </summary>
        public ObservableCollection<MenuItem> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged();
            }
        }
    }
}
