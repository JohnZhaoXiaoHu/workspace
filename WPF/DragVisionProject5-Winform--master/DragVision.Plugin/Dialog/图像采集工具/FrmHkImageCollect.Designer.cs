namespace DragVision.Plugin.Dialog.图像采集工具
{
    partial class FrmHkImageCollect
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
            btnExcuteComplete = new Button();
            btnLoadeImage = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            splitContainer1.Panel2.Controls.Add(btnExcuteComplete);
            splitContainer1.Panel2.Controls.Add(btnLoadeImage);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 495;
            splitContainer1.TabIndex = 0;
            // 
            // halconDisplayControl1
            // 
            halconDisplayControl1.Dock = DockStyle.Fill;
            halconDisplayControl1.Location = new Point(0, 0);
            halconDisplayControl1.Name = "halconDisplayControl1";
            halconDisplayControl1.Size = new Size(495, 450);
            halconDisplayControl1.TabIndex = 0;
            // 
            // btnExcuteComplete
            // 
            btnExcuteComplete.BackColor = Color.Teal;
            btnExcuteComplete.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnExcuteComplete.ForeColor = Color.White;
            btnExcuteComplete.Location = new Point(87, 130);
            btnExcuteComplete.Name = "btnExcuteComplete";
            btnExcuteComplete.Size = new Size(130, 50);
            btnExcuteComplete.TabIndex = 1;
            btnExcuteComplete.Text = "执行完成";
            btnExcuteComplete.UseVisualStyleBackColor = false;
            btnExcuteComplete.Click += btnExcuteComplete_Click;
            // 
            // btnLoadeImage
            // 
            btnLoadeImage.BackColor = Color.Teal;
            btnLoadeImage.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoadeImage.ForeColor = Color.White;
            btnLoadeImage.Location = new Point(87, 33);
            btnLoadeImage.Name = "btnLoadeImage";
            btnLoadeImage.Size = new Size(130, 50);
            btnLoadeImage.TabIndex = 0;
            btnLoadeImage.Text = "加载图像";
            btnLoadeImage.UseVisualStyleBackColor = false;
            btnLoadeImage.Click += btnLoadeImage_Click;
            // 
            // FrmHkImageCollect
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "FrmHkImageCollect";
            Text = "FrmHkImageCollect";
            Load += FrmHkImageCollect_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Controls.HalconDisplayControl halconDisplayControl1;
        private Button btnExcuteComplete;
        private Button btnLoadeImage;
    }
}