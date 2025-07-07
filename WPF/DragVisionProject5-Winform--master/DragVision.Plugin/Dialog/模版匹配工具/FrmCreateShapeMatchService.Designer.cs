namespace DragVision.Plugin.Dialog.模版匹配工具
{
    partial class FrmCreateShapeMatchService
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            halconDisplayControl1 = new Controls.HalconDisplayControl();
            splitContainer1 = new SplitContainer();
            btnClear = new Button();
            btnDrawROI = new Button();
            btnSaveModel = new Button();
            cbMinContrast = new ComboBox();
            label9 = new Label();
            cbContrast = new ComboBox();
            label8 = new Label();
            cbMetric = new ComboBox();
            label7 = new Label();
            cbOptimization = new ComboBox();
            label6 = new Label();
            textAngleStep = new TextBox();
            label5 = new Label();
            textAngleStop = new TextBox();
            label4 = new Label();
            textAngleStart = new TextBox();
            label3 = new Label();
            cbNumLevels = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            btnExcuteComplete = new Button();
            btnCreateModel = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // halconDisplayControl1
            // 
            halconDisplayControl1.Dock = DockStyle.Fill;
            halconDisplayControl1.Location = new Point(0, 0);
            halconDisplayControl1.Name = "halconDisplayControl1";
            halconDisplayControl1.Size = new Size(661, 572);
            halconDisplayControl1.TabIndex = 0;
            halconDisplayControl1.Load += halconDisplayControl1_Load;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(halconDisplayControl1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnClear);
            splitContainer1.Panel2.Controls.Add(btnDrawROI);
            splitContainer1.Panel2.Controls.Add(btnSaveModel);
            splitContainer1.Panel2.Controls.Add(cbMinContrast);
            splitContainer1.Panel2.Controls.Add(label9);
            splitContainer1.Panel2.Controls.Add(cbContrast);
            splitContainer1.Panel2.Controls.Add(label8);
            splitContainer1.Panel2.Controls.Add(cbMetric);
            splitContainer1.Panel2.Controls.Add(label7);
            splitContainer1.Panel2.Controls.Add(cbOptimization);
            splitContainer1.Panel2.Controls.Add(label6);
            splitContainer1.Panel2.Controls.Add(textAngleStep);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(textAngleStop);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(textAngleStart);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(cbNumLevels);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(btnExcuteComplete);
            splitContainer1.Panel2.Controls.Add(btnCreateModel);
            splitContainer1.Size = new Size(1069, 572);
            splitContainer1.SplitterDistance = 661;
            splitContainer1.TabIndex = 1;
            //splitContainer1.SplitterMoved += this.splitContainer1_SplitterMoved;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Teal;
            btnClear.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(210, 441);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(130, 50);
            btnClear.TabIndex = 21;
            btnClear.Text = "清空";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDrawROI
            // 
            btnDrawROI.BackColor = Color.Teal;
            btnDrawROI.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnDrawROI.ForeColor = Color.White;
            btnDrawROI.Location = new Point(20, 441);
            btnDrawROI.Name = "btnDrawROI";
            btnDrawROI.Size = new Size(130, 50);
            btnDrawROI.TabIndex = 20;
            btnDrawROI.Text = "绘制ROI区域";
            btnDrawROI.UseVisualStyleBackColor = false;
            btnDrawROI.Click += btnDrawROI_Click;
            // 
            // btnSaveModel
            // 
            btnSaveModel.BackColor = Color.Teal;
            btnSaveModel.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnSaveModel.ForeColor = Color.White;
            btnSaveModel.Location = new Point(210, 370);
            btnSaveModel.Name = "btnSaveModel";
            btnSaveModel.Size = new Size(130, 50);
            btnSaveModel.TabIndex = 19;
            btnSaveModel.Text = "保存模板";
            btnSaveModel.UseVisualStyleBackColor = false;
            btnSaveModel.Click += btnSaveModel_Click;
            // 
            // cbMinContrast
            // 
            cbMinContrast.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            cbMinContrast.FormattingEnabled = true;
            cbMinContrast.Items.AddRange(new object[] { "auto", "1", "2", "3", "5", "7", "10", "20", "30", "40" });
            cbMinContrast.Location = new Point(154, 313);
            cbMinContrast.Name = "cbMinContrast";
            cbMinContrast.Size = new Size(147, 28);
            cbMinContrast.TabIndex = 18;
            cbMinContrast.Text = "auto";
            //cbMinContrast.SelectedIndexChanged += this.cbMinContrast_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(29, 322);
            label9.Name = "label9";
            label9.Size = new Size(83, 19);
            label9.TabIndex = 17;
            label9.Text = "最小对比度:";
            //label9.Click += this.label9_Click;
            // 
            // cbContrast
            // 
            cbContrast.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            cbContrast.FormattingEnabled = true;
            cbContrast.Items.AddRange(new object[] { "10,", "20", "30", "40", "60", "80", "100", "120", "140", "160", "auto" });
            cbContrast.Location = new Point(153, 273);
            cbContrast.Name = "cbContrast";
            cbContrast.Size = new Size(147, 28);
            cbContrast.TabIndex = 16;
            cbContrast.Text = "auto";
            //cbContrast.SelectedIndexChanged += this.cbContrast_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(59, 277);
            label8.Name = "label8";
            label8.Size = new Size(55, 19);
            label8.TabIndex = 15;
            label8.Text = "对比度:";
            //label8.Click += this.label8_Click;
            // 
            // cbMetric
            // 
            cbMetric.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            cbMetric.FormattingEnabled = true;
            cbMetric.Items.AddRange(new object[] { "ignore_color_polarity", "ignore_global_polarity", "ignore_local_polarity", "use_polarity" });
            cbMetric.Location = new Point(153, 232);
            cbMetric.Name = "cbMetric";
            cbMetric.Size = new Size(147, 28);
            cbMetric.TabIndex = 14;
            cbMetric.Text = "use_polarity";
            //cbMetric.SelectedIndexChanged += this.cbMetric_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(80, 241);
            label7.Name = "label7";
            label7.Size = new Size(41, 19);
            label7.TabIndex = 13;
            label7.Text = "极性:";
            //label7.Click += this.label7_Click;
            // 
            // cbOptimization
            // 
            cbOptimization.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            cbOptimization.FormattingEnabled = true;
            cbOptimization.Items.AddRange(new object[] { "auto", "no_pregeneration", "none", "point_reduction_high", "point_reduction_low", "point_reduction_medium", "pregeneration" });
            cbOptimization.Location = new Point(153, 192);
            cbOptimization.Name = "cbOptimization";
            cbOptimization.Size = new Size(147, 28);
            cbOptimization.TabIndex = 12;
            cbOptimization.Text = "auto";
            //cbOptimization.SelectedIndexChanged += this.cbOptimization_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(52, 196);
            label6.Name = "label6";
            label6.Size = new Size(69, 19);
            label6.TabIndex = 11;
            label6.Text = "优化方式:";
            //label6.Click += this.label6_Click;
            // 
            // textAngleStep
            // 
            textAngleStep.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            textAngleStep.Location = new Point(153, 155);
            textAngleStep.Name = "textAngleStep";
            textAngleStep.Size = new Size(147, 26);
            textAngleStep.TabIndex = 10;
            textAngleStep.Text = "0.79";
            //textAngleStep.TextChanged += this.textAngleStep_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(52, 159);
            label5.Name = "label5";
            label5.Size = new Size(69, 19);
            label5.TabIndex = 9;
            label5.Text = "角度步长:";
            //label5.Click += this.label5_Click;
            // 
            // textAngleStop
            // 
            textAngleStop.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            textAngleStop.Location = new Point(153, 117);
            textAngleStop.Name = "textAngleStop";
            textAngleStop.Size = new Size(147, 26);
            textAngleStop.TabIndex = 8;
            textAngleStop.Text = "360";
           // textAngleStop.TextChanged += this.textAngleStop_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(52, 121);
            label4.Name = "label4";
            label4.Size = new Size(69, 19);
            label4.TabIndex = 7;
            label4.Text = "终止角度:";
            //label4.Click += this.label4_Click;
            // 
            // textAngleStart
            // 
            textAngleStart.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            textAngleStart.Location = new Point(153, 78);
            textAngleStart.Name = "textAngleStart";
            textAngleStart.Size = new Size(147, 26);
            textAngleStart.TabIndex = 6;
            textAngleStart.Text = "0";
            //textAngleStart.TextChanged += this.textAngleStart_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(52, 82);
            label3.Name = "label3";
            label3.Size = new Size(69, 19);
            label3.TabIndex = 5;
            label3.Text = "起始角度:";
            //label3.Click += this.label3_Click;
            // 
            // cbNumLevels
            // 
            cbNumLevels.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            cbNumLevels.FormattingEnabled = true;
            cbNumLevels.Items.AddRange(new object[] { "auto", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbNumLevels.Location = new Point(153, 38);
            cbNumLevels.Name = "cbNumLevels";
            cbNumLevels.Size = new Size(147, 28);
            cbNumLevels.TabIndex = 4;
            cbNumLevels.Text = "auto";
            //cbNumLevels.SelectedIndexChanged += this.cbNumLevels_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(52, 39);
            label2.Name = "label2";
            label2.Size = new Size(83, 19);
            label2.TabIndex = 3;
            label2.Text = "金字塔层数:";
            //label2.Click += this.label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(141, 9);
            label1.Name = "label1";
            label1.Size = new Size(170, 22);
            label1.TabIndex = 2;
            label1.Text = "创建形状匹配模板参数";
            //label1.Click += this.label1_Click;
            // 
            // btnExcuteComplete
            // 
            btnExcuteComplete.BackColor = Color.Teal;
            btnExcuteComplete.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnExcuteComplete.ForeColor = Color.White;
            btnExcuteComplete.Location = new Point(20, 513);
            btnExcuteComplete.Name = "btnExcuteComplete";
            btnExcuteComplete.Size = new Size(130, 50);
            btnExcuteComplete.TabIndex = 1;
            btnExcuteComplete.Text = "执行完成";
            btnExcuteComplete.UseVisualStyleBackColor = false;
            btnExcuteComplete.Click += btnExcuteComplete_Click;
            // 
            // btnCreateModel
            // 
            btnCreateModel.BackColor = Color.Teal;
            btnCreateModel.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnCreateModel.ForeColor = Color.White;
            btnCreateModel.Location = new Point(20, 370);
            btnCreateModel.Name = "btnCreateModel";
            btnCreateModel.Size = new Size(130, 50);
            btnCreateModel.TabIndex = 0;
            btnCreateModel.Text = "创建模板";
            btnCreateModel.UseVisualStyleBackColor = false;
            btnCreateModel.Click += btnCreateModel_Click;
            // 
            // FrmCreateShapeMatchService
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1069, 572);
            Controls.Add(splitContainer1);
            Name = "FrmCreateShapeMatchService";
            Text = "FrmCreateShapeMatchService";
            Load += FrmCreateShapeMatchService_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Controls.HalconDisplayControl halconDisplayControl1;
        private SplitContainer splitContainer1;
        private Label label2;
        private Label label1;
        private Button btnExcuteComplete;
        private Button btnCreateModel;
        private ComboBox cbOptimization;
        private Label label6;
        private TextBox textAngleStep;
        private Label label5;
        private TextBox textAngleStop;
        private Label label4;
        private TextBox textAngleStart;
        private Label label3;
        private ComboBox cbNumLevels;
        private Label label9;
        private ComboBox cbContrast;
        private Label label8;
        private ComboBox cbMetric;
        private Label label7;
        private Button btnSaveModel;
        private ComboBox cbMinContrast;
        private Button btnClear;
        private Button btnDrawROI;
    }
}