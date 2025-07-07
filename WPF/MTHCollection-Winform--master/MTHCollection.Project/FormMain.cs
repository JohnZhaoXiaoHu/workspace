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

        #region ������ť�¼�

        #region ��ʾ��Ӧ�Ӵ���
        private void ShowChildForm(UserControl childForm)
        {
            childForm.Dock = DockStyle.Fill;
            childForm.BackColor = Color.Transparent;
            childForm.Show();
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(childForm);
        }
        #endregion

        #region ִ�е�������
        private void GoNavigate(ChildFromtType cfType)
        {
            switch (cfType)
            {
                case ChildFromtType.���м��:
                    ShowChildForm(frmMonitor);
                    break;
                case ChildFromtType.��������:
                    ShowChildForm(frmParamSet);
                    break;
                case ChildFromtType.�䷽����:
                    ShowChildForm(frmRecipeManager);
                    break;
                case ChildFromtType.������Դ:
                    ShowChildForm(frmalAlarmTracing);
                    break;
                case ChildFromtType.��ʷ����:
                    ShowChildForm(frmHistoryTend);
                    break;
                case ChildFromtType.�û�����:
                    ShowChildForm(frmUserManager);
                    break;
            }
        }
        #endregion



        #region ����Ȩ����֤
        private bool NavigatePermissionCheck(ChildFromtType cfType)
        {
            switch (cfType)
            {
                case ChildFromtType.��������:
                    return CommonParam.CurrentUser.ParamSetPermission.Equals("����");
                case ChildFromtType.�䷽����:
                    return CommonParam.CurrentUser.RecipePermission.Equals("����");
                case ChildFromtType.������Դ:
                    return CommonParam.CurrentUser.AlarmTracingPermission.Equals("����");
                case ChildFromtType.��ʷ����:
                    return CommonParam.CurrentUser.HistoryTendPermission.Equals("����");
                case ChildFromtType.�û�����:
                    return CommonParam.CurrentUser.UserManagerPermission.Equals("����");
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
                        "��ǰ�û�û��Ȩ�޷��ʸ�ҳ�棡",
                        "��ʾ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                //.ִ�е�������
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
            string[] weeks = new string[] { "������", "����һ", "���ڶ�", "������", "������", "������", "������" };
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
                "ȷ��Ҫ�˳�ϵͳ��",
                "��ʾ",
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
