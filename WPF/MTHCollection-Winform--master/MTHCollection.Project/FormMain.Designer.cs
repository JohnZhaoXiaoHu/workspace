namespace MTHCollection.Project
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            panelEnhanced1 = new Controls.PanelEnhanced();
            panel1 = new Panel();
            MainPanel = new Panel();
            panel3 = new Panel();
            lightCommunicationState = new Sunny.UI.UILight();
            label4 = new Label();
            labMainTitle = new Label();
            pictureBox3 = new PictureBox();
            labCurrentTime = new Label();
            label3 = new Label();
            labUserName = new Label();
            pictureBox2 = new PictureBox();
            panelTop = new Panel();
            btnUserManager = new Controls.NavigateButton();
            btnHistoryTend = new Controls.NavigateButton();
            btnAlarmTracing = new Controls.NavigateButton();
            btnRecipeManager = new Controls.NavigateButton();
            btnParamSet = new Controls.NavigateButton();
            btnMonitor = new Controls.NavigateButton();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            panelEnhanced1.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelEnhanced1
            // 
            panelEnhanced1.BackgroundImage = Properties.Resources.Main;
            panelEnhanced1.BackgroundImageLayout = ImageLayout.Stretch;
            panelEnhanced1.Controls.Add(panel1);
            panelEnhanced1.Dock = DockStyle.Fill;
            panelEnhanced1.Location = new Point(0, 35);
            panelEnhanced1.Name = "panelEnhanced1";
            panelEnhanced1.Size = new Size(1440, 1005);
            panelEnhanced1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Main;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(MainPanel);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panelTop);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1440, 1005);
            panel1.TabIndex = 1;
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.Transparent;
            MainPanel.BorderStyle = BorderStyle.Fixed3D;
            MainPanel.Dock = DockStyle.Top;
            MainPanel.Location = new Point(0, 198);
            MainPanel.Name = "MainPanel";
            MainPanel.Padding = new Padding(2);
            MainPanel.Size = new Size(1440, 960);
            MainPanel.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(lightCommunicationState);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(labMainTitle);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(labCurrentTime);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(labUserName);
            panel3.Controls.Add(pictureBox2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 133);
            panel3.Name = "panel3";
            panel3.Size = new Size(1440, 65);
            panel3.TabIndex = 2;
            // 
            // lightCommunicationState
            // 
            lightCommunicationState.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lightCommunicationState.Location = new Point(1359, 15);
            lightCommunicationState.MinimumSize = new Size(1, 1);
            lightCommunicationState.Name = "lightCommunicationState";
            lightCommunicationState.OffColor = Color.Gray;
            lightCommunicationState.Radius = 35;
            lightCommunicationState.Size = new Size(35, 35);
            lightCommunicationState.State = Sunny.UI.UILightState.Off;
            lightCommunicationState.TabIndex = 8;
            lightCommunicationState.Text = "uiLight1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(1274, 23);
            label4.Name = "label4";
            label4.Size = new Size(79, 22);
            label4.TabIndex = 7;
            label4.Text = "通信状态:";
            // 
            // labMainTitle
            // 
            labMainTitle.AutoSize = true;
            labMainTitle.BackColor = Color.FromArgb(16, 56, 119);
            labMainTitle.FlatStyle = FlatStyle.Flat;
            labMainTitle.Font = new Font("微软雅黑", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labMainTitle.ForeColor = Color.White;
            labMainTitle.Location = new Point(674, 14);
            labMainTitle.Name = "labMainTitle";
            labMainTitle.Size = new Size(88, 26);
            labMainTitle.TabIndex = 6;
            labMainTitle.Text = "集中监控";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Current;
            pictureBox3.Location = new Point(637, 6);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(159, 44);
            pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // labCurrentTime
            // 
            labCurrentTime.AutoSize = true;
            labCurrentTime.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labCurrentTime.ForeColor = Color.Turquoise;
            labCurrentTime.Location = new Point(266, 23);
            labCurrentTime.Name = "labCurrentTime";
            labCurrentTime.Size = new Size(231, 22);
            labCurrentTime.TabIndex = 4;
            labCurrentTime.Text = "2025年1月05日 15:23 星期日";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(100, 23);
            label3.Name = "label3";
            label3.Size = new Size(160, 22);
            label3.TabIndex = 3;
            label3.Text = "欢迎登录!现在时间是";
            // 
            // labUserName
            // 
            labUserName.AutoSize = true;
            labUserName.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labUserName.ForeColor = Color.Turquoise;
            labUserName.Location = new Point(30, 23);
            labUserName.Name = "labUserName";
            labUserName.Size = new Size(42, 22);
            labUserName.TabIndex = 1;
            labUserName.Text = "游客";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.User;
            pictureBox2.Location = new Point(7, 23);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(20, 20);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.Transparent;
            panelTop.Controls.Add(btnUserManager);
            panelTop.Controls.Add(btnHistoryTend);
            panelTop.Controls.Add(btnAlarmTracing);
            panelTop.Controls.Add(btnRecipeManager);
            panelTop.Controls.Add(btnParamSet);
            panelTop.Controls.Add(btnMonitor);
            panelTop.Controls.Add(label2);
            panelTop.Controls.Add(label1);
            panelTop.Controls.Add(pictureBox1);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1440, 133);
            panelTop.TabIndex = 1;
            // 
            // btnUserManager
            // 
            btnUserManager.BackColor = Color.Transparent;
            btnUserManager.BackgroundImage = (Image)resources.GetObject("btnUserManager.BackgroundImage");
            btnUserManager.BackgroundImageLayout = ImageLayout.Stretch;
            btnUserManager.ButtonTitle = "用户管理";
            btnUserManager.IsLeft = false;
            btnUserManager.IsSelected = false;
            btnUserManager.Location = new Point(1274, 67);
            btnUserManager.Name = "btnUserManager";
            btnUserManager.Size = new Size(120, 50);
            btnUserManager.TabIndex = 8;
            // 
            // btnHistoryTend
            // 
            btnHistoryTend.BackColor = Color.Transparent;
            btnHistoryTend.BackgroundImage = (Image)resources.GetObject("btnHistoryTend.BackgroundImage");
            btnHistoryTend.BackgroundImageLayout = ImageLayout.Stretch;
            btnHistoryTend.ButtonTitle = "历史趋势";
            btnHistoryTend.IsLeft = false;
            btnHistoryTend.IsSelected = false;
            btnHistoryTend.Location = new Point(1112, 66);
            btnHistoryTend.Name = "btnHistoryTend";
            btnHistoryTend.Size = new Size(120, 50);
            btnHistoryTend.TabIndex = 7;
            // 
            // btnAlarmTracing
            // 
            btnAlarmTracing.BackColor = Color.Transparent;
            btnAlarmTracing.BackgroundImage = (Image)resources.GetObject("btnAlarmTracing.BackgroundImage");
            btnAlarmTracing.BackgroundImageLayout = ImageLayout.Stretch;
            btnAlarmTracing.ButtonTitle = "报警溯源";
            btnAlarmTracing.IsLeft = false;
            btnAlarmTracing.IsSelected = false;
            btnAlarmTracing.Location = new Point(961, 66);
            btnAlarmTracing.Name = "btnAlarmTracing";
            btnAlarmTracing.Size = new Size(120, 50);
            btnAlarmTracing.TabIndex = 6;
            // 
            // btnRecipeManager
            // 
            btnRecipeManager.BackColor = Color.Transparent;
            btnRecipeManager.BackgroundImage = (Image)resources.GetObject("btnRecipeManager.BackgroundImage");
            btnRecipeManager.BackgroundImageLayout = ImageLayout.Stretch;
            btnRecipeManager.ButtonTitle = "配方管理";
            btnRecipeManager.IsLeft = true;
            btnRecipeManager.IsSelected = false;
            btnRecipeManager.Location = new Point(314, 76);
            btnRecipeManager.Name = "btnRecipeManager";
            btnRecipeManager.Size = new Size(120, 50);
            btnRecipeManager.TabIndex = 5;
            // 
            // btnParamSet
            // 
            btnParamSet.BackColor = Color.Transparent;
            btnParamSet.BackgroundImage = (Image)resources.GetObject("btnParamSet.BackgroundImage");
            btnParamSet.BackgroundImageLayout = ImageLayout.Stretch;
            btnParamSet.ButtonTitle = "参数设置";
            btnParamSet.IsLeft = true;
            btnParamSet.IsSelected = false;
            btnParamSet.Location = new Point(153, 76);
            btnParamSet.Name = "btnParamSet";
            btnParamSet.Size = new Size(120, 50);
            btnParamSet.TabIndex = 4;
            // 
            // btnMonitor
            // 
            btnMonitor.BackColor = Color.Transparent;
            btnMonitor.BackgroundImage = (Image)resources.GetObject("btnMonitor.BackgroundImage");
            btnMonitor.BackgroundImageLayout = ImageLayout.Stretch;
            btnMonitor.ButtonTitle = "集中监控";
            btnMonitor.IsLeft = true;
            btnMonitor.IsSelected = false;
            btnMonitor.Location = new Point(16, 76);
            btnMonitor.Name = "btnMonitor";
            btnMonitor.Size = new Size(120, 50);
            btnMonitor.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("微软雅黑", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(514, 47);
            label2.Name = "label2";
            label2.Size = new Size(405, 46);
            label2.TabIndex = 2;
            label2.Text = "多路温湿度采集监控系统";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("微软雅黑", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(48, 9);
            label1.Name = "label1";
            label1.Size = new Size(72, 26);
            label1.TabIndex = 1;
            label1.Text = "ZHIGE";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.Logo1;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 42);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // FormMain
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1440, 1040);
            Controls.Add(panelEnhanced1);
            Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FormMain";
            Text = "多路温湿度采集系统";
            TitleFont = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ZoomScaleRect = new Rectangle(15, 15, 1424, 1040);
            FormClosing += FormMain_FormClosing;
            Load += FormMain_Load;
            Click += Navigate_Click;
            panelEnhanced1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Controls.PanelEnhanced panelEnhanced1;
        private Panel panel1;
        private Panel MainPanel;
        private Panel panel3;
        private Label labCurrentTime;
        private Label label3;
        private Label labUserName;
        private PictureBox pictureBox2;
        private Panel panelTop;
        private Controls.NavigateButton btnUserManager;
        private Controls.NavigateButton btnHistoryTend;
        private Controls.NavigateButton btnAlarmTracing;
        private Controls.NavigateButton btnRecipeManager;
        private Controls.NavigateButton btnParamSet;
        private Controls.NavigateButton btnMonitor;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private Label labMainTitle;
        private PictureBox pictureBox3;
        private System.Windows.Forms.Timer timer1;
        private Sunny.UI.UILight lightCommunicationState;
        private Label label4;
    }
}
