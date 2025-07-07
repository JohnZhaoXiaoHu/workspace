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
using MTHCollection.Controls;
using MTHCollection.Models;
using ScottPlot.Plottables;
using Sunny.UI;

namespace MTHCollection.Project.ChildForm
{
    public partial class FrmHistoryTend : UserControl
    {
        public FrmHistoryTend()
        {
            InitializeComponent();
        }

        private void FrmHistoryTend_Load(object sender, EventArgs e)
        {
            SetChartStyle();
        }

        private Dictionary<string, List<float>> dicChartData = new Dictionary<string, List<float>>()
        {
            { "模块1温度", new List<float>() },
            { "模块1湿度", new List<float>() },
            { "模块2温度", new List<float>() },
            { "模块2湿度", new List<float>() },
            { "模块3温度", new List<float>() },
            { "模块3湿度", new List<float>() },
            { "模块4温度", new List<float>() },
            { "模块4湿度", new List<float>() },
            { "模块5温度", new List<float>() },
            { "模块5湿度", new List<float>() },
            { "模块6温度", new List<float>() },
            { "模块6湿度", new List<float>() },
        };
        private List<DateTime> listDate = new List<DateTime>();
        private Scatter[] scatterArray = new Scatter[12];
        private Dictionary<string, Scatter> dicScatter = new Dictionary<string, Scatter>();

        private void SetChartStyle()
        {
            formsPlot1.Plot.Font.Automatic();
            formsPlot1.Plot.Axes.AutoScale();
            formsPlot1.Plot.Axes.DateTimeTicksBottom();
            formsPlot1.Plot.DataBackground.Color = ScottPlot.Color.FromHtml("#07245A");
            formsPlot1.Plot.FigureBackground.Color = ScottPlot.Color.FromHtml("#07245A");
            formsPlot1.Plot.Legend.BackgroundColor = ScottPlot.Color.FromHtml("#07245A");
            formsPlot1.Plot.Legend.FontColor = ScottPlot.Color.FromColor(
                System.Drawing.Color.White
            );
            formsPlot1.Plot.Legend.OutlineColor = ScottPlot.Color.FromHtml("#07245A");
            formsPlot1.Plot.Grid.MajorLineColor = ScottPlot.Color.FromColor(
                System.Drawing.Color.LightGray
            );
            formsPlot1.Plot.HideGrid();
            formsPlot1.Plot.Grid.XAxisStyle.FillColor1 = new ScottPlot.Color("#07245A").WithAlpha(
                10
            );
            formsPlot1.Plot.Grid.YAxisStyle.FillColor1 = new ScottPlot.Color("#07245A").WithAlpha(
                10
            );
            //formsPlot1.Plot.Axes.FrameColor(new ScottPlot.Color("#ffffffff"));
            formsPlot1.Plot.Axes.Color(new ScottPlot.Color("#ffffffff"));

            formsPlot1.Plot.Title("温湿度监控");
            formsPlot1.Plot.XLabel("Time");
            formsPlot1.Plot.YLabel("数值");
        }

        /// <summary>
        /// 刷新显示实时趋势图的数据
        /// </summary>
        private void SetChart(IList<RealTimeDataModel> list)
        {
            foreach (var item in list)
            {
                listDate.Add(item.InsertTime);
                dicChartData["模块1温度"].Add(item.Station1Temp);
                dicChartData["模块1湿度"].Add(item.Station1Humidity);
                dicChartData["模块2温度"].Add(item.Station2Temp);
                dicChartData["模块2湿度"].Add(item.Station2Humidity);
                dicChartData["模块3温度"].Add(item.Station3Temp);
                dicChartData["模块3湿度"].Add(item.Station3Humidity);
                dicChartData["模块4温度"].Add(item.Station4Temp);
                dicChartData["模块4湿度"].Add(item.Station4Humidity);
                dicChartData["模块5温度"].Add(item.Station5Temp);
                dicChartData["模块5湿度"].Add(item.Station5Humidity);
                dicChartData["模块6温度"].Add(item.Station2Temp);
                dicChartData["模块6湿度"].Add(item.Station2Humidity);
            }

            //移除旧的数据
            formsPlot1.Plot.Clear();

            #region  添加各项数据
            dicScatter["模块1温度"] = ChartService.AddData<DateTime, float>(
                formsPlot1.Plot,
                listDate,
                dicChartData["模块1温度"],
                System.Drawing.Color.Red
            );

            dicScatter["模块1湿度"] = ChartService.AddData<DateTime, float>(
                formsPlot1.Plot,
                listDate,
                dicChartData["模块1湿度"],
                System.Drawing.Color.Orange
            );

            dicScatter["模块2温度"] = ChartService.AddData<DateTime, float>(
                formsPlot1.Plot,
                listDate,
                dicChartData["模块2温度"],
                System.Drawing.Color.Cyan
            );

            dicScatter["模块2湿度"] = ChartService.AddData<DateTime, float>(
                formsPlot1.Plot,
                listDate,
                dicChartData["模块2湿度"],
                System.Drawing.Color.Green
            );

            dicScatter["模块3温度"] = ChartService.AddData<DateTime, float>(
                formsPlot1.Plot,
                listDate,
                dicChartData["模块3温度"],
                System.Drawing.Color.LightSeaGreen
            );

            dicScatter["模块3湿度"] = ChartService.AddData<DateTime, float>(
                formsPlot1.Plot,
                listDate,
                dicChartData["模块3湿度"],
                System.Drawing.Color.Blue
            );

            dicScatter["模块4温度"] = ChartService.AddData<DateTime, float>(
                formsPlot1.Plot,
                listDate,
                dicChartData["模块4温度"],
                System.Drawing.Color.Purple
            );

            dicScatter["模块4湿度"] = ChartService.AddData<DateTime, float>(
                formsPlot1.Plot,
                listDate,
                dicChartData["模块4湿度"],
                System.Drawing.Color.PaleGoldenrod
            );

            dicScatter["模块5温度"] = ChartService.AddData<DateTime, float>(
                formsPlot1.Plot,
                listDate,
                dicChartData["模块5温度"],
                System.Drawing.Color.Plum
            );

            dicScatter["模块5湿度"] = ChartService.AddData<DateTime, float>(
                formsPlot1.Plot,
                listDate,
                dicChartData["模块5湿度"],
                System.Drawing.Color.HotPink
            );

            dicScatter["模块6温度"] = ChartService.AddData<DateTime, float>(
                formsPlot1.Plot,
                listDate,
                dicChartData["模块6温度"],
                System.Drawing.Color.Chocolate
            );

            dicScatter["模块6湿度"] = ChartService.AddData<DateTime, float>(
                formsPlot1.Plot,
                listDate,
                dicChartData["模块6湿度"],
                System.Drawing.Color.BlanchedAlmond
            );
            #endregion

            foreach (var item in dicScatter)
            {
                if (item.Value != null)
                    dicScatter[item.Key].LegendText = item.Key;
            }

            foreach (var control in this.Controls)
            {
                if (control is UICheckBox ck)
                {
                    string varName = ck.Tag.ToString();

                    if (!string.IsNullOrWhiteSpace(varName) && dicScatter[varName] != null)
                        dicScatter[varName].IsVisible = ck.Checked;
                }
            }

            SetChartStyle();
            formsPlot1.Refresh();
        }

        IList<RealTimeDataModel> list = null;

        #region 时间查询按钮事件
        private async void btnTimeSearch_Click(object sender, EventArgs e)
        {
            DateTime startTime = dtStartTime.Value;
            DateTime endTime = dtEndTime.Value;
            list = await new RealTimeDataService().GetListAsync(startTime, endTime);
            if (list != null)
            {
                SetChart(list);
            }
        }
        #endregion

        #region 快速查询按钮事件
        private async void btnQuiklySearch_Click(object sender, EventArgs e)
        {
            list = await new RealTimeDataService().GetListAsync();
            if (list != null)
            {
                SetChart(list);
            }
        }
        #endregion


        private string baseDirectory = AppDomain.CurrentDomain.BaseDirectory + "//ConfigFile//";

        #region 导出Excel按钮事件
        private async void btnOutputExcel_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }
            try
            {
                await MiniExcel.SaveAsAsync(
                    baseDirectory + "HistoryData.xlsx",
                    list,
                    overwriteFile: true
                );
                MessageBox.Show("导出Excel成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出Excel失败:" + ex.Message);
            }
        }
        #endregion

        private void ckH6_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var control in this.Controls)
            {
                if (control is UICheckBox ck)
                {
                    string varName = ck.Tag.ToString();

                    if (!string.IsNullOrWhiteSpace(varName) && dicScatter[varName] != null)
                        dicScatter[varName].IsVisible = ck.Checked;
                }
            }
            formsPlot1.Refresh();
        }
    }
}
