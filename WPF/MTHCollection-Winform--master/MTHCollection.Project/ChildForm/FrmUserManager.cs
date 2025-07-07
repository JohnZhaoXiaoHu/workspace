using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MTHCollection.BLL;
using MTHCollection.Common;
using MTHCollection.Models;
using Sunny.UI;

namespace MTHCollection.Project.ChildForm
{
    public partial class FrmUserManager : UserControl
    {
        public FrmUserManager()
        {
            InitializeComponent();
        }

        private void FrmUserManager_Load(object sender, EventArgs e)
        {
            dgUserManager.AutoGenerateColumns = false;
            RefreshUser();
        }

        #region 全选，全不选按钮事件
        private bool selectAll = false;

        private void btnSelectAllOrNot_Click(object sender, EventArgs e)
        {
            foreach (var control in this.Controls)
            {
                if (control is UICheckBox ck)
                {
                    ck.Checked = !selectAll;
                }
            }
            selectAll = !selectAll;
        }
        #endregion


        private async void RefreshUser()
        {
            var list = await new UserService().GetListAsync(null);
            if (list != null)
            {
                dgUserManager.DataSource = null;
                dgUserManager.DataSource = list;
            }
        }

        #region 新增用户按钮事件
        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(tbUserName.Text.Trim()))
            {
                MessageBox.Show("用户名不能为空", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbPassword.Text.Trim()))
            {
                MessageBox.Show("密码不能为空", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!(tbConfirmPassword.Text.Trim().Equals(tbPassword.Text.Trim())))
            {
                MessageBox.Show("两次输入的密码不一致", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            //1.数据验证
            if (!Validate())
            {
                return;
            }

            bool isExitUser = await new UserService().isExitUserName(tbUserName.Text.Trim());
            if (isExitUser)
            {
                MessageBox.Show("用户名已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //2.封装实体
            UserModel model = new UserModel()
            {
                UserName = tbUserName.Text.Trim(),
                Password = tbPassword.Text.Trim(),
                ParamSetPermission = (ckParamSet.Checked) ? "启用" : "禁用",
                RecipePermission = (ckRecipe.Checked) ? "启用" : "禁用",
                AlarmTracingPermission = (ckAlarmTracing.Checked) ? "启用" : "禁用",
                HistoryTendPermission = (ckHistoryTend.Checked) ? "启用" : "禁用",
                UserManagerPermission = (ckUserManager.Checked) ? "启用" : "禁用",
            };

            //3.新增用户到数据库
            int row = await new UserService().InsertAsync(model);

            //刷新显示
            if (row > 0)
            {
                RefreshUser();
            }
            else
            {
                MessageBox.Show("新增用户失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        #region 删除用户按钮事件
        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            int id = (int)dgUserManager.CurrentRow.Cells["Id"].Value;
            bool result = await new UserService().DeleteAsync(id);
            if (result)
            {
                RefreshUser();
            }
            else
            {
                MessageBox.Show("删除用户失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        #region 修改用户按钮事件
        private async void btnUpdateUser_Click(object sender, EventArgs e)
        {
            int id = (int)dgUserManager.CurrentRow.Cells["Id"].Value;
            UserModel model = new UserModel()
            {
                Id = id,
                UserName = tbUserName.Text.Trim(),
                Password = tbPassword.Text.Trim(),
                ParamSetPermission = (ckParamSet.Checked) ? "启用" : "禁用",
                RecipePermission = (ckRecipe.Checked) ? "启用" : "禁用",
                AlarmTracingPermission = (ckAlarmTracing.Checked) ? "启用" : "禁用",
                HistoryTendPermission = (ckHistoryTend.Checked) ? "启用" : "禁用",
                UserManagerPermission = (ckUserManager.Checked) ? "启用" : "禁用",
            };

            bool result = await new UserService().UpdateAsync(model);
            if (result)
            {
                RefreshUser();
            }
            else
            {
                MessageBox.Show("修改用户失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 清除消息按钮事件
        private async void btnClearMessage_Click(object sender, EventArgs e)
        {
            await new UserService().DeleteAsync();
            dgUserManager.DataSource = null;
        }
        #endregion

        #region 单元格绘制行号
        private void dgUserManager_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint(dgUserManager, e);
        }
        #endregion


        #region 绘制单元格颜色
        private void dgUserManager_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e
        )
        {
            dgUserManager.DgvStyle(
                Color.FromArgb(4, 21, 65),
                Color.FromArgb(4, 21, 65),
                Color.FromArgb(4, 21, 65)
            );
        }
        #endregion
    }
}
