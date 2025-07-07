namespace Zhaoxi.Vision.Flow.Proj.VFrame
{
    partial class LoadImageFrm
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
            fileSystemWatcher1 = new FileSystemWatcher();
            BtnLoadImage = new Button();
            BtnFinish = new Button();
            myhWindowControl1 = new NewVision.Editor.mycontrols.MyHWindowControl();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // BtnLoadImage
            // 
            BtnLoadImage.Location = new Point(635, 28);
            BtnLoadImage.Name = "BtnLoadImage";
            BtnLoadImage.Size = new Size(208, 54);
            BtnLoadImage.TabIndex = 0;
            BtnLoadImage.Text = "加载图像";
            BtnLoadImage.UseVisualStyleBackColor = true;
            BtnLoadImage.Click += BtnLoadImage_Click;
            // 
            // BtnFinish
            // 
            BtnFinish.Location = new Point(635, 143);
            BtnFinish.Name = "BtnFinish";
            BtnFinish.Size = new Size(208, 63);
            BtnFinish.TabIndex = 1;
            BtnFinish.Text = "完成";
            BtnFinish.UseVisualStyleBackColor = true;
            BtnFinish.Click += BtnFinish_Click;
            // 
            // myhWindowControl1
            // 
            myhWindowControl1.BackColor = Color.Black;
            myhWindowControl1.BorderColor = Color.Black;
            myhWindowControl1.ImagePart = new Rectangle(0, 0, 640, 480);
            myhWindowControl1.Location = new Point(32, 28);
            myhWindowControl1.Name = "myhWindowControl1";
            myhWindowControl1.Size = new Size(581, 470);
            myhWindowControl1.TabIndex = 2;
            myhWindowControl1.WindowSize = new Size(581, 470);
            // 
            // LoadImageFrm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(863, 515);
            Controls.Add(myhWindowControl1);
            Controls.Add(BtnFinish);
            Controls.Add(BtnLoadImage);
            Name = "LoadImageFrm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "加载图像窗口";
            Load += LoadImageFrm_Load;
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FileSystemWatcher fileSystemWatcher1;
        private Button BtnLoadImage;
        private Button BtnFinish;
        private NewVision.Editor.mycontrols.MyHWindowControl myhWindowControl1;
    }
}