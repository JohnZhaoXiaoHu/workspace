using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using HalconDotNet;
using MachineVision.Core;
using MachineVision.Defect.Helper;
using MachineVision.Defect.Models;
using MachineVision.Defect.Models.Result;
using MachineVision.Defect.Paramters;
using MachineVision.Defect.Paramters.Macth;
using MachineVision.Defect.Service;
using MachineVision.Defect.Services;
using MachineVision.Defect.Services.Table;
using MachineVision.Shared2.Info;
using Microsoft.WindowsAPICodePack.Dialogs;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace MachineVision.Defect.ViewModels
{
    public class DefectMatchEditViewModel : NavigationViewModel
    {
        #region 字段和属性
        /// <summary>
        /// 对话服务
        /// </summary>
        private IDialogService dialogService;

        //项目服务
        private ProjectService projectService;

        //检测区域服务
        private InspectRegionService inspectRegionService;

        //检测服务
        private InspectionService runInspectionService;

        private ProjectModel currentProject;

        /// <summary>
        /// 当前缺陷检测项目
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

        private ObservableCollection<ImageFileModel> imageFileList;

        /// <summary>
        /// 缺陷检测项目对应的图片列表
        /// </summary>
        public ObservableCollection<ImageFileModel> ImageFileList
        {
            get { return imageFileList; }
            set
            {
                imageFileList = value;
                RaisePropertyChanged();
            }
        }

        private HImage currentImage;

        /// <summary>
        /// 当前显示的图片
        /// </summary>
        public HImage CurrentImage
        {
            get { return currentImage; }
            set
            {
                currentImage = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<ReferPointDrawInfo> drawInfos;

        /// <summary>
        /// 绘制信息
        /// </summary>
        public ObservableCollection<ReferPointDrawInfo> DrawInfos
        {
            get { return drawInfos; }
            set
            {
                drawInfos = value;
                RaisePropertyChanged();
            }
        }

        private MatchResultParamter matchParamter;

        /// <summary>
        /// 匹配到的参数
        /// </summary>
        public MatchResultParamter MatchParamter
        {
            get { return matchParamter; }
            set
            {
                matchParamter = value;
                RaisePropertyChanged();
            }
        }

        private bool showReferMatchResult;

        /// <summary>
        /// 显示参考点匹配结果，传递给用户控件做匹配结果显示
        /// </summary>
        public bool ShowReferMatchResult
        {
            get { return showReferMatchResult; }
            set
            {
                showReferMatchResult = value;
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

        private InsectRegionModel selectedInspectRegion;

        /// <summary>
        /// 当前选中的检测区域
        /// </summary>
        public InsectRegionModel SelectedInspectRegion
        {
            get { return selectedInspectRegion; }
            set
            {
                selectedInspectRegion = value;
                RaisePropertyChanged();
            }
        }

        private HWindow eidtWindow;

        /// <summary>
        /// 当前的图像编辑窗口
        /// </summary>
        public HWindow EidtWindow
        {
            get { return eidtWindow; }
            set
            {
                eidtWindow = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<DeformableInspectResult> inspectResultList;

        /// <summary>
        /// 缺陷检测的结果集合
        /// </summary>
        public ObservableCollection<DeformableInspectResult> InspectResultList
        {
            get { return inspectResultList; }
            set
            {
                inspectResultList = value;
                RaisePropertyChanged();
            }
        }

       
        #endregion


        #region 命令

        /// <summary>
        /// 加载图片命令
        /// </summary>
        public DelegateCommand LoadImageCommand { get; private set; }

        /// <summary>
        /// 选择图片命令
        /// </summary>
        public DelegateCommand<ImageFileModel> ChooseImageCommand { get; private set; }

        /// <summary>
        /// 更新参考点模板参数命令
        /// </summary>
        public DelegateCommand UpdateReferTemplateCommand { get; private set; }

        /// <summary>
        /// 载入项目参数命令
        /// </summary>
        public DelegateCommand LoadInProjectParamterCommand { get; private set; }

        /// <summary>
        /// 添加检测区域命令
        /// </summary>
        public DelegateCommand AddInspectRegionCommand { get; private set; }

        /// <summary>
        /// 删除检测区域命令
        /// </summary>
        public DelegateCommand DeleteInspectRegionCommand { get; private set; }

        /// <summary>
        /// 更新检测区域命令
        /// </summary>
        public DelegateCommand UpdateInspectRegionCommand { get; set; }

        /// <summary>
        /// 运行检测命令
        /// </summary>
        public DelegateCommand RunInspectCommand { get; private set; }

        /// <summary>
        /// 添加训练图片命令
        /// </summary>
        public DelegateCommand<DeformableInspectResult> AddTrainImageCommand { get; set; }

        /// <summary>
        /// 训练模型图片管理命令
        /// </summary>
        public DelegateCommand TrainManageCommand { get; set; }
        #endregion


        #region 构造方法
        public DefectMatchEditViewModel(
            IDialogService dialogService,
            InspectionService runInspectionService,
            ProjectService projectService,
            InspectRegionService inspectRegionService
        )
        {
            this.dialogService= dialogService;
            this.runInspectionService = runInspectionService;
            this.projectService = projectService;
            this.inspectRegionService = inspectRegionService;
            LoadImageCommand = new DelegateCommand(LoadImage);
            ImageFileList = new ObservableCollection<ImageFileModel>();
            ChooseImageCommand = new DelegateCommand<ImageFileModel>(ChooseImage);
            UpdateReferTemplateCommand = new DelegateCommand(UpdateReferPointTemplate);
            DrawInfos = new ObservableCollection<ReferPointDrawInfo>();
            LoadInProjectParamterCommand = new DelegateCommand(LoadInProjectParamter);
            InspectRegionList = new ObservableCollection<InsectRegionModel>();
            SelectedInspectRegion = new InsectRegionModel();
            AddInspectRegionCommand = new DelegateCommand(AddInspectRegion);
            DeleteInspectRegionCommand = new DelegateCommand(DeleteInspectRegion);
            UpdateInspectRegionCommand = new DelegateCommand(UpdateInspectRegion);
            RunInspectCommand = new DelegateCommand(RunInspect);
            InspectResultList = new ObservableCollection<DeformableInspectResult>();
            AddTrainImageCommand = new DelegateCommand<DeformableInspectResult>(AddTrainImage);
            TrainManageCommand = new DelegateCommand(TrainManage);
        }

        #endregion



        #region 方法

        #region 图片加载和选择相关
        private void LoadImage()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true; // 设置为选择文件夹
            dialog.Multiselect = false; //禁止选用多个文件夹
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // 这里可以获取选择的文件夹路径列表
                string path = dialog.FileName;
                var files = new DirectoryInfo(path).GetFiles();
                ImageFileList.Clear();
                //遍历文件夹中的文件，存入文件列表
                foreach (var file in files)
                {
                    string name = file.Name;
                    string fullName = file.FullName;
                    ImageFileModel model = new ImageFileModel()
                    {
                        ImageName = file.Name,
                        ImagePath = file.FullName,
                    };
                    ImageFileList.Add(model);
                }
            }
        }

        private void ChooseImage(ImageFileModel model)
        {
            CurrentImage = model.EditImage;
        }
        #endregion

        #region 更新参考点模板信息
        /// <summary>
        /// 更新参考点的模板信息
        /// </summary>
        private async void UpdateReferPointTemplate()
        {
            var drawInfo = DrawInfos.FirstOrDefault(r => r.Color == "green");
            if (drawInfo != null)
            {
                //记录当前的坐标信息等
                if (CurrentProject.ReferPointParamtter == null)
                {
                    CurrentProject.ReferPointParamtter = new Paramters.TeamplateParamter();
                }
                var teamplate = CurrentProject.ReferPointParamtter;
                teamplate.Row1 = drawInfo.HTuples[0];
                teamplate.Column1 = drawInfo.HTuples[1];
                teamplate.Row2 = drawInfo.HTuples[2];
                teamplate.Column2 = drawInfo.HTuples[3];
                teamplate.Width = teamplate.Row2 - teamplate.Row1;
                teamplate.Height = teamplate.Column2 - teamplate.Column1;
                teamplate.RowCenter = teamplate.Row1 + teamplate.Width / 2;
                teamplate.ColumnCenter = teamplate.Column1 + teamplate.Height / 2;

                //通过当前的参考点坐标信息抠图
                HOperatorSet.GenRectangle1(
                    out HObject rectangle,
                    teamplate.Row1,
                    teamplate.Column1,
                    teamplate.Row2,
                    teamplate.Column2
                );
                HOperatorSet.ReduceDomain(CurrentImage, rectangle, out HObject imageReduced);
                HOperatorSet.CropDomain(imageReduced, out HObject imagePart);

                //利用扣出来的图像，生成NCC匹配模板，并保存到本地
                await CreateReferTemplate(imagePart);

                //将修改后的项目信息存储到数据库
                await projectService.UpdateAsync(CurrentProject);
                MessageBox.Show("参考点模板更新成功！");
            }
        }

        private async Task CreateReferTemplate(HObject templateImage)
        {
            string baseDirectory =
                AppDomain.CurrentDomain.BaseDirectory + $"project\\{CurrentProject.Name}\\";
            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }
            CurrentProject.ReferPointParamtter.IamgeFileName = "default.png";
            CurrentProject.ReferPointParamtter.TeamplateFileName = "default.ncm";
            string imagePath = baseDirectory + CurrentProject.ReferPointParamtter.IamgeFileName;
            string templatePath =
                baseDirectory + CurrentProject.ReferPointParamtter.TeamplateFileName;
            await Task.Run(() =>
            {
                HOperatorSet.Rgb1ToGray(templateImage, out templateImage); //截取部分的图像转换为灰度图像

                HOperatorSet.CreateNccModel( //创建NCC匹配模板
                    templateImage,
                    "auto",
                    0,
                    360,
                    "auto",
                    "use_polarity",
                    out HTuple modelID
                );

                //保存当前ModelID
                CurrentProject.ReferPointParamtter.ModleId = modelID;

                //将图像和模板信息通过文件保存到本地
                HOperatorSet.WriteImage(templateImage, "png", 0, imagePath);
                HOperatorSet.WriteNccModel(modelID, templatePath);
            });
        }

        #endregion


        #region 载入项目的参数(参考点模板参数等)
        private void LoadInProjectParamter()
        {
            if (CurrentProject.ReferPointParamtter.ModleId == null)
            {
                MessageBox.Show("请先绘制参考点区域");
            }
            else
            {
                var modleId = CurrentProject.ReferPointParamtter.ModleId;

                //查找NCC匹配模板,更新匹配结果参数
                RefreshReferPointParamter();
            }
        }

        //通过读取到的参考点模板，刷新匹配参数
        private void RefreshReferPointParamter()
        {
            HTuple hv_angleStart = 0;
            HTuple hv_angleExtent = 360;
            HTuple hv_minScore = 0.79;
            HTuple hv_numMatches = 0;
            HTuple hv_maxOverlap = 0.5;
            HTuple hv_subPixel = "true";
            HTuple hv_numLevels = 0;
            HTuple hv_row = null,
                hv_column = null,
                hv_angle = null,
                hv_score = null;

            //图像转换为灰度图像，然后进行NCC匹配
            HOperatorSet.Rgb1ToGray(CurrentImage, out HObject grayImage);
            var modleId = CurrentProject.ReferPointParamtter.ModleId;
            HOperatorSet.FindNccModel(
                grayImage,
                modleId,
                hv_angleStart,
                hv_angleExtent,
                hv_minScore,
                hv_numMatches,
                hv_maxOverlap,
                hv_subPixel,
                hv_numLevels,
                out hv_row,
                out hv_column,
                out hv_angle,
                out hv_score
            );

            //通过NCC匹配模板的中点坐标，更新模板匹配参数
            if (hv_score.Length > 0)
            {
                MatchParamter = new MatchResultParamter();
                double[] row1 = new double[hv_score.Length];
                double[] column1 = new double[hv_score.Length];
                double[] row2 = new double[hv_score.Length];
                double[] column2 = new double[hv_score.Length];
                for (int i = 0; i < hv_score.Length; i++)
                {
                    row1[i] = hv_row.DArr[i] - CurrentProject.ReferPointParamtter.Width / 2;
                    column1[i] = hv_column.DArr[i] - CurrentProject.ReferPointParamtter.Height / 2;
                    row2[i] = hv_row.DArr[i] + CurrentProject.ReferPointParamtter.Width / 2;
                    column2[i] = hv_column.DArr[i] + CurrentProject.ReferPointParamtter.Height / 2;
                }
                MatchParamter.NccParamter.Row1 = row1;
                MatchParamter.NccParamter.Column1 = column1;
                MatchParamter.NccParamter.Row2 = row2;
                MatchParamter.NccParamter.Column2 = column2;

                if (hv_score.Length == 1)
                {
                    CurrentProject.ReferPointParamtter.Row1 = row1[0];
                    CurrentProject.ReferPointParamtter.Column1 = column1[0];
                    CurrentProject.ReferPointParamtter.Row2 = row2[0];
                    CurrentProject.ReferPointParamtter.Column2 = column2[0];
                }

                //通过修改绑定控件的依赖属性,刷新显示匹配结果
                if (!ShowReferMatchResult)
                    ShowReferMatchResult = true;
            }
            else
            {
                MessageBox.Show("NCC匹配结果失败,请重新绘制检测区域");
            }
        }
        #endregion


        #region 检测区域相关
        /// <summary>
        /// 增加检测区域
        /// </summary>
        private async void AddInspectRegion()
        {
            int row = await inspectRegionService.InsertAsync(
                new InsectRegionModel()
                {
                    Name = "P" + (InspectRegionList.Count + 1).ToString(),
                    ProjectName = CurrentProject.Name,
                    ProjectId = CurrentProject.Id,
                }
            );
            if (row > 0)
            {
                await SearchInsectRegionFromDatabase();
                MessageBox.Show("新增检测区域成功!");
            }
        }

        /// <summary>
        /// 从数据库中查询检测区域
        /// </summary>
        /// <param name="word">查询关键字</param>
        /// <returns></returns>
        private async Task SearchInsectRegionFromDatabase()
        {
            InspectRegionList = await inspectRegionService.GetListAsync(CurrentProject.Id);
        }

        /// <summary>
        /// 删除检测区域
        /// </summary>
        private async void DeleteInspectRegion()
        {
            if (SelectedInspectRegion == null)
            {
                MessageBox.Show("不存在检测区域");
                return;
            }

            int row = await inspectRegionService.DeleteAsync(SelectedInspectRegion.Id);
            if (row > 0)
            {
                await SearchInsectRegionFromDatabase();
                MessageBox.Show("删除检测区域成功!");
            }
        }

        /// <summary>
        /// 更新检测区域
        /// </summary>
        private async void UpdateInspectRegion()
        {
            //拿到绘制的检测区域参数
            var drawInfo = DrawInfos.FirstOrDefault(d => d.Color == "red");
            if (drawInfo == null)
            {
                MessageBox.Show("请先绘制检测区域范围");
                return;
            }
            if (SelectedInspectRegion == null)
            {
                MessageBox.Show("请先选择要绘制的检测区域");
                return;
            }

            SelectedInspectRegion.RegionParamter = new TeamplateParamter();

            //提取检测区域参数
            runInspectionService.GetInsectRegionParamter(
                drawInfo,
                SelectedInspectRegion,
                CurrentProject
            );

            //裁剪和生成模板图片
            HObject templateImage = runInspectionService.GetInspectRegionTeamplateImage(
                CurrentImage,
                SelectedInspectRegion
            );

            if (templateImage == null)
            {
                MessageBox.Show("裁剪模板图片失败");
                return;
            }

            //创建局部可形变模板
            SelectedInspectRegion.RegionParamter.ModleId =
                runInspectionService.CreateDeformableModle(templateImage);
            var defomableModleID = SelectedInspectRegion.RegionParamter.ModleId;
            SelectedInspectRegion.RegionParamter.IamgeFileName =
                $"{SelectedInspectRegion.Name}.png";
            SelectedInspectRegion.RegionParamter.TeamplateFileName =
                $"{SelectedInspectRegion.Name}.dfm";

            //保存局部可形变模板(模板图片和模板文件)
            runInspectionService.SaveDeformableModle(
                templateImage,
                SelectedInspectRegion.RegionParamter.ModleId,
                CurrentProject.Name,
                SelectedInspectRegion.RegionParamter.IamgeFileName,
                SelectedInspectRegion.RegionParamter.TeamplateFileName
            );

            //创建差异模型
            SelectedInspectRegion.VariationModelID = runInspectionService.CreateVariationModel(
                templateImage
            );
            var variationModelID = SelectedInspectRegion.VariationModelID;

            //保存差异模型
            SelectedInspectRegion.VariationModelFileName = $"{SelectedInspectRegion.Name}.vam";
            runInspectionService.SaveVariationModel(
                SelectedInspectRegion.VariationModelID,
                CurrentProject.Name,
                SelectedInspectRegion.VariationModelFileName
            );

            //更新数据库信息
            int row = await inspectRegionService.UpdateAsync(SelectedInspectRegion);
            if (row > 0)
            {
                //读取数据库数据，刷新数据显示
                await SearchInsectRegionFromDatabase();

                //刷新初始化检测区域的参数
                foreach (var inspectRegion in InspectRegionList)
                {
                    inspectRegion.InitRegionParamter();
                    inspectRegion.InitVaritionModelID(CurrentProject.Name);
                }

                MessageBox.Show($"更新检测区域成功");
            }
            else
            {
                MessageBox.Show("更新检测区域失败");
            }
        }

        /// <summary>
        /// 执行检测
        /// </summary>
        private async void RunInspect()
        {
            if (CurrentImage == null)
            {
                MessageBox.Show("请先选中要检测的图片");
                return;
            }

            //清空当前结果的集合
            InspectResultList.Clear();

           
            //创建一个自定义的顺序执行的任务管理器
            SequentialTaskManager taskManager = new SequentialTaskManager();

            await Task.Run(() =>
            {
                foreach (var itemRegion in InspectRegionList)
                {
                    //将添加训练图片和执行训练任务的任务添加到任务队列中
                    taskManager.EnqueueTask(async () =>
                    {
                        //还原各个区域的检测区域坐标参数
                        runInspectionService.UpdateInspectRegionByReferencePoint(
                            CurrentProject,
                            CurrentImage,
                            itemRegion
                        );

                        //显示各个检测区域的检测范围   
                        runInspectionService.ShowTestRegion(itemRegion, EidtWindow);
                      
                       

                        //根据刷新后的检测区域参数，获取新的模板图片
                        var teamplate = runInspectionService.GetInspectRegionTeamplateImage(
                            CurrentImage,
                            itemRegion
                        );

                        //执行检测,接收检测结果
                        var inspectResult = runInspectionService.ExcuteInspect(teamplate, itemRegion);
                       
                        lock (this)
                        {
                            //检测结果添加到结果集合中
                            InspectResultList.Add(inspectResult);
                        }
                    });
                }

                //执行任务队列中的所有任务
                taskManager.ProcessTasks();
            });

           
        }
        #endregion


        #region 训练服务相关
        private async void AddTrainImage(DeformableInspectResult result)
        {
            TrainService trainService = new TrainService(CurrentProject, result.InspectRegionModel);

            //获取当前模型文件的图片数量
            var imageCount = trainService.GetImageList().Count;

            string fileName = $"{result.InspectRegionModel.Name}_{imageCount}.bmp";

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            //添加训练图片
            trainService.AddTarinImage(result.RectifiedImage, fileName);

            //执行差异模型训练
            await trainService.TrainVariationModel();

            stopwatch.Stop();

            //重新保存差异模型
            runInspectionService.SaveVariationModel(
                result.InspectRegionModel.VariationModelID,
                CurrentProject.Name,
                result.InspectRegionModel.VariationModelFileName
            );

            MessageBox.Show($"添加和训练模型完成,耗时:{stopwatch.ElapsedMilliseconds}ms");
        }


        /// <summary>
        /// 训练管理
        /// </summary>
        private void TrainManage()
        {
            DialogParameters paras = new DialogParameters();
            paras.Add("CurrentProjectParameter", CurrentProject);
            paras.Add("InspectRegionListParamter", InspectRegionList);
            dialogService.ShowDialog("TrainManageView", paras,callback =>
            {

            });
        }


        #endregion



        #endregion


        #region 导航感知
        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            if (navigationContext.Parameters.ContainsKey("projectEditValue"))
            {
                CurrentProject = navigationContext.Parameters.GetValue<ProjectModel>(
                    "projectEditValue"
                );

                CurrentProject.InitReferParamter(); //通过从本地文件读取的方式初始化参考点参数

                //获取所有检测区域
                await SearchInsectRegionFromDatabase();

                //初始化检测区域的参数
                foreach(var inspectRegion in InspectRegionList)
                {
                    inspectRegion.InitRegionParamter();
                    inspectRegion.InitVaritionModelID(CurrentProject.Name);
                }
            }
        }

        #endregion
    }
}
