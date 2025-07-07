using Zhaoxi.NewVision.Editor.mycontrols;

namespace Zhaoxi.Vision.Flow.Proj.VFrame
{
    partial class DrawROIFrm
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
            BtnDrawROI = new Button();
            BtnUpdate = new Button();
            BtnDropModelImage = new Button();
            BtnFinish = new Button();
            roiWd = new MyHWindowControl();
            SuspendLayout();
            // 
            // BtnDrawROI
            // 
            BtnDrawROI.Location = new Point(26, 509);
            BtnDrawROI.Name = "BtnDrawROI";
            BtnDrawROI.Size = new Size(141, 51);
            BtnDrawROI.TabIndex = 1;
            BtnDrawROI.Text = "选取模板图像";
            BtnDrawROI.UseVisualStyleBackColor = true;
            BtnDrawROI.Click += BtnDrawROI_Click;
            // 
            // BtnUpdate
            // 
            BtnUpdate.Location = new Point(214, 509);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(141, 51);
            BtnUpdate.TabIndex = 1;
            BtnUpdate.Text = "修改模板图像";
            BtnUpdate.UseVisualStyleBackColor = true;
            BtnUpdate.Click += BtnUpdate_Click;
            // 
            // BtnDropModelImage
            // 
            BtnDropModelImage.Location = new Point(398, 509);
            BtnDropModelImage.Name = "BtnDropModelImage";
            BtnDropModelImage.Size = new Size(141, 51);
            BtnDropModelImage.TabIndex = 1;
            BtnDropModelImage.Text = "截取模板图像";
            BtnDropModelImage.UseVisualStyleBackColor = true;
            BtnDropModelImage.Click += BtnDropModelImage_Click;
            // 
            // BtnFinish
            // 
            BtnFinish.Location = new Point(574, 509);
            BtnFinish.Name = "BtnFinish";
            BtnFinish.Size = new Size(112, 51);
            BtnFinish.TabIndex = 2;
            BtnFinish.Text = "完成";
            BtnFinish.UseVisualStyleBackColor = true;
            BtnFinish.Click += BtnFinish_Click;
            // 
            // roiWd
            // 
            roiWd.BackColor = Color.Black;
            roiWd.BorderColor = Color.Black;
            roiWd.ImagePart = new Rectangle(0, 0, 640, 480);
            roiWd.Location = new Point(26, 12);
            roiWd.Name = "roiWd";
            roiWd.Size = new Size(660, 475);
            roiWd.TabIndex = 3;
            roiWd.WindowSize = new Size(660, 475);
            // 
            // DrawROIFrm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(711, 588);
            Controls.Add(roiWd);
            Controls.Add(BtnFinish);
            Controls.Add(BtnDropModelImage);
            Controls.Add(BtnUpdate);
            Controls.Add(BtnDrawROI);
            Name = "DrawROIFrm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "截取模板图像窗口";
            Load += DrawROIFrm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button BtnDrawROI;
        private Button BtnUpdate;
        private Button BtnDropModelImage;
        private Button BtnFinish;
        private MyHWindowControl roiWd;
    }
}