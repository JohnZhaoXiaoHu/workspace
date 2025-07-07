using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.Core.Device;
using HslCommunication.ModBus;
using MiniExcelLibs;
using MTHCollection.BLL;
using MTHCollection.Common;
using MTHCollection.Common.Communication;
using MTHCollection.Models;
using ScottPlot;
using ScottPlot.Plottables;
using Sunny.UI;
using static System.Windows.Forms.ListViewItem;

namespace MTHCollection.Project.ChildForm
{
    public partial class FrmMonitor : UserControl
    {
        public FrmMonitor()
        {
            InitializeComponent();
        }

        private string groupPath =
            AppDomain.CurrentDomain.BaseDirectory + "//ConfigFile" + "//GroupConfig.xlsx";
        private string variblePath =
            AppDomain.CurrentDomain.BaseDirectory + "//ConfigFile" + "//VaribleConfig.xlsx";

        private CancellationTokenSource cts = new CancellationTokenSource();

        #region  窗体加载事件

        /// <summary>
        /// 从Excel中读取和加载变量和通讯组信息
        /// </summary>
        /// <returns></returns>
        private async Task LoadVaribleAndGroup()
        {
            List<VaribleModel> varibleList = null;
            if (File.Exists(variblePath))
            {
                varibleList = (await MiniExcel.QueryAsync<VaribleModel>(variblePath)).ToList();
            }
            List<GroupModel> groupList = null;
            if (File.Exists(groupPath))
            {
                groupList = (await MiniExcel.QueryAsync<GroupModel>(groupPath)).ToList();
                foreach (var groupItem in groupList)
                {
                    groupItem.VaribleList = varibleList.FindAll(v =>
                        v.GroupName.Equals(groupItem.GroupName)
                    );
                }
                CommonParam.CurrentDevice.GroupList = groupList;
            }
        }

        private async void FrmMonitor_Load(object sender, EventArgs e)
        {
            //1.获取通讯类对象
            var device = CommonParam.CurrentDevice;
            CommonParam.Modbus = DeviceFactory.GetNetDevice(
                NetType.ModbusTcp,
                device.IP,
                device.Port
            );

            //2.从Excel文件中加载通讯组和设备信息到设备
            await LoadVaribleAndGroup();

            CommonParam.CurrentDevice.AlarmAction += CurrentDevice_AlarmClick;

            //3.建立通讯
            Task.Run(
                () =>
                {
                    DeviceCommunication();
                },
                cts.Token
            );

            //4.驱动定时器，显示UI数据
            timer1.Interval = 1200;
            timer1.Enabled = true;

            dicScatter.Add("模块1温度", scatterArray[0]);
            dicScatter.Add("模块1湿度", scatterArray[1]);
            dicScatter.Add("模块2温度", scatterArray[2]);
            dicScatter.Add("模块2湿度", scatterArray[3]);
            dicScatter.Add("模块3温度", scatterArray[4]);
            dicScatter.Add("模块3湿度", scatterArray[5]);
            dicScatter.Add("模块4温度", scatterArray[6]);
            dicScatter.Add("模块4湿度", scatterArray[7]);
            dicScatter.Add("模块5温度", scatterArray[8]);
            dicScatter.Add("模块5湿度", scatterArray[9]);
            dicScatter.Add("模块6温度", scatterArray[10]);
            dicScatter.Add("模块6湿度", scatterArray[11]);

            //5.设置图表样式
            SetChartStyle();
        }

        private async void CurrentDevice_AlarmClick(bool alarmActionType, VaribleModel model)
        {
            if (alarmActionType) //报警触发
            {
                CommonParam.AddLogAction?.Invoke(2, $"{model.Remark}:触发");

                //报警溯源内容添加到数据库
                AlarmModel alarmModel = new AlarmModel()
                {
                    AlarmTime = DateTime.Now,
                    AlarmType = "触发",
                    AlarmContent = model.Remark,
                    UserName = CommonParam.CurrentUser.UserName,
                    VaribleName = model.VaribleName,
                };
                await new AlarmService().InsertAsync(alarmModel);
            }
            else //报警消除
            {
                CommonParam.AddLogAction?.Invoke(1, $"{model.Remark}:消除");

                //报警溯源内容添加到数据库
                AlarmModel alarmModel = new AlarmModel()
                {
                    AlarmTime = DateTime.Now,
                    AlarmType = "消除",
                    AlarmContent = model.Remark,
                    UserName = CommonParam.CurrentUser.UserName,
                    VaribleName = model.VaribleName,
                };
                await new AlarmService().InsertAsync(alarmModel);
            }
        }

        /// <summary>
        /// 建立设备通讯，读取数据
        /// </summary>
        private void DeviceCommunication()
        {
            while (!cts.IsCancellationRequested)
            {
                object[] dataArray = null;
                if (CommonParam.CurrentDevice.IsConnected)
                {
                    foreach (var group in CommonParam.CurrentDevice.GroupList)
                    {
                        DataTypeEnum dataType = (DataTypeEnum)
                            Enum.Parse(typeof(DataTypeEnum), group.SaveAreaName);

                        lock (this)
                        {
                            dataArray = GetData(dataType, group);
                        }

                        for (int i = 0; i < dataArray.Length; i++)
                        {
                            var varible = group.VaribleList.Find(v => v.StartIndex == i);

                            if (varible != null)
                            {
                                varible.Value = GetRealVaribleValue(varible, dataArray[i]);
                                CommonParam.CurrentDevice.UpdateVarible(varible);
                            }
                        }
                    }
                }
                else
                {
                    CommonParam.CurrentDevice.IsConnected = CommonParam
                        .Modbus.ConnectServer()
                        .IsSuccess;
                    if (CommonParam.CurrentDevice.IsConnected)
                    {
                        CommonParam.AddLogAction.Invoke(1, "连接设备成功!");
                    }
                    else
                    {
                        CommonParam.Modbus.ConnectClose();
                        CommonParam.AddLogAction.Invoke(2, "连接设备失败,正在尝试重连!");
                        Thread.Sleep(5000);
                        CommonParam.Modbus.ConnectServer();
                    }
                }
            }
        }

        private ChartService chartService = new ChartService();

        /// <summary>
        /// 根据数据类型读取和获取数据
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        private object[] GetData(DataTypeEnum dataType, GroupModel group)
        {
            object[] data = null;
            switch (dataType)
            {
                case DataTypeEnum.Bool:
                    var bResult = CommonParam
                        .Modbus.ReadBool(group.StartAddress.ToString(), (ushort)group.Length)
                        .Content;
                    data = bResult.Cast<object>().ToArray();
                    break;
                case DataTypeEnum.Short:
                    var sResult = CommonParam
                        .Modbus.ReadInt16(group.StartAddress.ToString(), (ushort)group.Length)
                        .Content;
                    data = sResult.Cast<object>().ToArray();
                    break;
                case DataTypeEnum.Int:
                    var iResult = CommonParam
                        .Modbus.ReadInt32(group.StartAddress.ToString(), (ushort)group.Length)
                        .Content;
                    data = iResult.Cast<object>().ToArray();
                    break;
                case DataTypeEnum.Float:
                    var fResult = CommonParam
                        .Modbus.ReadFloat(group.StartAddress.ToString(), (ushort)group.Length)
                        .Content;
                    data = fResult.Cast<object>().ToArray();
                    break;
                case DataTypeEnum.Double:
                    var dResult = CommonParam
                        .Modbus.ReadDouble(group.StartAddress.ToString(), (ushort)group.Length)
                        .Content;
                    data = dResult.Cast<object>().ToArray();
                    break;
                default:
                    break;
            }
            return data;
        }

        /// <summary>
        /// 根据变量类型获取线性系数和偏移转换后的实际变量值
        /// </summary>
        /// <param name="varible"></param>
        /// <param name="oValue"></param>
        /// <returns></returns>
        private object GetRealVaribleValue(VaribleModel varible, object oValue)
        {
            DataTypeEnum dataType = (DataTypeEnum)
                Enum.Parse(typeof(DataTypeEnum), varible.VaribleType);
            object o = null;
            switch (dataType)
            {
                case DataTypeEnum.Bool:
                    o = oValue;
                    break;
                case DataTypeEnum.Short:
                    o = (short)oValue * varible.Scale + varible.Offset;
                    break;
                case DataTypeEnum.Int:
                    o = (int)oValue * varible.Scale + varible.Offset;
                    break;
                case DataTypeEnum.Float:
                    o = (float)oValue * varible.Scale + varible.Offset;
                    break;
                case DataTypeEnum.Double:
                    o = (double)oValue * varible.Scale + varible.Offset;
                    break;
                default:
                    break;
            }

            return o;
        }
        #endregion

        #region 定时器事件
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
            formsPlot1.Plot.Legend.OutlineColor= ScottPlot.Color.FromHtml("#07245A");
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
        private void SetChart()
        {
            listDate.Add(DateTime.Now);
            dicChartData["模块1温度"].Add(thMonitorControl1.Teamperature);
            dicChartData["模块1湿度"].Add(thMonitorControl1.Humidity);
            dicChartData["模块2温度"].Add(thMonitorControl2.Teamperature);
            dicChartData["模块2湿度"].Add(thMonitorControl2.Humidity);
            dicChartData["模块3温度"].Add(thMonitorControl3.Teamperature);
            dicChartData["模块3湿度"].Add(thMonitorControl3.Humidity);
            dicChartData["模块4温度"].Add(thMonitorControl4.Teamperature);
            dicChartData["模块4湿度"].Add(thMonitorControl4.Humidity);
            dicChartData["模块5温度"].Add(thMonitorControl5.Teamperature);
            dicChartData["模块5湿度"].Add(thMonitorControl5.Humidity);
            dicChartData["模块6温度"].Add(thMonitorControl6.Teamperature);
            dicChartData["模块6湿度"].Add(thMonitorControl6.Humidity);

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

        private RealTimeDataService dataService= new RealTimeDataService();
        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (CommonParam.CurrentDevice.IsConnected)
            {
                thMonitorControl1.Teamperature = (float)CommonParam.CurrentDevice["模块1温度"];
                thMonitorControl1.Humidity = (float)CommonParam.CurrentDevice["模块1湿度"];
                thMonitorControl2.Teamperature = (float)CommonParam.CurrentDevice["模块2温度"];
                thMonitorControl2.Humidity = (float)CommonParam.CurrentDevice["模块2湿度"];
                thMonitorControl3.Teamperature = (float)CommonParam.CurrentDevice["模块3温度"];
                thMonitorControl3.Humidity = (float)CommonParam.CurrentDevice["模块3湿度"];
                thMonitorControl4.Teamperature = (float)CommonParam.CurrentDevice["模块4温度"];
                thMonitorControl4.Humidity = (float)CommonParam.CurrentDevice["模块4湿度"];
                thMonitorControl5.Teamperature = (float)CommonParam.CurrentDevice["模块5温度"];
                thMonitorControl5.Humidity = (float)CommonParam.CurrentDevice["模块5湿度"];
                thMonitorControl6.Teamperature = (float)CommonParam.CurrentDevice["模块6温度"];
                thMonitorControl6.Humidity = (float)CommonParam.CurrentDevice["模块6湿度"];

                //刷新显示图表数据
                SetChart();

                //存储实时数据到数据库
                RealTimeDataModel dataModel = new RealTimeDataModel()
                {
                    InsertTime = DateTime.Now,
                    Station1Temp = thMonitorControl1.Teamperature,
                    Station1Humidity = thMonitorControl1.Humidity,
                    Station2Temp = thMonitorControl2.Teamperature,
                    Station2Humidity = thMonitorControl2.Humidity,
                    Station3Temp = thMonitorControl3.Teamperature,
                    Station3Humidity = thMonitorControl3.Humidity,
                    Station4Temp = thMonitorControl4.Teamperature,
                    Station4Humidity = thMonitorControl4.Humidity,
                    Station5Temp = thMonitorControl5.Teamperature,
                    Station5Humidity = thMonitorControl5.Humidity,
                    Station6Temp = thMonitorControl6.Teamperature,
                    Station6Humidity = thMonitorControl6.Humidity,
                };
                await dataService.InsertAsync(dataModel);
            }
        }
        #endregion

        #region  公有方法，添加日志
        public void AddLog(int imageIndex, string str)
        {
            if (listView1.InvokeRequired)
            {
                listView1.Invoke(AddLog, imageIndex, str);
            }
            else
            {
                ListViewItem item = new ListViewItem()
                {
                    ImageIndex = imageIndex,
                    ForeColor = System.Drawing.Color.White
                };
                /*ListViewSubItem sub1 = new ListViewSubItem() { Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ,ForeColor=Color.White};
                ListViewSubItem sub2 = new ListViewSubItem() { Text = str, ForeColor = Color.White };
                item.SubItems.AddRange(new ListViewSubItem[] { sub1, sub2 });*/
                item.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                item.SubItems.Add(str);
                listView1.Items.Add(item);
            }
        }

        #endregion
    }
}
