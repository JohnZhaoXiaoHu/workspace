namespace MTHCollection.Project.Dialog
{
    partial class FrmUpdateParam
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
            label1 = new Label();
            labParamName = new Label();
            label2 = new Label();
            labCurrentValue = new Label();
            label3 = new Label();
            tbUpdateValue = new TextBox();
            btn_SureUpdate = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("微软雅黑", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(99, 86);
            label1.Name = "label1";
            label1.Size = new Size(102, 28);
            label1.TabIndex = 0;
            label1.Text = "参数名称:";
            // 
            // labParamName
            // 
            labParamName.AutoSize = true;
            labParamName.BackColor = Color.Transparent;
            labParamName.Font = new Font("微软雅黑", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            labParamName.ForeColor = Color.White;
            labParamName.Location = new Point(225, 86);
            labParamName.Name = "labParamName";
            labParamName.Size = new Size(164, 28);
            labParamName.TabIndex = 1;
            labParamName.Text = "1#站点温度高限";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("微软雅黑", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(109, 147);
            label2.Name = "label2";
            label2.Size = new Size(81, 28);
            label2.TabIndex = 2;
            label2.Text = "当前值:";
            // 
            // labCurrentValue
            // 
            labCurrentValue.AutoSize = true;
            labCurrentValue.BackColor = Color.Transparent;
            labCurrentValue.Font = new Font("微软雅黑", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            labCurrentValue.ForeColor = Color.White;
            labCurrentValue.Location = new Point(255, 147);
            labCurrentValue.Name = "labCurrentValue";
            labCurrentValue.Size = new Size(44, 28);
            labCurrentValue.TabIndex = 3;
            labCurrentValue.Text = "0.0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("微软雅黑", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(109, 204);
            label3.Name = "label3";
            label3.Size = new Size(81, 28);
            label3.TabIndex = 4;
            label3.Text = "更新值:";
            // 
            // tbUpdateValue
            // 
            tbUpdateValue.Font = new Font("微软雅黑", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            tbUpdateValue.Location = new Point(225, 203);
            tbUpdateValue.Name = "tbUpdateValue";
            tbUpdateValue.Size = new Size(164, 33);
            tbUpdateValue.TabIndex = 5;
            tbUpdateValue.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_SureUpdate
            // 
            btn_SureUpdate.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_SureUpdate.Location = new Point(173, 272);
            btn_SureUpdate.MinimumSize = new Size(1, 1);
            btn_SureUpdate.Name = "btn_SureUpdate";
            btn_SureUpdate.Size = new Size(100, 35);
            btn_SureUpdate.TabIndex = 6;
            btn_SureUpdate.Text = "确认修改";
            btn_SureUpdate.TipsFont = new Font("微软雅黑", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_SureUpdate.Click += btn_SureUpdate_Click;
            // 
            // FrmUpdateParam
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.BackGround;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(465, 335);
            Controls.Add(btn_SureUpdate);
            Controls.Add(tbUpdateValue);
            Controls.Add(label3);
            Controls.Add(labCurrentValue);
            Controls.Add(label2);
            Controls.Add(labParamName);
            Controls.Add(label1);
            Name = "FrmUpdateParam";
            Text = "修改参数设置";
            TitleColor = Color.DarkBlue;
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += FrmUpdateParam_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labParamName;
        private Label label2;
        private Label labCurrentValue;
        private Label label3;
        private TextBox tbUpdateValue;
        private Sunny.UI.UIButton btn_SureUpdate;
    }
}