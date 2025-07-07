namespace MTHCollection.Controls
{
    partial class THMonitorControl
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
            meterH = new Sunny.UI.UIAnalogMeter();
            meterT = new Sunny.UI.UIAnalogMeter();
            label5 = new Label();
            labH = new Label();
            label7 = new Label();
            label4 = new Label();
            labT = new Label();
            label1 = new Label();
            labStationName = new Label();
            SuspendLayout();
            // 
            // meterH
            // 
            meterH.BodyColor = Color.FromArgb(192, 192, 255);
            meterH.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            meterH.Location = new Point(154, 38);
            meterH.MaxValue = 1000D;
            meterH.MinimumSize = new Size(1, 1);
            meterH.MinValue = 0D;
            meterH.Name = "meterH";
            meterH.Renderer = null;
            meterH.Size = new Size(136, 88);
            meterH.TabIndex = 58;
            meterH.Text = "uiAnalogMeter2";
            meterH.Value = 0D;
            // 
            // meterT
            // 
            meterT.BodyColor = Color.FromArgb(255, 192, 192);
            meterT.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            meterT.Location = new Point(12, 38);
            meterT.MaxValue = 1000D;
            meterT.MinimumSize = new Size(1, 1);
            meterT.MinValue = 0D;
            meterT.Name = "meterT";
            meterT.Renderer = null;
            meterT.Size = new Size(136, 88);
            meterT.TabIndex = 57;
            meterT.Text = "uiAnalogMeter1";
            meterT.Value = 0D;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Cyan;
            label5.Location = new Point(239, 142);
            label5.Name = "label5";
            label5.Size = new Size(24, 21);
            label5.TabIndex = 56;
            label5.Text = "%";
            // 
            // labH
            // 
            labH.AutoSize = true;
            labH.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labH.ForeColor = Color.Cyan;
            labH.Location = new Point(201, 142);
            labH.Name = "labH";
            labH.Size = new Size(32, 21);
            labH.TabIndex = 55;
            labH.Text = "0.0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(165, 142);
            label7.Name = "label7";
            label7.Size = new Size(42, 21);
            label7.TabIndex = 54;
            label7.Text = "湿度";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Cyan;
            label4.Location = new Point(89, 142);
            label4.Name = "label4";
            label4.Size = new Size(26, 21);
            label4.TabIndex = 53;
            label4.Text = "℃";
            // 
            // labT
            // 
            labT.AutoSize = true;
            labT.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labT.ForeColor = Color.Cyan;
            labT.Location = new Point(51, 142);
            labT.Name = "labT";
            labT.Size = new Size(32, 21);
            labT.TabIndex = 52;
            labT.Text = "0.0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 142);
            label1.Name = "label1";
            label1.Size = new Size(42, 21);
            label1.TabIndex = 51;
            label1.Text = "温度";
            // 
            // labStationName
            // 
            labStationName.AutoSize = true;
            labStationName.BackColor = Color.MediumTurquoise;
            labStationName.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labStationName.ForeColor = Color.White;
            labStationName.Location = new Point(22, 2);
            labStationName.Name = "labStationName";
            labStationName.Size = new Size(61, 21);
            labStationName.TabIndex = 50;
            labStationName.Text = "1#站点";
            // 
            // THMonitorControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(meterH);
            Controls.Add(meterT);
            Controls.Add(label5);
            Controls.Add(labH);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(labT);
            Controls.Add(label1);
            Controls.Add(labStationName);
            Name = "THMonitorControl";
            Size = new Size(283, 177);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Sunny.UI.UIAnalogMeter meterH;
        private Sunny.UI.UIAnalogMeter meterT;
        private Label label5;
        private Label labH;
        private Label label7;
        private Label label4;
        private Label labT;
        private Label label1;
        private Label labStationName;
    }
}
