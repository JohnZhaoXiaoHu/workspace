using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MachineVision.Core;
using MachineVision.Defect.Models;
using MachineVision.Defect.Service;
using MachineVision.Shared2.Services.AutoMapper;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace MachineVision.Defect.ViewModels
{
    public class DefectMatchViewModel : NavigationViewModel
    {
        #region 字段和属性
        private ProjectService projectService;

        private IDialogService dialogService;

        private IRegionManager regionManager;

        private IList<ProjectModel> projectList;

        public IList<ProjectModel> ProjectList
        {
            get { return projectList; }
            set
            {
                projectList = value;
                RaisePropertyChanged();
            }
        }

        private string searchWord;

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string SearchWord
        {
            get { return searchWord; }
            set
            {
                searchWord = value;
                RaisePropertyChanged();
            }
        }

        #endregion


        #region 命令
        /// <summary>
        /// 新建项目命令
        /// </summary>
        public DelegateCommand AddCommand { get; set; }

        /// <summary>
        /// 页面加载命令
        /// </summary>
        public DelegateCommand LoadedCommad { get; set; }

        /// <summary>
        /// 搜索命令
        /// </summary>
        public DelegateCommand SearchCommand { get; set; }

        /// <summary>
        /// 删除命令
        /// </summary>
        public DelegateCommand<ProjectModel> DeleteCommand { get; set; }

        /// <summary>
        /// 选择命令
        /// </summary>
        public DelegateCommand<ProjectModel> ChooseCommand { get; set; }

        public DelegateCommand<ProjectModel> UpdateCommand { get; set; }
        #endregion


        #region 构造方法
        public DefectMatchViewModel(
            ProjectService proService,
            IDialogService dialogService,
            IRegionManager regionManager
        )
        {
            this.projectService = proService;
            this.dialogService = dialogService;
            this.regionManager = regionManager;
            ProjectList = new ObservableCollection<ProjectModel>();
            AddCommand = new DelegateCommand(Add);
            LoadedCommad = new DelegateCommand(Loaded);
            SearchCommand = new DelegateCommand(Search);
            DeleteCommand = new DelegateCommand<ProjectModel>(Delete);
            UpdateCommand = new DelegateCommand<ProjectModel>(Update);
            ChooseCommand = new DelegateCommand<ProjectModel>(Choose);
        }

        #endregion


        #region 方法

        private void Add()
        {
            dialogService.ShowDialog(
                "AddProjectView",
                async callback =>
                {
                    if (callback.Result == ButtonResult.OK)
                    {
                        projectList = new ObservableCollection<ProjectModel>();
                        projectList.Clear();
                        ProjectList = await projectService.GetListAsync(null);
                    }
                }
            );
        }

        private async void Loaded()
        {
            ProjectList.Clear();
            ProjectList = await projectService.GetListAsync(null);
        }

        private async void Search()
        {
            ProjectList.Clear();
            ProjectList = await projectService.GetListAsync(SearchWord);
        }

        private async void Delete(ProjectModel model)
        {
            int row = await projectService.DeleteAsync(model.Id);
            if (row > 0)
            {
                ProjectList.Clear();
                ProjectList = await projectService.GetListAsync(null);
            }
            else
            {
                MessageBox.Show("删除失败!");
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">当前要更新的项目</param>
        private void Update(ProjectModel model)
        {
            DialogParameters paras = new DialogParameters();
            paras.Add("updateValue", model);
            dialogService.ShowDialog(
                "UpdateProjectView",
                paras,
                async callback =>
                {
                    if (callback.Result == ButtonResult.OK)
                    {
                        ProjectList.Clear();
                        ProjectList = await projectService.GetListAsync(null);
                    }
                }
            );
        }

        /// <summary>
        /// 选择按钮按下时,跳转到项目设置页面
        /// </summary>
        /// <param name="model"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Choose(ProjectModel model)
        {
            if(model==null)
            {
                return;
            }
            NavigationParameters paras = new NavigationParameters();
            paras.Add("projectEditValue", model);
            regionManager.RequestNavigate("MainViewRegion", "DefectMatchEditView", callback =>
            {
                if(!(bool)callback.Result)
                {
                    System.Diagnostics.Trace.WriteLine(callback.Error.Message);
                }
            } ,paras);
        }

        #endregion
    }
}
