namespace DragVision.Start.Dialog
{
    partial class FrmAddFow
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
            textFloName = new TextBox();
            btnSure = new Button();
            BtnClose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(12, 35);
            label1.Name = "label1";
            label1.Size = new Size(93, 25);
            label1.TabIndex = 0;
            label1.Text = "流程名称:";
            // 
            // textFloName
            // 
            textFloName.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textFloName.Location = new Point(130, 35);
            textFloName.Name = "textFloName";
            textFloName.Size = new Size(260, 29);
            textFloName.TabIndex = 1;
            // 
            // btnSure
            // 
            btnSure.BackColor = Color.Cyan;
            btnSure.FlatStyle = FlatStyle.Flat;
            btnSure.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSure.ForeColor = Color.Black;
            btnSure.Location = new Point(156, 83);
            btnSure.Name = "btnSure";
            btnSure.Size = new Size(91, 34);
            btnSure.TabIndex = 2;
            btnSure.Text = "确认";
            btnSure.UseVisualStyleBackColor = false;
            btnSure.Click += btnSure_Click;
            // 
            // BtnClose
            // 
            BtnClose.BackColor = Color.Cyan;
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnClose.Location = new Point(275, 83);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(91, 34);
            BtnClose.TabIndex = 3;
            BtnClose.Text = "关闭";
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // FrmAddFow
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(505, 151);
            Controls.Add(BtnClose);
            Controls.Add(btnSure);
            Controls.Add(textFloName);
            Controls.Add(label1);
            Name = "FrmAddFow";
            Text = "FrmAddFow";
            Load += FrmAddFow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textFloName;
        private Button btnSure;
        private Button BtnClose;
    }
}