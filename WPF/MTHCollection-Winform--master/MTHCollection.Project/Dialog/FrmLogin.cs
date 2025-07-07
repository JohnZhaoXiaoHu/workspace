using MTHCollection.BLL;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTHCollection.Project.Dialog
{
    public partial class FrmLogin : UILoginForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        #region 登录按钮事件
        private async void FrmLogin_ButtonLoginClick(object sender, EventArgs e)
        {
            string userName = this.UserName.Trim();
            string password = this.Password.Trim();
            var model = await new UserService().LoginAsync(userName, password);
            if (model != null)
            {
                CommonParam.CurrentUser= model;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                UIMessageTip.Show("用户名或密码错误");
            }

        }
        #endregion

        #region 取消按钮事件
        private void FrmLogin_ButtonCancelClick(object sender, EventArgs e)
        {
            this.UserName= string.Empty;
            this.Password = string.Empty;
        }
        #endregion
    }
}
