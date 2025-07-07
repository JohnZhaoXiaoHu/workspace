using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MachineVision.Core;
using MachineVision.Defect.Models;
using MachineVision.Defect.Service;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace MachineVision.Defect.ViewModels
{
    public class AddProjectViewModel : NavigationViewModel, IDialogAware
    {
        public string Title { get; set; }

        public event Action<IDialogResult> RequestClose;

        #region 字段和属性

        private ProjectService service;

        private string projectName;

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName
        {
            get { return projectName; }
            set
            {
                projectName = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        #region 命令
        public DelegateCommand AddProjectCommand { get;private  set;}

        public DelegateCommand CancelCommand { get; private set;}
        #endregion


        #region 构造方法
        public AddProjectViewModel(ProjectService service)
        {
            this.service = service;
            AddProjectCommand = new DelegateCommand(AddProject);
            CancelCommand = new DelegateCommand(Cancel);
        }

       

        #region 方法
        private async void AddProject()
        {
            int row = await service.InsertAsync(new ProjectModel()
            {
                Name=ProjectName,
                CreateTime=DateTime.Now,
                UpdateTime=DateTime.Now,
            });
            if(row>0)
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
            }
            else
            {
                MessageBox.Show("添加项目失败!");
            }
        }

        private void Cancel()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }
        #endregion

        #endregion

        #region 对话感知
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed() { }

        public void OnDialogOpened(IDialogParameters parameters) { }
        #endregion
    }
}
