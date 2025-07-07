namespace MTHCollection.Project.ChildForm
{
    partial class FrmParamSet
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmParamSet));
            titleEx1 = new Controls.TitleEx();
            label1 = new Label();
            tbIP = new TextBox();
            tbPort = new TextBox();
            label2 = new Label();
            btnSureSetting = new Button();
            btnCancelSetting = new Button();
            btnGroupConfig = new Button();
            btnVaribleConfig = new Button();
            thSetControl1 = new Controls.THSetControl();
            thSetControl2 = new Controls.THSetControl();
            thSetControl3 = new Controls.THSetControl();
            thSetControl4 = new Controls.THSetControl();
            thSetControl5 = new Controls.THSetControl();
            thSetControl6 = new Controls.THSetControl();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // titleEx1
            // 
            titleEx1.BackColor = Color.Transparent;
            titleEx1.BackgroundImage = (Image)resources.GetObject("titleEx1.BackgroundImage");
            titleEx1.BackgroundImageLayout = ImageLayout.Stretch;
            titleEx1.Location = new Point(-3, 3);
            titleEx1.Name = "titleEx1";
            titleEx1.Size = new Size(109, 43);
            titleEx1.TabIndex = 0;
            titleEx1.Title = "通信配置";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(130, 14);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 1;
            label1.Text = "IP地址设置";
            // 
            // tbIP
            // 
            tbIP.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbIP.Location = new Point(214, 10);
            tbIP.Name = "tbIP";
            tbIP.Size = new Size(141, 29);
            tbIP.TabIndex = 2;
            // 
            // tbPort
            // 
            tbPort.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbPort.Location = new Point(479, 10);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(141, 29);
            tbPort.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(395, 14);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 3;
            label2.Text = "端口号设置";
            // 
            // btnSureSetting
            // 
            btnSureSetting.FlatStyle = FlatStyle.Flat;
            btnSureSetting.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSureSetting.ForeColor = Color.White;
            btnSureSetting.Location = new Point(873, 7);
            btnSureSetting.Name = "btnSureSetting";
            btnSureSetting.Size = new Size(96, 35);
            btnSureSetting.TabIndex = 5;
            btnSureSetting.Text = "确定设置";
            btnSureSetting.UseVisualStyleBackColor = true;
            btnSureSetting.Click += btnSureSetting_Click;
            // 
            // btnCancelSetting
            // 
            btnCancelSetting.FlatStyle = FlatStyle.Flat;
            btnCancelSetting.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelSetting.ForeColor = Color.White;
            btnCancelSetting.Location = new Point(1004, 7);
            btnCancelSetting.Name = "btnCancelSetting";
            btnCancelSetting.Size = new Size(96, 35);
            btnCancelSetting.TabIndex = 6;
            btnCancelSetting.Text = "取消设置";
            btnCancelSetting.UseVisualStyleBackColor = true;
            btnCancelSetting.Click += btnCancelSetting_Click;
            // 
            // btnGroupConfig
            // 
            btnGroupConfig.FlatStyle = FlatStyle.Flat;
            btnGroupConfig.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnGroupConfig.ForeColor = Color.White;
            btnGroupConfig.Location = new Point(1138, 7);
            btnGroupConfig.Name = "btnGroupConfig";
            btnGroupConfig.Size = new Size(106, 35);
            btnGroupConfig.TabIndex = 7;
            btnGroupConfig.Text = "通信组配置";
            btnGroupConfig.UseVisualStyleBackColor = true;
            btnGroupConfig.Click += btnGroupConfig_Click;
            // 
            // btnVaribleConfig
            // 
            btnVaribleConfig.FlatStyle = FlatStyle.Flat;
            btnVaribleConfig.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnVaribleConfig.ForeColor = Color.White;
            btnVaribleConfig.Location = new Point(1279, 6);
            btnVaribleConfig.Name = "btnVaribleConfig";
            btnVaribleConfig.Size = new Size(96, 35);
            btnVaribleConfig.TabIndex = 8;
            btnVaribleConfig.Text = "变量配置";
            btnVaribleConfig.UseVisualStyleBackColor = true;
            btnVaribleConfig.Click += btnVaribleConfig_Click;
            // 
            // thSetControl1
            // 
            thSetControl1.BackColor = Color.Transparent;
            thSetControl1.CurrentHuBidingVarName = "模块1湿度";
            thSetControl1.CurrentTemBidingVarName = "模块1温度";
            thSetControl1.HAlarmUseBindingVarName = "模块1温度报警启用";
            thSetControl1.HuHeightAlarmBidingVarName = "模块1湿度高";
            thSetControl1.HuHeightBindingVarName = "模块1湿度高限";
            thSetControl1.HuLowAlarmBidingVarName = "模块1湿度低";
            thSetControl1.HuLowBindingVarName = "模块1湿度低限";
            thSetControl1.HumidityHigh = 45F;
            thSetControl1.HumidityLow = 0F;
            thSetControl1.IsHuHeightAlarm = false;
            thSetControl1.IsHuLowAlarm = false;
            thSetControl1.IsHumidityAlarmUse = false;
            thSetControl1.IsTemAlarmUse = false;
            thSetControl1.IsTHeightAlarm = false;
            thSetControl1.IsTLowAlarm = false;
            thSetControl1.Location = new Point(67, 85);
            thSetControl1.Name = "thSetControl1";
            thSetControl1.Size = new Size(322, 285);
            thSetControl1.StationName = "1#站点";
            thSetControl1.TabIndex = 9;
            thSetControl1.TAlarmUseBindingVarName = "模块1湿度报警启用";
            thSetControl1.TemHeightAlarmBidingVarName = "模块1温度高";
            thSetControl1.TemLowAlarmBidingVarName = "模块1温度低";
            thSetControl1.TempratureHigh = 35F;
            thSetControl1.TempratureLow = 0F;
            thSetControl1.THeighBindingVarName = "模块1温度高限";
            thSetControl1.TLowBindingVarName = "模块1温度低限";
            // 
            // thSetControl2
            // 
            thSetControl2.BackColor = Color.Transparent;
            thSetControl2.CurrentHuBidingVarName = "模块2湿度";
            thSetControl2.CurrentTemBidingVarName = "模块2温度";
            thSetControl2.HAlarmUseBindingVarName = "模块2湿度报警启用";
            thSetControl2.HuHeightAlarmBidingVarName = "模块2湿度高";
            thSetControl2.HuHeightBindingVarName = "模块2湿度高限";
            thSetControl2.HuLowAlarmBidingVarName = "模块2湿度低";
            thSetControl2.HuLowBindingVarName = "模块2湿度低限";
            thSetControl2.HumidityHigh = 45F;
            thSetControl2.HumidityLow = 0F;
            thSetControl2.IsHuHeightAlarm = false;
            thSetControl2.IsHuLowAlarm = false;
            thSetControl2.IsHumidityAlarmUse = false;
            thSetControl2.IsTemAlarmUse = false;
            thSetControl2.IsTHeightAlarm = false;
            thSetControl2.IsTLowAlarm = false;
            thSetControl2.Location = new Point(502, 85);
            thSetControl2.Name = "thSetControl2";
            thSetControl2.Size = new Size(322, 285);
            thSetControl2.StationName = "2#站点";
            thSetControl2.TabIndex = 10;
            thSetControl2.TAlarmUseBindingVarName = "模块2温度报警启用";
            thSetControl2.TemHeightAlarmBidingVarName = "模块2温度高";
            thSetControl2.TemLowAlarmBidingVarName = "模块2温度低";
            thSetControl2.TempratureHigh = 35F;
            thSetControl2.TempratureLow = 0F;
            thSetControl2.THeighBindingVarName = "模块2温度高限";
            thSetControl2.TLowBindingVarName = "模块2温度低限";
            // 
            // thSetControl3
            // 
            thSetControl3.BackColor = Color.Transparent;
            thSetControl3.CurrentHuBidingVarName = "模块3湿度";
            thSetControl3.CurrentTemBidingVarName = "模块3温度";
            thSetControl3.HAlarmUseBindingVarName = "模块3湿度报警启用";
            thSetControl3.HuHeightAlarmBidingVarName = "模块3湿度高";
            thSetControl3.HuHeightBindingVarName = "模块3湿度高限";
            thSetControl3.HuLowAlarmBidingVarName = "模块3湿度低";
            thSetControl3.HuLowBindingVarName = "模块3湿度低限";
            thSetControl3.HumidityHigh = 45F;
            thSetControl3.HumidityLow = 0F;
            thSetControl3.IsHuHeightAlarm = false;
            thSetControl3.IsHuLowAlarm = false;
            thSetControl3.IsHumidityAlarmUse = false;
            thSetControl3.IsTemAlarmUse = false;
            thSetControl3.IsTHeightAlarm = false;
            thSetControl3.IsTLowAlarm = false;
            thSetControl3.Location = new Point(930, 85);
            thSetControl3.Name = "thSetControl3";
            thSetControl3.Size = new Size(322, 285);
            thSetControl3.StationName = "3#站点";
            thSetControl3.TabIndex = 11;
            thSetControl3.TAlarmUseBindingVarName = "模块3温度报警启用";
            thSetControl3.TemHeightAlarmBidingVarName = "模块3温度高";
            thSetControl3.TemLowAlarmBidingVarName = "模块3温度低";
            thSetControl3.TempratureHigh = 35F;
            thSetControl3.TempratureLow = 0F;
            thSetControl3.THeighBindingVarName = "模块3温度高限";
            thSetControl3.TLowBindingVarName = "模块3温度低限";
            // 
            // thSetControl4
            // 
            thSetControl4.BackColor = Color.Transparent;
            thSetControl4.CurrentHuBidingVarName = "模块4温度";
            thSetControl4.CurrentTemBidingVarName = "模块4湿度";
            thSetControl4.HAlarmUseBindingVarName = "模块4湿度报警启用";
            thSetControl4.HuHeightAlarmBidingVarName = "模块4湿度高";
            thSetControl4.HuHeightBindingVarName = "模块4湿度高限";
            thSetControl4.HuLowAlarmBidingVarName = "模块4湿度低";
            thSetControl4.HuLowBindingVarName = "模块4湿度低限";
            thSetControl4.HumidityHigh = 45F;
            thSetControl4.HumidityLow = 0F;
            thSetControl4.IsHuHeightAlarm = false;
            thSetControl4.IsHuLowAlarm = false;
            thSetControl4.IsHumidityAlarmUse = false;
            thSetControl4.IsTemAlarmUse = false;
            thSetControl4.IsTHeightAlarm = false;
            thSetControl4.IsTLowAlarm = false;
            thSetControl4.Location = new Point(67, 417);
            thSetControl4.Name = "thSetControl4";
            thSetControl4.Size = new Size(322, 286);
            thSetControl4.StationName = "4#站点";
            thSetControl4.TabIndex = 12;
            thSetControl4.TAlarmUseBindingVarName = "模块4温度报警启用";
            thSetControl4.TemHeightAlarmBidingVarName = "模块4温度高";
            thSetControl4.TemLowAlarmBidingVarName = "模块4温度低";
            thSetControl4.TempratureHigh = 35F;
            thSetControl4.TempratureLow = 0F;
            thSetControl4.THeighBindingVarName = "模块4温度高限";
            thSetControl4.TLowBindingVarName = "模块4温度低限";
            // 
            // thSetControl5
            // 
            thSetControl5.BackColor = Color.Transparent;
            thSetControl5.CurrentHuBidingVarName = "模块5湿度";
            thSetControl5.CurrentTemBidingVarName = "模块5温度";
            thSetControl5.HAlarmUseBindingVarName = "模块5湿度报警启用";
            thSetControl5.HuHeightAlarmBidingVarName = "模块5湿度高";
            thSetControl5.HuHeightBindingVarName = "模块5湿度高限";
            thSetControl5.HuLowAlarmBidingVarName = "模块5湿度低";
            thSetControl5.HuLowBindingVarName = "模块5湿度低限";
            thSetControl5.HumidityHigh = 45F;
            thSetControl5.HumidityLow = 0F;
            thSetControl5.IsHuHeightAlarm = false;
            thSetControl5.IsHuLowAlarm = false;
            thSetControl5.IsHumidityAlarmUse = false;
            thSetControl5.IsTemAlarmUse = false;
            thSetControl5.IsTHeightAlarm = false;
            thSetControl5.IsTLowAlarm = false;
            thSetControl5.Location = new Point(502, 417);
            thSetControl5.Name = "thSetControl5";
            thSetControl5.Size = new Size(322, 286);
            thSetControl5.StationName = "5#站点";
            thSetControl5.TabIndex = 13;
            thSetControl5.TAlarmUseBindingVarName = "模块5温度报警启用";
            thSetControl5.TemHeightAlarmBidingVarName = "模块5温度高";
            thSetControl5.TemLowAlarmBidingVarName = "模块5温度低";
            thSetControl5.TempratureHigh = 35F;
            thSetControl5.TempratureLow = 0F;
            thSetControl5.THeighBindingVarName = "模块5温度高限";
            thSetControl5.TLowBindingVarName = "模块5温度低限";
            // 
            // thSetControl6
            // 
            thSetControl6.BackColor = Color.Transparent;
            thSetControl6.CurrentHuBidingVarName = "模块6湿度";
            thSetControl6.CurrentTemBidingVarName = "模块6温度";
            thSetControl6.HAlarmUseBindingVarName = "模块6湿度报警启用";
            thSetControl6.HuHeightAlarmBidingVarName = "模块6湿度高";
            thSetControl6.HuHeightBindingVarName = "模块6湿度高限";
            thSetControl6.HuLowAlarmBidingVarName = "模块6湿度低";
            thSetControl6.HuLowBindingVarName = "模块6湿度低限";
            thSetControl6.HumidityHigh = 45F;
            thSetControl6.HumidityLow = 0F;
            thSetControl6.IsHuHeightAlarm = false;
            thSetControl6.IsHuLowAlarm = false;
            thSetControl6.IsHumidityAlarmUse = false;
            thSetControl6.IsTemAlarmUse = false;
            thSetControl6.IsTHeightAlarm = false;
            thSetControl6.IsTLowAlarm = false;
            thSetControl6.Location = new Point(930, 417);
            thSetControl6.Name = "thSetControl6";
            thSetControl6.Size = new Size(322, 286);
            thSetControl6.StationName = "6#站点";
            thSetControl6.TabIndex = 14;
            thSetControl6.TAlarmUseBindingVarName = "模块6温度报警启用";
            thSetControl6.TemHeightAlarmBidingVarName = "模块6温度高";
            thSetControl6.TemLowAlarmBidingVarName = "模块6温度低";
            thSetControl6.TempratureHigh = 35F;
            thSetControl6.TempratureLow = 0F;
            thSetControl6.THeighBindingVarName = "模块6温度高限";
            thSetControl6.TLowBindingVarName = "模块6温度低限";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // FrmParamSet
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(thSetControl6);
            Controls.Add(thSetControl5);
            Controls.Add(thSetControl4);
            Controls.Add(thSetControl3);
            Controls.Add(thSetControl2);
            Controls.Add(thSetControl1);
            Controls.Add(btnVaribleConfig);
            Controls.Add(btnGroupConfig);
            Controls.Add(btnCancelSetting);
            Controls.Add(btnSureSetting);
            Controls.Add(tbPort);
            Controls.Add(label2);
            Controls.Add(tbIP);
            Controls.Add(label1);
            Controls.Add(titleEx1);
            Name = "FrmParamSet";
            Size = new Size(1440, 960);
            Load += FrmParamSet_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.TitleEx titleEx1;
        private Label label1;
        private TextBox tbIP;
        private TextBox tbPort;
        private Label label2;
        private Button btnSureSetting;
        private Button btnCancelSetting;
        private Button btnGroupConfig;
        private Button btnVaribleConfig;
        private Controls.THSetControl thSetControl1;
        private Controls.THSetControl thSetControl2;
        private Controls.THSetControl thSetControl3;
        private Controls.THSetControl thSetControl4;
        private Controls.THSetControl thSetControl5;
        private Controls.THSetControl thSetControl6;
        private System.Windows.Forms.Timer timer1;
    }
}
