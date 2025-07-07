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
using MTHCollection.BLL;
using MTHCollection.Common;
using MTHCollection.Models;

namespace MTHCollection.Project.ChildForm
{
    public partial class FrmAlarmTracing : UserControl
    {
        public FrmAlarmTracing()
        {
            InitializeComponent();
        }

        private async void FrmAlarmTracing_Load(object sender, EventArgs e)
        {
            dgAlarmTracing.AutoGenerateColumns = false;
            cbAlarmType.SelectedIndex = 0;

            //刷新表格显示
            var list = await new AlarmService().GetListAsync();
            RefreshAlarm(list);
        }

        /// <summary>
        /// 刷新表格显示
        /// </summary>
        /// <param name="list"></param>
        private void RefreshAlarm(IList<AlarmModel> list)
        {
            if (list != null)
            {
                dgAlarmTracing.DataSource = null;
                dgAlarmTracing.DataSource = list;
            }
        }

        #region 时间查询按钮显示
        private async void btnTimeSearch_Click(object sender, EventArgs e)
        {
            //1.数据验证
            var startTime = dtStartTime.Value;
            var endTime = dtEndTime.Value;
            bool b = (endTime >= startTime);
            if (startTime > endTime)
            {
                MessageBox.Show("开始时间不能大于结束时间");
                return;
            }

            var list = await new AlarmService().GetListAsync(
                cbAlarmType.Text,
                dtStartTime.Value,
                dtEndTime.Value
            );
            RefreshAlarm(list);
        }
        #endregion


        private string basePath = AppDomain.CurrentDomain.BaseDirectory + "//ConfigFile//";

        #region 导出Excel按钮事件
        private async void btnOutputExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var list = dgAlarmTracing.DataSource as IList<AlarmModel>;
                if (list != null)
                {
                    if (!Directory.Exists(basePath))
                    {
                        Directory.CreateDirectory(basePath);
                    }
                    await MiniExcel.SaveAsAsync(
                        basePath + "AlarmTracing.xlsx",
                        list,
                        overwriteFile: true
                    );
                    MessageBox.Show(
                        "导出Excel成功",
                        "提示",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        "没有数据可以导出",
                        "提示",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"导出Excel失败:{ex.Message}",
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
        #endregion


        #region 给表格绘制行号
        private void dgAlarmTracing_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint(dgAlarmTracing, e);
        }
        #endregion



        #region 绘制表格的单元格颜色
        private void dgAlarmTracing_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e
        )
        {
            dgAlarmTracing.DgvStyle(
                Color.FromArgb(4, 21, 65),
                Color.FromArgb(4, 21, 65),
                Color.FromArgb(4, 21, 65)
            );
        }
        #endregion
    }
}
