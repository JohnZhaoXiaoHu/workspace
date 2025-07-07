namespace DragVision.Plugin.Dialog.模版匹配工具
{
    partial class FrmReadNccMatch
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
            btnExcuteComplete = new Button();
            btnChooseRead = new Button();
            textNccModle = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnExcuteComplete
            // 
            btnExcuteComplete.BackColor = Color.Teal;
            btnExcuteComplete.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnExcuteComplete.ForeColor = Color.White;
            btnExcuteComplete.Location = new Point(283, 107);
            btnExcuteComplete.Name = "btnExcuteComplete";
            btnExcuteComplete.Size = new Size(130, 50);
            btnExcuteComplete.TabIndex = 8;
            btnExcuteComplete.Text = "执行完成";
            btnExcuteComplete.UseVisualStyleBackColor = false;
            btnExcuteComplete.Click += btnExcuteComplete_Click;
            // 
            // btnChooseRead
            // 
            btnChooseRead.BackColor = Color.Teal;
            btnChooseRead.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnChooseRead.ForeColor = Color.White;
            btnChooseRead.Location = new Point(595, 33);
            btnChooseRead.Name = "btnChooseRead";
            btnChooseRead.Size = new Size(130, 37);
            btnChooseRead.TabIndex = 7;
            btnChooseRead.Text = "选择并读取";
            btnChooseRead.UseVisualStyleBackColor = false;
            btnChooseRead.Click += btnChooseRead_Click;
            // 
            // textNccModle
            // 
            textNccModle.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textNccModle.Location = new Point(192, 37);
            textNccModle.Name = "textNccModle";
            textNccModle.Size = new Size(374, 28);
            textNccModle.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(75, 40);
            label1.Name = "label1";
            label1.Size = new Size(111, 22);
            label1.TabIndex = 5;
            label1.Text = "模板文件路径:";
            // 
            // FrmReadNccMatch
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 190);
            Controls.Add(btnExcuteComplete);
            Controls.Add(btnChooseRead);
            Controls.Add(textNccModle);
            Controls.Add(label1);
            Name = "FrmReadNccMatch";
            Text = "FrmReadNccMatch";
            Load += FrmReadNccMatch_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExcuteComplete;
        private Button btnChooseRead;
        private TextBox textNccModle;
        private Label label1;
    }
}