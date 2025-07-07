namespace DragVision.Plugin.Dialog.ROI工具
{
    partial class FrmDrawROI
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
            btnClear = new Button();
            btnDraw = new Button();
            rbEliipse = new RadioButton();
            rbRectangle = new RadioButton();
            rbCircle = new RadioButton();
            btnComplete = new Button();
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
            splitContainer1.Panel2.Controls.Add(btnClear);
            splitContainer1.Panel2.Controls.Add(btnDraw);
            splitContainer1.Panel2.Controls.Add(rbEliipse);
            splitContainer1.Panel2.Controls.Add(rbRectangle);
            splitContainer1.Panel2.Controls.Add(rbCircle);
            splitContainer1.Panel2.Controls.Add(btnComplete);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 494;
            splitContainer1.TabIndex = 3;
            // 
            // halconDisplayControl1
            // 
            halconDisplayControl1.Dock = DockStyle.Fill;
            halconDisplayControl1.Location = new Point(0, 0);
            halconDisplayControl1.Name = "halconDisplayControl1";
            halconDisplayControl1.Size = new Size(494, 450);
            halconDisplayControl1.TabIndex = 0;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Teal;
            btnClear.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(77, 264);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(130, 50);
            btnClear.TabIndex = 6;
            btnClear.Text = "清空";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDraw
            // 
            btnDraw.BackColor = Color.Teal;
            btnDraw.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnDraw.ForeColor = Color.White;
            btnDraw.Location = new Point(77, 196);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new Size(130, 50);
            btnDraw.TabIndex = 5;
            btnDraw.Text = "绘制";
            btnDraw.UseVisualStyleBackColor = false;
            btnDraw.Click += btnDraw_Click;
            // 
            // rbEliipse
            // 
            rbEliipse.AutoSize = true;
            rbEliipse.Location = new Point(47, 90);
            rbEliipse.Name = "rbEliipse";
            rbEliipse.Size = new Size(72, 21);
            rbEliipse.TabIndex = 4;
            rbEliipse.TabStop = true;
            rbEliipse.Text = "椭圆ROI";
            rbEliipse.UseVisualStyleBackColor = true;
            // 
            // rbRectangle
            // 
            rbRectangle.AutoSize = true;
            rbRectangle.Location = new Point(161, 41);
            rbRectangle.Name = "rbRectangle";
            rbRectangle.Size = new Size(72, 21);
            rbRectangle.TabIndex = 3;
            rbRectangle.TabStop = true;
            rbRectangle.Text = "矩形ROI";
            rbRectangle.UseVisualStyleBackColor = true;
            // 
            // rbCircle
            // 
            rbCircle.AutoSize = true;
            rbCircle.Checked = true;
            rbCircle.Location = new Point(47, 41);
            rbCircle.Name = "rbCircle";
            rbCircle.Size = new Size(72, 21);
            rbCircle.TabIndex = 2;
            rbCircle.TabStop = true;
            rbCircle.Text = "圆形ROI";
            rbCircle.UseVisualStyleBackColor = true;
            // 
            // btnComplete
            // 
            btnComplete.BackColor = Color.Teal;
            btnComplete.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnComplete.ForeColor = Color.White;
            btnComplete.Location = new Point(77, 335);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(130, 50);
            btnComplete.TabIndex = 1;
            btnComplete.Text = "执行完成";
            btnComplete.UseVisualStyleBackColor = false;
            btnComplete.Click += btnComplete_Click;
            // 
            // FrmDrawROI
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "FrmDrawROI";
            Text = "FrmDrawROI";
            Load += FrmDrawROI_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Controls.HalconDisplayControl halconDisplayControl1;
        private RadioButton rbCircle;
        private Button btnComplete;
        private Button btnClear;
        private Button btnDraw;
        private RadioButton rbEliipse;
        private RadioButton rbRectangle;
    }
}