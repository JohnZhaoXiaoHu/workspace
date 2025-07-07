using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MachineVision.Defect.Models;
using MachineVision.Defect.Service;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace MachineVision.Defect.ViewModels
{
    public class UpdateProjectViewModel : BindableBase, IDialogAware
    {
        public string Title { get; private set; }

        public event Action<IDialogResult> RequestClose;

        #region 字段和属性
        private ProjectModel currentProject;

        public ProjectModel CurrentProject
        {
            get { return currentProject; }
            set
            {
                currentProject = value;
                RaisePropertyChanged();
            }
        }

        private ProjectService projectService;

        #endregion


        #region 命令
        public DelegateCommand UpdateProjectCommand { get; private set;}

        public DelegateCommand CancelCommand { get; private set;}
        #endregion

        #region 构造方法
        public UpdateProjectViewModel(ProjectService projectService)
        {
            this.projectService = projectService;
            CurrentProject = new ProjectModel();
            UpdateProjectCommand = new DelegateCommand(UpdateProject);
            CancelCommand = new DelegateCommand(Cancel);
        }


        #endregion


        #region 方法
        private async void UpdateProject()
        {
            CurrentProject.UpdateTime = DateTime.Now;
           
            try
            {
                int row=await projectService.UpdateAsync(CurrentProject);
                if(row>0)
                {
                    RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
                }
                else
                {
                    MessageBox.Show("修改项目失败!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Cancel()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }


        #endregion

        #region 对话服务感知
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed() { }

        public void OnDialogOpened(IDialogParameters parameters) 
        {
            if(parameters.Keys.Contains("updateValue"))
            {
                CurrentProject = parameters.GetValue<ProjectModel>("updateValue"); //获取传递的参数
            }
        }
        #endregion
    }
}
