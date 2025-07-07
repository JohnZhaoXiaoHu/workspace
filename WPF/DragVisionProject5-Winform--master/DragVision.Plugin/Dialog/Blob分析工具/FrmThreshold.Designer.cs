namespace DragVision.Plugin.Dialog.Blob分析工具
{
    partial class FrmThreshold
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
            splitContainer1 = new SplitContainer();
            halconDisplayControl1 = new Controls.HalconDisplayControl();
            textMaxGray = new TextBox();
            textMinGray = new TextBox();
            label2 = new Label();
            labMinValue = new Label();
            trackBarMinGray = new TrackBar();
            trackBarMaxGray = new TrackBar();
            btnExcuteComplete = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarMinGray).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarMaxGray).BeginInit();
            SuspendLayout();
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
            splitContainer1.Panel2.Controls.Add(textMaxGray);
            splitContainer1.Panel2.Controls.Add(textMinGray);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(labMinValue);
            splitContainer1.Panel2.Controls.Add(trackBarMinGray);
            splitContainer1.Panel2.Controls.Add(trackBarMaxGray);
            splitContainer1.Panel2.Controls.Add(btnExcuteComplete);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 494;
            splitContainer1.TabIndex = 2;
            // 
            // halconDisplayControl1
            // 
            halconDisplayControl1.Dock = DockStyle.Fill;
            halconDisplayControl1.Location = new Point(0, 0);
            halconDisplayControl1.Name = "halconDisplayControl1";
            halconDisplayControl1.Size = new Size(494, 450);
            halconDisplayControl1.TabIndex = 0;
            // 
            // textMaxGray
            // 
            textMaxGray.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            textMaxGray.Location = new Point(120, 139);
            textMaxGray.Name = "textMaxGray";
            textMaxGray.Size = new Size(108, 26);
            textMaxGray.TabIndex = 7;
            // 
            // textMinGray
            // 
            textMinGray.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            textMinGray.Location = new Point(120, 43);
            textMinGray.Name = "textMinGray";
            textMinGray.Size = new Size(108, 26);
            textMinGray.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(7, 107);
            label2.Name = "label2";
            label2.Size = new Size(78, 21);
            label2.TabIndex = 5;
            label2.Text = "最大灰度:";
            // 
            // labMinValue
            // 
            labMinValue.AutoSize = true;
            labMinValue.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labMinValue.Location = new Point(5, 14);
            labMinValue.Name = "labMinValue";
            labMinValue.Size = new Size(78, 21);
            labMinValue.TabIndex = 4;
            labMinValue.Text = "最小灰度:";
            // 
            // trackBarMinGray
            // 
            trackBarMinGray.Location = new Point(96, 12);
            trackBarMinGray.Maximum = 255;
            trackBarMinGray.Name = "trackBarMinGray";
            trackBarMinGray.Size = new Size(164, 45);
            trackBarMinGray.TabIndex = 3;
            trackBarMinGray.ValueChanged += trackBar_ValueChanged;
            // 
            // trackBarMaxGray
            // 
            trackBarMaxGray.Location = new Point(91, 108);
            trackBarMaxGray.Maximum = 255;
            trackBarMaxGray.Name = "trackBarMaxGray";
            trackBarMaxGray.Size = new Size(164, 45);
            trackBarMaxGray.TabIndex = 2;
            trackBarMaxGray.ValueChanged += trackBar_ValueChanged;
            // 
            // btnExcuteComplete
            // 
            btnExcuteComplete.BackColor = Color.Teal;
            btnExcuteComplete.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnExcuteComplete.ForeColor = Color.White;
            btnExcuteComplete.Location = new Point(81, 239);
            btnExcuteComplete.Name = "btnExcuteComplete";
            btnExcuteComplete.Size = new Size(130, 50);
            btnExcuteComplete.TabIndex = 1;
            btnExcuteComplete.Text = "执行完成";
            btnExcuteComplete.UseVisualStyleBackColor = false;
            btnExcuteComplete.Click += btnExcuteComplete_Click;
            // 
            // FrmThreshold
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "FrmThreshold";
            Text = "FrmThreshold";
            Load += FrmThreshold_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackBarMinGray).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarMaxGray).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Controls.HalconDisplayControl halconDisplayControl1;
        private Label label2;
        private Label labMinValue;
        private TrackBar trackBarMinGray;
        private TrackBar trackBarMaxGray;
        private Button btnExcuteComplete;
        private TextBox textMaxGray;
        private TextBox textMinGray;
    }
}