namespace MTHCollection.Controls
{
    partial class RecipeControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipeControl));
            titleEx = new TitleEx();
            labTemHeigh = new Label();
            ndTemHeigh = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            ndTemLow = new NumericUpDown();
            labTemLow = new Label();
            label5 = new Label();
            ndHumidityHeigh = new NumericUpDown();
            labHumidityHeigh = new Label();
            label7 = new Label();
            ndHumidityLow = new NumericUpDown();
            labHumidityLow = new Label();
            ckTemAlarmUse = new Sunny.UI.UICheckBox();
            ckHumidityAlarmUse = new Sunny.UI.UICheckBox();
            ((System.ComponentModel.ISupportInitialize)ndTemHeigh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ndTemLow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ndHumidityHeigh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ndHumidityLow).BeginInit();
            SuspendLayout();
            // 
            // titleEx
            // 
            titleEx.BackColor = Color.Transparent;
            titleEx.BackgroundImage = (Image)resources.GetObject("titleEx.BackgroundImage");
            titleEx.BackgroundImageLayout = ImageLayout.Stretch;
            titleEx.Location = new Point(15, 1);
            titleEx.Margin = new Padding(4, 3, 4, 3);
            titleEx.Name = "titleEx";
            titleEx.Size = new Size(93, 33);
            titleEx.TabIndex = 0;
            titleEx.Title = "1#站点";
            // 
            // labTemHeigh
            // 
            labTemHeigh.AutoSize = true;
            labTemHeigh.BackColor = Color.Transparent;
            labTemHeigh.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labTemHeigh.ForeColor = Color.White;
            labTemHeigh.Location = new Point(24, 48);
            labTemHeigh.Margin = new Padding(4, 0, 4, 0);
            labTemHeigh.Name = "labTemHeigh";
            labTemHeigh.Size = new Size(125, 21);
            labTemHeigh.TabIndex = 1;
            labTemHeigh.Text = "1#站点温度高限";
            // 
            // ndTemHeigh
            // 
            ndTemHeigh.DecimalPlaces = 1;
            ndTemHeigh.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ndTemHeigh.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            ndTemHeigh.Location = new Point(171, 46);
            ndTemHeigh.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            ndTemHeigh.Name = "ndTemHeigh";
            ndTemHeigh.Size = new Size(87, 29);
            ndTemHeigh.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(264, 48);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(26, 21);
            label2.TabIndex = 3;
            label2.Text = "℃";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(264, 103);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(26, 21);
            label3.TabIndex = 6;
            label3.Text = "℃";
            // 
            // ndTemLow
            // 
            ndTemLow.DecimalPlaces = 1;
            ndTemLow.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ndTemLow.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            ndTemLow.Location = new Point(171, 102);
            ndTemLow.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            ndTemLow.Name = "ndTemLow";
            ndTemLow.Size = new Size(87, 29);
            ndTemLow.TabIndex = 5;
            // 
            // labTemLow
            // 
            labTemLow.AutoSize = true;
            labTemLow.BackColor = Color.Transparent;
            labTemLow.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labTemLow.ForeColor = Color.White;
            labTemLow.Location = new Point(24, 103);
            labTemLow.Margin = new Padding(4, 0, 4, 0);
            labTemLow.Name = "labTemLow";
            labTemLow.Size = new Size(125, 21);
            labTemLow.TabIndex = 4;
            labTemLow.Text = "1#站点温度低限";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(264, 157);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(24, 21);
            label5.TabIndex = 9;
            label5.Text = "%";
            // 
            // ndHumidityHeigh
            // 
            ndHumidityHeigh.DecimalPlaces = 1;
            ndHumidityHeigh.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ndHumidityHeigh.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            ndHumidityHeigh.Location = new Point(171, 155);
            ndHumidityHeigh.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            ndHumidityHeigh.Name = "ndHumidityHeigh";
            ndHumidityHeigh.Size = new Size(87, 29);
            ndHumidityHeigh.TabIndex = 8;
            // 
            // labHumidityHeigh
            // 
            labHumidityHeigh.AutoSize = true;
            labHumidityHeigh.BackColor = Color.Transparent;
            labHumidityHeigh.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labHumidityHeigh.ForeColor = Color.White;
            labHumidityHeigh.Location = new Point(24, 157);
            labHumidityHeigh.Margin = new Padding(4, 0, 4, 0);
            labHumidityHeigh.Name = "labHumidityHeigh";
            labHumidityHeigh.Size = new Size(125, 21);
            labHumidityHeigh.TabIndex = 7;
            labHumidityHeigh.Text = "1#站点湿度高限";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(264, 204);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(24, 21);
            label7.TabIndex = 12;
            label7.Text = "%";
            // 
            // ndHumidityLow
            // 
            ndHumidityLow.DecimalPlaces = 1;
            ndHumidityLow.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ndHumidityLow.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            ndHumidityLow.Location = new Point(171, 202);
            ndHumidityLow.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            ndHumidityLow.Name = "ndHumidityLow";
            ndHumidityLow.Size = new Size(87, 29);
            ndHumidityLow.TabIndex = 11;
            // 
            // labHumidityLow
            // 
            labHumidityLow.AutoSize = true;
            labHumidityLow.BackColor = Color.Transparent;
            labHumidityLow.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labHumidityLow.ForeColor = Color.White;
            labHumidityLow.Location = new Point(24, 204);
            labHumidityLow.Margin = new Padding(4, 0, 4, 0);
            labHumidityLow.Name = "labHumidityLow";
            labHumidityLow.Size = new Size(125, 21);
            labHumidityLow.TabIndex = 10;
            labHumidityLow.Text = "1#站点湿度低限";
            // 
            // ckTemAlarmUse
            // 
            ckTemAlarmUse.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckTemAlarmUse.ForeColor = Color.White;
            ckTemAlarmUse.Location = new Point(18, 249);
            ckTemAlarmUse.Margin = new Padding(4, 3, 4, 3);
            ckTemAlarmUse.MinimumSize = new Size(1, 1);
            ckTemAlarmUse.Name = "ckTemAlarmUse";
            ckTemAlarmUse.Size = new Size(150, 28);
            ckTemAlarmUse.TabIndex = 13;
            ckTemAlarmUse.Text = "温度报警启用";
            // 
            // ckHumidityAlarmUse
            // 
            ckHumidityAlarmUse.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckHumidityAlarmUse.ForeColor = Color.White;
            ckHumidityAlarmUse.Location = new Point(152, 249);
            ckHumidityAlarmUse.Margin = new Padding(4, 3, 4, 3);
            ckHumidityAlarmUse.MinimumSize = new Size(1, 1);
            ckHumidityAlarmUse.Name = "ckHumidityAlarmUse";
            ckHumidityAlarmUse.Size = new Size(150, 28);
            ckHumidityAlarmUse.TabIndex = 14;
            ckHumidityAlarmUse.Text = "湿度报警启用";
            // 
            // RecipeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(ckHumidityAlarmUse);
            Controls.Add(ckTemAlarmUse);
            Controls.Add(label7);
            Controls.Add(ndHumidityLow);
            Controls.Add(labHumidityLow);
            Controls.Add(label5);
            Controls.Add(ndHumidityHeigh);
            Controls.Add(labHumidityHeigh);
            Controls.Add(label3);
            Controls.Add(ndTemLow);
            Controls.Add(labTemLow);
            Controls.Add(label2);
            Controls.Add(ndTemHeigh);
            Controls.Add(labTemHeigh);
            Controls.Add(titleEx);
            ForeColor = Color.White;
            Margin = new Padding(4, 3, 4, 3);
            Name = "RecipeControl";
            Size = new Size(303, 290);
            ((System.ComponentModel.ISupportInitialize)ndTemHeigh).EndInit();
            ((System.ComponentModel.ISupportInitialize)ndTemLow).EndInit();
            ((System.ComponentModel.ISupportInitialize)ndHumidityHeigh).EndInit();
            ((System.ComponentModel.ISupportInitialize)ndHumidityLow).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TitleEx titleEx;
        private Label labTemHeigh;
        private NumericUpDown ndTemHeigh;
        private Label label2;
        private Label label3;
        private NumericUpDown ndTemLow;
        private Label labTemLow;
        private Label label5;
        private NumericUpDown ndHumidityHeigh;
        private Label labHumidityHeigh;
        private Label label7;
        private NumericUpDown ndHumidityLow;
        private Label labHumidityLow;
        private Sunny.UI.UICheckBox ckTemAlarmUse;
        private Sunny.UI.UICheckBox ckHumidityAlarmUse;
    }
}
