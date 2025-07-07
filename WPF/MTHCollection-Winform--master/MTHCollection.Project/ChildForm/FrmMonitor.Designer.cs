namespace MTHCollection.Project.ChildForm
{
    partial class FrmMonitor
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
            ColumnHeader columnHeader1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMonitor));
            timer1 = new System.Windows.Forms.Timer(components);
            thMonitorControl6 = new Controls.THMonitorControl();
            thMonitorControl5 = new Controls.THMonitorControl();
            thMonitorControl4 = new Controls.THMonitorControl();
            thMonitorControl3 = new Controls.THMonitorControl();
            thMonitorControl2 = new Controls.THMonitorControl();
            thMonitorControl1 = new Controls.THMonitorControl();
            titleEx2 = new Controls.TitleEx();
            titleEx1 = new Controls.TitleEx();
            imageList1 = new ImageList(components);
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            listView1 = new ListView();
            columnHeader4 = new ColumnHeader();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            ckT1 = new Sunny.UI.UICheckBox();
            ckH1 = new Sunny.UI.UICheckBox();
            ckT2 = new Sunny.UI.UICheckBox();
            ckH2 = new Sunny.UI.UICheckBox();
            CKH4 = new Sunny.UI.UICheckBox();
            ckT4 = new Sunny.UI.UICheckBox();
            ckH3 = new Sunny.UI.UICheckBox();
            ckT3 = new Sunny.UI.UICheckBox();
            ckH6 = new Sunny.UI.UICheckBox();
            ckT6 = new Sunny.UI.UICheckBox();
            ckH5 = new Sunny.UI.UICheckBox();
            ckT5 = new Sunny.UI.UICheckBox();
            columnHeader1 = new ColumnHeader();
            SuspendLayout();
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "图标";
            columnHeader1.Width = 100;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // thMonitorControl6
            // 
            thMonitorControl6.BackColor = Color.Transparent;
            thMonitorControl6.Humidity = 0F;
            thMonitorControl6.Location = new Point(369, 504);
            thMonitorControl6.Name = "thMonitorControl6";
            thMonitorControl6.Size = new Size(283, 177);
            thMonitorControl6.StationName = "6#站点";
            thMonitorControl6.TabIndex = 66;
            thMonitorControl6.Teamperature = 0F;
            // 
            // thMonitorControl5
            // 
            thMonitorControl5.BackColor = Color.Transparent;
            thMonitorControl5.Humidity = 0F;
            thMonitorControl5.Location = new Point(38, 504);
            thMonitorControl5.Name = "thMonitorControl5";
            thMonitorControl5.Size = new Size(283, 177);
            thMonitorControl5.StationName = "5#站点";
            thMonitorControl5.TabIndex = 65;
            thMonitorControl5.Teamperature = 0F;
            // 
            // thMonitorControl4
            // 
            thMonitorControl4.BackColor = Color.Transparent;
            thMonitorControl4.Humidity = 0F;
            thMonitorControl4.Location = new Point(369, 249);
            thMonitorControl4.Name = "thMonitorControl4";
            thMonitorControl4.Size = new Size(283, 177);
            thMonitorControl4.StationName = "4#站点";
            thMonitorControl4.TabIndex = 64;
            thMonitorControl4.Teamperature = 0F;
            // 
            // thMonitorControl3
            // 
            thMonitorControl3.BackColor = Color.Transparent;
            thMonitorControl3.Humidity = 0F;
            thMonitorControl3.Location = new Point(38, 249);
            thMonitorControl3.Name = "thMonitorControl3";
            thMonitorControl3.Size = new Size(283, 177);
            thMonitorControl3.StationName = "3#站点";
            thMonitorControl3.TabIndex = 63;
            thMonitorControl3.Teamperature = 0F;
            // 
            // thMonitorControl2
            // 
            thMonitorControl2.BackColor = Color.Transparent;
            thMonitorControl2.Humidity = 0F;
            thMonitorControl2.Location = new Point(369, 14);
            thMonitorControl2.Name = "thMonitorControl2";
            thMonitorControl2.Size = new Size(283, 177);
            thMonitorControl2.StationName = "2#站点";
            thMonitorControl2.TabIndex = 62;
            thMonitorControl2.Teamperature = 0F;
            // 
            // thMonitorControl1
            // 
            thMonitorControl1.BackColor = Color.Transparent;
            thMonitorControl1.Humidity = 0F;
            thMonitorControl1.Location = new Point(38, 14);
            thMonitorControl1.Name = "thMonitorControl1";
            thMonitorControl1.Size = new Size(283, 177);
            thMonitorControl1.StationName = "1#站点";
            thMonitorControl1.TabIndex = 61;
            thMonitorControl1.Teamperature = 0F;
            // 
            // titleEx2
            // 
            titleEx2.BackColor = Color.Transparent;
            titleEx2.BackgroundImage = (Image)resources.GetObject("titleEx2.BackgroundImage");
            titleEx2.BackgroundImageLayout = ImageLayout.Stretch;
            titleEx2.Location = new Point(748, 542);
            titleEx2.Name = "titleEx2";
            titleEx2.Size = new Size(121, 36);
            titleEx2.TabIndex = 47;
            titleEx2.Title = "系统日志";
            // 
            // titleEx1
            // 
            titleEx1.BackColor = Color.Transparent;
            titleEx1.BackgroundImage = (Image)resources.GetObject("titleEx1.BackgroundImage");
            titleEx1.BackgroundImageLayout = ImageLayout.Stretch;
            titleEx1.Location = new Point(777, 0);
            titleEx1.Name = "titleEx1";
            titleEx1.Size = new Size(121, 36);
            titleEx1.TabIndex = 46;
            titleEx1.Title = "实时趋势";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "error.png");
            imageList1.Images.SetKeyName(1, "info.png");
            imageList1.Images.SetKeyName(2, "warning.png");
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "图标";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "时间";
            columnHeader3.Width = 200;
            // 
            // listView1
            // 
            listView1.BackColor = Color.FromArgb(5, 28, 68);
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader2, columnHeader3, columnHeader4 });
            listView1.Location = new Point(815, 602);
            listView1.Name = "listView1";
            listView1.Size = new Size(447, 220);
            listView1.SmallImageList = imageList1;
            listView1.TabIndex = 45;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "信息";
            columnHeader4.Width = 200;
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Location = new Point(815, 42);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(602, 301);
            formsPlot1.TabIndex = 67;
            // 
            // ckT1
            // 
            ckT1.CheckBoxColor = Color.DarkCyan;
            ckT1.Checked = true;
            ckT1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckT1.ForeColor = Color.White;
            ckT1.Location = new Point(837, 360);
            ckT1.MinimumSize = new Size(1, 1);
            ckT1.Name = "ckT1";
            ckT1.Size = new Size(150, 29);
            ckT1.TabIndex = 68;
            ckT1.Tag = "模块1温度";
            ckT1.Text = "1#站点温度";
            // 
            // ckH1
            // 
            ckH1.CheckBoxColor = Color.DarkCyan;
            ckH1.Checked = true;
            ckH1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckH1.ForeColor = Color.White;
            ckH1.Location = new Point(993, 360);
            ckH1.MinimumSize = new Size(1, 1);
            ckH1.Name = "ckH1";
            ckH1.Size = new Size(150, 29);
            ckH1.TabIndex = 69;
            ckH1.Tag = "模块1湿度";
            ckH1.Text = "1#站点湿度";
            // 
            // ckT2
            // 
            ckT2.CheckBoxColor = Color.DarkCyan;
            ckT2.Checked = true;
            ckT2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckT2.ForeColor = Color.White;
            ckT2.Location = new Point(1149, 360);
            ckT2.MinimumSize = new Size(1, 1);
            ckT2.Name = "ckT2";
            ckT2.Size = new Size(150, 29);
            ckT2.TabIndex = 70;
            ckT2.Tag = "模块2温度";
            ckT2.Text = "2#站点温度";
            // 
            // ckH2
            // 
            ckH2.CheckBoxColor = Color.DarkCyan;
            ckH2.Checked = true;
            ckH2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckH2.ForeColor = Color.White;
            ckH2.Location = new Point(1287, 360);
            ckH2.MinimumSize = new Size(1, 1);
            ckH2.Name = "ckH2";
            ckH2.Size = new Size(150, 29);
            ckH2.TabIndex = 71;
            ckH2.Tag = "模块2湿度";
            ckH2.Text = "2#站点湿度";
            // 
            // CKH4
            // 
            CKH4.CheckBoxColor = Color.DarkCyan;
            CKH4.Checked = true;
            CKH4.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CKH4.ForeColor = Color.White;
            CKH4.Location = new Point(1287, 397);
            CKH4.MinimumSize = new Size(1, 1);
            CKH4.Name = "CKH4";
            CKH4.Size = new Size(150, 29);
            CKH4.TabIndex = 75;
            CKH4.Tag = "模块4湿度";
            CKH4.Text = "4#站点湿度";
            // 
            // ckT4
            // 
            ckT4.CheckBoxColor = Color.DarkCyan;
            ckT4.Checked = true;
            ckT4.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckT4.ForeColor = Color.White;
            ckT4.Location = new Point(1149, 397);
            ckT4.MinimumSize = new Size(1, 1);
            ckT4.Name = "ckT4";
            ckT4.Size = new Size(150, 29);
            ckT4.TabIndex = 74;
            ckT4.Tag = "模块4温度";
            ckT4.Text = "4#站点温度";
            // 
            // ckH3
            // 
            ckH3.CheckBoxColor = Color.DarkCyan;
            ckH3.Checked = true;
            ckH3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckH3.ForeColor = Color.White;
            ckH3.Location = new Point(993, 397);
            ckH3.MinimumSize = new Size(1, 1);
            ckH3.Name = "ckH3";
            ckH3.Size = new Size(150, 29);
            ckH3.TabIndex = 73;
            ckH3.Tag = "模块3湿度";
            ckH3.Text = "3#站点湿度";
            // 
            // ckT3
            // 
            ckT3.CheckBoxColor = Color.DarkCyan;
            ckT3.Checked = true;
            ckT3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckT3.ForeColor = Color.White;
            ckT3.Location = new Point(837, 397);
            ckT3.MinimumSize = new Size(1, 1);
            ckT3.Name = "ckT3";
            ckT3.Size = new Size(150, 29);
            ckT3.TabIndex = 72;
            ckT3.Tag = "模块3温度";
            ckT3.Text = "3#站点温度";
            // 
            // ckH6
            // 
            ckH6.CheckBoxColor = Color.DarkCyan;
            ckH6.Checked = true;
            ckH6.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckH6.ForeColor = Color.White;
            ckH6.Location = new Point(1287, 432);
            ckH6.MinimumSize = new Size(1, 1);
            ckH6.Name = "ckH6";
            ckH6.Size = new Size(150, 29);
            ckH6.TabIndex = 79;
            ckH6.Tag = "模块6湿度";
            ckH6.Text = "6#站点湿度";
            // 
            // ckT6
            // 
            ckT6.CheckBoxColor = Color.DarkCyan;
            ckT6.Checked = true;
            ckT6.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckT6.ForeColor = Color.White;
            ckT6.Location = new Point(1149, 432);
            ckT6.MinimumSize = new Size(1, 1);
            ckT6.Name = "ckT6";
            ckT6.Size = new Size(150, 29);
            ckT6.TabIndex = 78;
            ckT6.Tag = "模块6温度";
            ckT6.Text = "6#站点温度";
            // 
            // ckH5
            // 
            ckH5.CheckBoxColor = Color.DarkCyan;
            ckH5.Checked = true;
            ckH5.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckH5.ForeColor = Color.White;
            ckH5.Location = new Point(993, 432);
            ckH5.MinimumSize = new Size(1, 1);
            ckH5.Name = "ckH5";
            ckH5.Size = new Size(150, 29);
            ckH5.TabIndex = 77;
            ckH5.Tag = "模块5湿度";
            ckH5.Text = "5#站点湿度";
            // 
            // ckT5
            // 
            ckT5.CheckBoxColor = Color.DarkCyan;
            ckT5.Checked = true;
            ckT5.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckT5.ForeColor = Color.White;
            ckT5.Location = new Point(837, 432);
            ckT5.MinimumSize = new Size(1, 1);
            ckT5.Name = "ckT5";
            ckT5.Size = new Size(150, 29);
            ckT5.TabIndex = 76;
            ckT5.Tag = "模块5温度";
            ckT5.Text = "5#站点温度";
            // 
            // FrmMonitor
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(ckH6);
            Controls.Add(ckT6);
            Controls.Add(ckH5);
            Controls.Add(ckT5);
            Controls.Add(CKH4);
            Controls.Add(ckT4);
            Controls.Add(ckH3);
            Controls.Add(ckT3);
            Controls.Add(ckH2);
            Controls.Add(ckT2);
            Controls.Add(ckH1);
            Controls.Add(ckT1);
            Controls.Add(formsPlot1);
            Controls.Add(thMonitorControl6);
            Controls.Add(thMonitorControl5);
            Controls.Add(thMonitorControl4);
            Controls.Add(thMonitorControl3);
            Controls.Add(thMonitorControl2);
            Controls.Add(thMonitorControl1);
            Controls.Add(titleEx2);
            Controls.Add(titleEx1);
            Controls.Add(listView1);
            ForeColor = Color.White;
            Name = "FrmMonitor";
            Size = new Size(1440, 960);
            Load += FrmMonitor_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Controls.THMonitorControl thMonitorControl6;
        private Controls.THMonitorControl thMonitorControl5;
        private Controls.THMonitorControl thMonitorControl4;
        private Controls.THMonitorControl thMonitorControl3;
        private Controls.THMonitorControl thMonitorControl2;
        private Controls.THMonitorControl thMonitorControl1;
        private Controls.TitleEx titleEx2;
        private Controls.TitleEx titleEx1;
        private ImageList imageList1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ListView listView1;
        private ColumnHeader columnHeader4;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private Sunny.UI.UICheckBox ckT1;
        private Sunny.UI.UICheckBox ckH1;
        private Sunny.UI.UICheckBox ckT2;
        private Sunny.UI.UICheckBox ckH2;
        private Sunny.UI.UICheckBox CKH4;
        private Sunny.UI.UICheckBox ckT4;
        private Sunny.UI.UICheckBox ckH3;
        private Sunny.UI.UICheckBox ckT3;
        private Sunny.UI.UICheckBox ckH6;
        private Sunny.UI.UICheckBox ckT6;
        private Sunny.UI.UICheckBox ckH5;
        private Sunny.UI.UICheckBox ckT5;
    }
}
