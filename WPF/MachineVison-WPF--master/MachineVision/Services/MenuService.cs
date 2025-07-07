using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineVision.Models;
using Prism.Mvvm;

namespace MachineVision.Services
{
    /// <summary>
    /// 菜单服务类
    /// </summary>
    public class MenuService : BindableBase, IMenuService
    {
        public MenuService()
        {
            MenuItems = new ObservableCollection<MenuItem>();
            Init();
        }

        private ObservableCollection<MenuItem> _menuItems;

        /// <summary>
        /// 菜单项集合
        /// </summary>
        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                _menuItems = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 初始化菜单项
        /// </summary>
        public void Init()
        {
            //清除现有菜单项
            MenuItems.Clear();

            //添加菜单项
            MenuItems.Add
            (
                new MenuItem(
                    "全部",
                    "",
                    "DashboardView",
                    new ObservableCollection<MenuItem>()
                    {
                       /* new MenuItem("轮廓匹配", "", ""),
                        new MenuItem("形状匹配", "", ""),
                        new MenuItem("相似性匹配", "", ""),
                        new MenuItem("轮廓匹配", "", ""),
                        */
                        new MenuItem("模板匹配", "", "",new ObservableCollection<MenuItem>()
                        {
                            new MenuItem("轮廓匹配","ShapeCirclePlus","DrawShapeView"),
                            new MenuItem("形状匹配","ShapeOutline","ShapeMatchView"),
                            new MenuItem("相似性匹配","Clouds","NccMatchView"),
                            new MenuItem("形变匹配","ShapeOvalPlus","LocalDeformableMatchView"),
                        }),


                new MenuItem(
                    "比较测量",
                    "",
                    "",
                    new ObservableCollection<MenuItem>()
                    {
                        new MenuItem("卡尺线圈", "Circle", "CircleMessureMatchView"),
                        new MenuItem("颜色检测", "Palette", ""),
                        new MenuItem("几何测量", "Ruler", ""),
                    }
                ),

                new MenuItem(
                    "字符识别",
                    "",
                    "",
                    new ObservableCollection<MenuItem>()
                    {
                        /*new MenuItem("字符识别", "FormatColorText", ""),*/
                        new MenuItem("一维码识别", "Barcode", "BarcodeMatchView"),
                        new MenuItem("二维码识别", "Qrcode", "QrcodeMatchView"),
                    }
                ),

                 new MenuItem(
                    "缺陷检测",
                    "",
                    "",
                    new ObservableCollection<MenuItem>()
                    {
                        new MenuItem("缺陷检测", "Crop", "DefectMatchView"),
                       /* new MenuItem("形变模型", "CropRotate", ""),*/
                    })
                }
                ));

            MenuItems.Add(new MenuItem("模板匹配", "", ""));
            MenuItems.Add(new MenuItem("比较测量", "", ""));
            MenuItems.Add(new MenuItem("字符识别", "", ""));
            MenuItems.Add(new MenuItem("缺陷检测", "", ""));
            MenuItems.Add(new MenuItem("学习文档", "", ""));
            
        }
    }
}
