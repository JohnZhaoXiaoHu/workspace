using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MTHCollection.Models;
using Sunny.UI;
using MiniExcelLibs;
using MTHCollection.Common;
using Sunny.UI.Win32;

namespace MTHCollection.Project.Dialog
{
    public partial class FrmGroupConfig : UIForm
    {
        public FrmGroupConfig()
        {
            InitializeComponent();
        }

        private async void FrmGroupConfig_Load(object sender, EventArgs e)
        {
            dgGroup.AutoGenerateColumns = false;
            if (File.Exists(groupPath))
            {
                groupList = (await MiniExcel.QueryAsync<GroupModel>(groupPath, "Sheet1")).ToList();
                dgGroup.DataSource = null;
                dgGroup.DataSource = groupList;
            }
        }

        private List<GroupModel> groupList = new List<GroupModel>();
        private string groupDirectory = AppDomain.CurrentDomain.BaseDirectory + "//ConfigFile";
        private string groupPath = AppDomain.CurrentDomain.BaseDirectory + "//ConfigFile" + "//GroupConfig.xlsx";

        #region 新增通讯组
        private bool ValidateGroup()
        {
            if (string.IsNullOrWhiteSpace(tbName.Text.Trim()))
            {
                MessageBox.Show("请输入通讯组名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (groupList.Count > 0)
            {
                var group = groupList.Find(g => g.GroupName.Equals(tbName.Text.Trim()));
                if (group != null)
                {
                    MessageBox.Show("通讯组名称已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (cbSaveArea.SelectedIndex == -1)
            {
                MessageBox.Show("请选择通讯组保存区域", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private async void btnAddGroup_Click(object sender, EventArgs e)
        {
            //1.数据验证
            if (!ValidateGroup())
                return;
            //2.封装实体
            GroupModel group = new GroupModel()
            {
                GroupName = tbName.Text.Trim(),
                StartAddress = (int)ndStartAddress.Value,
                Length = (int)ndLength.Value,
                SaveAreaName = cbSaveArea.Text.Trim(),
                Remark = tbRemark.Text.Trim(),
            };

            //3.添加实体到列表并保存Excel文件
            groupList.Add(group);
            if (!File.Exists(groupPath))
            {
                Directory.CreateDirectory(groupDirectory);
            }
            await MiniExcel.SaveAsAsync(groupPath, groupList, overwriteFile: true);
            dgGroup.DataSource = null;
            dgGroup.DataSource = groupList;
            MessageBox.Show("添加通讯组成功!");

        }
        #endregion

        #region 删除通讯组
        private async void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            string groupName = dgGroup.CurrentRow.Cells["GroupName"].Value.ToString();
            var group = groupList.Find(g => g.GroupName.Equals(groupName));
            if (group != null)
            {
                groupList.Remove(group);
                await MiniExcel.SaveAsAsync(groupPath, groupList, overwriteFile: true);
                dgGroup.DataSource = null;
                dgGroup.DataSource = groupList;
            }
        }
        #endregion

        #region 更新通讯组
        private async void btnUpdateGroup_Click(object sender, EventArgs e) 
        {
            string groupName = dgGroup.CurrentRow.Cells["GroupName"].Value.ToString();
            var group = groupList.Find(g => g.GroupName.Equals(groupName));
            if (group != null)
            {
                group.GroupName = tbName.Text.Trim();
                group.StartAddress = (int)ndStartAddress.Value;
                group.Length = (int)ndLength.Value;
                group.SaveAreaName = cbSaveArea.Text.Trim();
                group.Remark = tbRemark.Text.Trim();
                await MiniExcel.SaveAsAsync(groupPath, groupList, overwriteFile: true);
                dgGroup.DataSource = null;
                dgGroup.DataSource = groupList;
            }
        }
        #endregion


        #region 给表格绘制行号
        private void dgGroup_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint(dgGroup, e);
        }
        #endregion

        #region 改变单元格颜色
        private void dgGroup_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewHelper.DgvStyle(dgGroup,   Color.FromArgb(4, 21, 65), Color.FromArgb(4, 21, 65), Color.FromArgb(4, 21, 65));
        }
        #endregion

        #region 单元格点击事件
        private void dgGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string groupName = dgGroup.CurrentRow.Cells["GroupName"].Value.ToString();
            var group = groupList.Find(g => g.GroupName.Equals(groupName));
            if (group != null)
            {
                tbName.Text = group.GroupName;
                ndStartAddress.Value = group.StartAddress;
                ndLength.Value = group.Length;
                cbSaveArea.Text = group.SaveAreaName;
                tbRemark.Text = group.Remark;
            }
        }
        #endregion
    }
}
