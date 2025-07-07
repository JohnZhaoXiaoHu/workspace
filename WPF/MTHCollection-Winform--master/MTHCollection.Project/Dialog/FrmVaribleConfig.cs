using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniExcelLibs;
using MTHCollection.Common;
using MTHCollection.Models;
using Sunny.UI;

namespace MTHCollection.Project.Dialog
{
    public partial class FrmVaribleConfig : UIForm
    {
        public FrmVaribleConfig()
        {
            InitializeComponent();
        }

        private async void FrmVaribleConfig_Load(object sender, EventArgs e)
        {
            dgVarible.AutoGenerateColumns = false;

            if (File.Exists(groupPath))
            {
                groupList = (await MiniExcel.QueryAsync<GroupModel>(groupPath, "Sheet1")).ToList();
                cbGroupName.DataSource = groupList;
                cbGroupName.DisplayMember = "GroupName";
                var group = groupList.Find(g => g.GroupName.Equals(cbGroupName.Text.Trim()));
                if (group != null)
                {
                    tbDataType.Text = group.SaveAreaName;
                }
            }
            if (File.Exists(variblePath))
            {
                varibleList = (
                    await MiniExcel.QueryAsync<VaribleModel>(variblePath, "Sheet1")
                ).ToList();
                dgVarible.DataSource = null;
                dgVarible.DataSource = varibleList;
            }
        }

        #region 给表格绘制行号
        private void dgVarible_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint(dgVarible, e);

        }
        #endregion

        #region 改变表格单元格样式
        private void dgVarible_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgVarible.DgvStyle(
                Color.FromArgb(4, 23, 65),
                Color.FromArgb(4, 23, 65),
                Color.FromArgb(4, 23, 65)
            );


        }
        #endregion



        #region 通信组选择
        private void cbGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var group = groupList.Find(g => g.GroupName.Equals(cbGroupName.Text.Trim()));
            if (group != null)
            {
                tbDataType.Text = group.SaveAreaName;
            }
        }
        #endregion


        private List<GroupModel> groupList = null;

        private List<VaribleModel> varibleList = new List<VaribleModel>();

        private string baseDirectory = AppDomain.CurrentDomain.BaseDirectory + "//ConfigFile";
        private string groupPath =
            AppDomain.CurrentDomain.BaseDirectory + "//ConfigFile" + "//GroupConfig.xlsx";
        private string variblePath =
            AppDomain.CurrentDomain.BaseDirectory + "//ConfigFile" + "//VaribleConfig.xlsx";

        #region 新增变量
        private bool ValidateVarible()
        {
            if (string.IsNullOrWhiteSpace(cbGroupName.Text.Trim()))
            {
                MessageBox.Show("通信组不能为空", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbName.Text.Trim()))
            {
                MessageBox.Show("变量名不能为空", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (varibleList.Count > 0)
            {
                var varrible = varibleList.Find(v => v.VaribleName.Equals(tbName.Text.Trim()));
                if (varrible != null)
                {
                    MessageBox.Show("变量名已存在", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (string.IsNullOrWhiteSpace(tbDataType.Text.Trim()))
            {
                MessageBox.Show("数据类型不能为空", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private async void btnAddVarible_Click(object sender, EventArgs e)
        {
            //1.数据验证
            if (!ValidateVarible())
            {
                return;
            }

            //2.封装实体
            VaribleModel varible = new VaribleModel()
            {
                VaribleName = tbName.Text,
                GroupName = cbGroupName.Text,
                VaribleType = tbDataType.Text,
                StartIndex = (int)ndStartAddress.Value,
                Scale = (float)ndScale.Value,
                Offset = (int)ndOffset.Value,
                IsPosEdgeAlarm = ckIsPosedgeAlarm.Checked,
                IsFallEdgeAlarm = ckIsFallEdgeAlarm.Checked,
                Remark = tbRemark.Text,
            };

            //3.添加到集合并保存到文件和刷新表格
            varibleList.Add(varible);
            if (!File.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }
            await MiniExcel.SaveAsAsync(variblePath, varibleList, overwriteFile: true);
            dgVarible.DataSource = null;
            dgVarible.DataSource = varibleList;
        }
        #endregion



        #region 删除变量
        private async void btnDeleteVarible_Click(object sender, EventArgs e)
        {
            string varibleName = dgVarible.CurrentRow.Cells["VaribleName"].Value.ToString();
            var varrible = varibleList.Find(v => v.VaribleName.Equals(varibleName));
            if (varrible != null)
            {
                varibleList.Remove(varrible);
                await MiniExcel.SaveAsAsync(variblePath, varibleList, overwriteFile: true);
                dgVarible.DataSource = null;
                dgVarible.DataSource = varibleList;
            }
        }
        #endregion

        #region 更新变量
        private async void btnUpdateVarible_Click(object sender, EventArgs e) 
        {
            string varibleName = dgVarible.CurrentRow.Cells["VaribleName"].Value.ToString();
            var varrible = varibleList.Find(v => v.VaribleName.Equals(varibleName));
            if (varrible != null)
            {
                varrible.VaribleName = tbName.Text;
                varrible.GroupName = cbGroupName.Text;
                varrible.VaribleType = tbDataType.Text;
                varrible.StartIndex = (int)ndStartAddress.Value;
                varrible.Scale = (float)ndScale.Value;
                varrible.Offset = (int)ndOffset.Value;
                varrible.IsPosEdgeAlarm = ckIsPosedgeAlarm.Checked;
                varrible.IsFallEdgeAlarm = ckIsFallEdgeAlarm.Checked;
                varrible.Remark = tbRemark.Text;
                await MiniExcel.SaveAsAsync(variblePath, varibleList, overwriteFile: true);
                dgVarible.DataSource = null;
                dgVarible.DataSource = varibleList;
            }
        }
        #endregion


        #region 单元格点击事件
        private void dgVarible_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string varibleName= dgVarible.CurrentRow.Cells["VaribleName"].Value.ToString();
            var varrible = varibleList.Find(v => v.VaribleName.Equals(varibleName));
            if (varrible != null)
            {
                tbName.Text = varrible.VaribleName;
                cbGroupName.Text = varrible.GroupName;
                tbDataType.Text = varrible.VaribleType;
                ndStartAddress.Value = varrible.StartIndex;
                ndScale.Value = (decimal)varrible.Scale;
                ndOffset.Value = varrible.Offset;
                ckIsPosedgeAlarm.Checked = varrible.IsPosEdgeAlarm;
                ckIsFallEdgeAlarm.Checked = varrible.IsFallEdgeAlarm;
                tbRemark.Text = varrible.Remark;
            }
        }
        #endregion
    }
}
