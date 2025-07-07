namespace DragVision.Plugin.Dialog.模版匹配工具
{
    partial class FrmReadShapeMatch
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
            textShapeModle = new TextBox();
            btnChooseRead = new Button();
            btnExcuteComplete = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(66, 24);
            label1.Name = "label1";
            label1.Size = new Size(111, 22);
            label1.TabIndex = 0;
            label1.Text = "模板文件路径:";
            // 
            // textShapeModle
            // 
            textShapeModle.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textShapeModle.Location = new Point(183, 21);
            textShapeModle.Name = "textShapeModle";
            textShapeModle.Size = new Size(374, 28);
            textShapeModle.TabIndex = 1;
            // 
            // btnChooseRead
            // 
            btnChooseRead.BackColor = Color.Teal;
            btnChooseRead.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnChooseRead.ForeColor = Color.White;
            btnChooseRead.Location = new Point(586, 17);
            btnChooseRead.Name = "btnChooseRead";
            btnChooseRead.Size = new Size(130, 37);
            btnChooseRead.TabIndex = 3;
            btnChooseRead.Text = "选择并读取";
            btnChooseRead.UseVisualStyleBackColor = false;
            btnChooseRead.Click += btnChooseRead_Click;
            // 
            // btnExcuteComplete
            // 
            btnExcuteComplete.BackColor = Color.Teal;
            btnExcuteComplete.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnExcuteComplete.ForeColor = Color.White;
            btnExcuteComplete.Location = new Point(274, 91);
            btnExcuteComplete.Name = "btnExcuteComplete";
            btnExcuteComplete.Size = new Size(130, 50);
            btnExcuteComplete.TabIndex = 4;
            btnExcuteComplete.Text = "执行完成";
            btnExcuteComplete.UseVisualStyleBackColor = false;
            btnExcuteComplete.Click += btnExcuteComplete_Click;
            // 
            // FrmReadShapeMatch
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 190);
            Controls.Add(btnExcuteComplete);
            Controls.Add(btnChooseRead);
            Controls.Add(textShapeModle);
            Controls.Add(label1);
            Name = "FrmReadShapeMatch";
            Text = "FrmReadShapeMatch";
            Load += FrmReadShapeMatch_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textShapeModle;
        private Button btnChooseRead;
        private Button btnExcuteComplete;
    }
}