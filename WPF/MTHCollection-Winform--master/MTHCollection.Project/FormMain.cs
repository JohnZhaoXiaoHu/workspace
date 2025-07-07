using MTHCollection.BLL;
using MTHCollection.Controls;
using MTHCollection.Models;
using MTHCollection.Project.ChildForm;
using SqlSugar;
using Sunny.UI;
using VaribleConfig.DAL.Helper;

namespace MTHCollection.Project
{
    public partial class FormMain : UIForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            return;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.DoubleBuffered = true;
            base.OnPaint(e);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            labUserName.Text = CommonParam.CurrentUser.UserName;
            CommonParam.CurrentDevice = new JsonFileHelper().DeserializeAndLoad<DeviceModel>(
                "Device.json"
            );

            CommonParam.AddLogAction = ((FrmMonitor)frmMonitor).AddLog;
            ShowChildForm(frmMonitor);
            btnMonitor.IsSelected = true;
            labMainTitle.Text = btnMonitor.ButtonTitle;
            btnMonitor.Click += Navigate_Click;
            btnParamSet.Click += Navigate_Click;
            btnRecipeManager.Click += Navigate_Click;
            btnAlarmTracing.Click += Navigate_Click;
            btnHistoryTend.Click += Navigate_Click;
            btnUserManager.Click += Navigate_Click;

            timer1.Interval = 1000;
            timer1.Enabled = true;
        }

        private UserControl frmMonitor = new FrmMonitor();
        private UserControl frmParamSet = new FrmParamSet();
        private UserControl frmRecipeManager = new FrmRecipe();
        private UserControl frmalAlarmTracing = new FrmAlarmTracing();
        private UserControl frmHistoryTend = new FrmHistoryTend();
        private UserControl frmUserManager = new FrmUserManager();

        #region 导航按钮事件

        #region 显示对应子窗体
        private void ShowChildForm(UserControl childForm)
        {
            childForm.Dock = DockStyle.Fill;
            childForm.BackColor = Color.Transparent;
            childForm.Show();
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(childForm);
        }
        #endregion

        #region 执行导航请求
        private void GoNavigate(ChildFromtType cfType)
        {
            switch (cfType)
            {
                case ChildFromtType.集中监控:
                    ShowChildForm(frmMonitor);
                    break;
                case ChildFromtType.参数设置:
                    ShowChildForm(frmParamSet);
                    break;
                case ChildFromtType.配方管理:
                    ShowChildForm(frmRecipeManager);
                    break;
                case ChildFromtType.报警溯源:
                    ShowChildForm(frmalAlarmTracing);
                    break;
                case ChildFromtType.历史趋势:
                    ShowChildForm(frmHistoryTend);
                    break;
                case ChildFromtType.用户管理:
                    ShowChildForm(frmUserManager);
                    break;
            }
        }
        #endregion



        #region 导航权限验证
        private bool NavigatePermissionCheck(ChildFromtType cfType)
        {
            switch (cfType)
            {
                case ChildFromtType.参数设置:
                    return CommonParam.CurrentUser.ParamSetPermission.Equals("启用");
                case ChildFromtType.配方管理:
                    return CommonParam.CurrentUser.RecipePermission.Equals("启用");
                case ChildFromtType.报警溯源:
                    return CommonParam.CurrentUser.AlarmTracingPermission.Equals("启用");
                case ChildFromtType.历史趋势:
                    return CommonParam.CurrentUser.HistoryTendPermission.Equals("启用");
                case ChildFromtType.用户管理:
                    return CommonParam.CurrentUser.UserManagerPermission.Equals("启用");
                default:
                    return true;
            }
        }
        #endregion


        private void Navigate_Click(object sender, EventArgs e)
        {
            NavigateButton cb = sender as NavigateButton;

            if (cb != null)
            {
                
                ChildFromtType cfType = (ChildFromtType)
                    Enum.Parse(typeof(ChildFromtType), cb.ButtonTitle);

                bool isPermission = NavigatePermissionCheck(cfType);
                if (!isPermission)
                {
                    MessageBox.Show(
                        "当前用户没有权限访问该页面！",
                        "提示",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                //.执行导航请求
                GoNavigate(cfType);

                labMainTitle.Text = cb.ButtonTitle;
                foreach (var control in panelTop.Controls)
                {
                    if (control is NavigateButton nb)
                    {
                        nb.IsSelected = (nb.ButtonTitle.Equals(cb.ButtonTitle)) ? true : false;
                    }
                }
            }
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] weeks = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            int day = (int)DateTime.Now.DayOfWeek;
            labCurrentTime.Text =
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "    " + weeks[day];

            lightCommunicationState.State = CommonParam.CurrentDevice.IsConnected
                ? UILightState.On
                : UILightState.Off;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            new RecipeManager().SaveCurrentRecipeInfo(CommonParam.CurrentRecipeInfo);

            var result = MessageBox.Show(
                "确定要退出系统吗？",
                "提示",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
