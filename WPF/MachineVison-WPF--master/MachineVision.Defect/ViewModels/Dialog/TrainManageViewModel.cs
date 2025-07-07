using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using MachineVision.Defect.Models;
using MachineVision.Defect.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace MachineVision.Defect.ViewModels.Dialog
{
    public class TrainManageViewModel : BindableBase, IDialogAware
    {
        public string Title { get; set; }

        public event Action<IDialogResult> RequestClose;

        #region 字段和属性



        private ProjectModel currentProject;

        /// <summary>
        /// 当前项目
        /// </summary>
        public ProjectModel CurrentProject
        {
            get { return currentProject; }
            set
            {
                currentProject = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<InsectRegionModel> inspectRegionList;

        /// <summary>
        /// 检测区域列表
        /// </summary>
        public ObservableCollection<InsectRegionModel> InspectRegionList
        {
            get { return inspectRegionList; }
            set
            {
                inspectRegionList = value;
                RaisePropertyChanged();
            }
        }

        private InsectRegionModel selectedRegion;

        /// <summary>
        /// 选中的检测区域
        /// </summary>
        public InsectRegionModel SelectedRegion
        {
            get { return selectedRegion; }
            set
            {
                selectedRegion = value;
                RaisePropertyChanged();
            }
        }

        private IList<ImageFileModel> imageList;

        public IList<ImageFileModel> ImageList
        {
            get { return imageList; }
            set
            {
                imageList = value;
                RaisePropertyChanged();
            }
        }

        private BitmapImage displayImage;

        /// <summary>
        /// 当前显示图片
        /// </summary>
        public BitmapImage DisplayImage
        {
            get { return displayImage; }
            set
            {
                displayImage = value;
                RaisePropertyChanged();
            }
        }

        #endregion


        #region 命令
        /// <summary>
        /// 检测区域改变命令
        /// </summary>
        public DelegateCommand<InsectRegionModel> RegionChangedCommand { get; private set; }

        /// <summary>
        /// 删除图片命令
        /// </summary>
        public DelegateCommand<ImageFileModel> DeleteImageCommand { get; private set; }

        /// <summary>
        /// 显示图片命令
        /// </summary>
        public DelegateCommand<ImageFileModel> ShowImageCommand { get; private set; }

        /// <summary>
        /// 确定命令
        /// </summary>
        public DelegateCommand SureCommand { get; private set; }
        #endregion


        #region 构造方法
        public TrainManageViewModel()
        {
            RegionChangedCommand = new DelegateCommand<InsectRegionModel>(RegionChanged);
            DeleteImageCommand = new DelegateCommand<ImageFileModel>(DeleteImage);
            ShowImageCommand = new DelegateCommand<ImageFileModel>(ShowImage);
            SureCommand = new DelegateCommand(Sure);
        }

        #endregion

        #region 方法
        private void RegionChanged(InsectRegionModel regionModel)
        {
            TrainService trainService = new TrainService(CurrentProject, regionModel);
            ImageList = trainService.GetImageList();
        }

        private async void DeleteImage(ImageFileModel model)
        {
            if (model == null)
                return;

            //删除图片
            if (File.Exists(model.ImagePath))
            {
                File.Delete(model.ImagePath);
                ImageList.Remove(model);
            }

            InspectionService inspectionService = new InspectionService();



            //重新训练图片和保存差异模型
            await Task.Run(async() =>
            {
                foreach (var itemRegion in InspectRegionList)
                {
                    TrainService trainService = new TrainService(CurrentProject, itemRegion);
                    await trainService.TrainVariationModel();
                    inspectionService.SaveVariationModel(
                    itemRegion.VariationModelID,
                    CurrentProject.Name, itemRegion.VariationModelFileName);

                }
            });

            
            MessageBox.Show("删除模型图片完成");
        }

        private void ShowImage(ImageFileModel model)
        {
            if (model == null)
                return;

            // 读取指定图像文件的所有字节数据
            var bytes = File.ReadAllBytes(model.ImagePath);

            // 创建一个基于读取到的字节数据的内存流
            MemoryStream ms = new MemoryStream(bytes);

            // 创建一个用于表示图像的 BitmapImage 对象
            BitmapImage b = new BitmapImage();

            // 开始 BitmapImage 的初始化过程
            b.BeginInit();

            // 设置 BitmapImage 的数据源为前面创建的内存流
            b.StreamSource = ms;

            // 结束 BitmapImage 的初始化过程
            b.EndInit();

            // 将加载好的 BitmapImage 对象赋值给 Image，可能用于后续的图像显示等操作
            DisplayImage = b;
        }



        private void Sure()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }


        #endregion



        #region 导航感知
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed() { }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("CurrentProjectParameter"))
            {
                CurrentProject = parameters.GetValue<ProjectModel>("CurrentProjectParameter");
            }
            if (parameters.ContainsKey("InspectRegionListParamter"))
            {
                InspectRegionList = parameters.GetValue<ObservableCollection<InsectRegionModel>>(
                    "InspectRegionListParamter"
                );
            }
        }
        #endregion
    }
}
