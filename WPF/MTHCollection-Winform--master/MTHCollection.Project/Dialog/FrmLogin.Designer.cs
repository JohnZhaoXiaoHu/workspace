namespace MTHCollection.Project.Dialog
{
    partial class FrmLogin
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
            SuspendLayout();
            // 
            // lblSubText
            // 
            lblSubText.Location = new Point(376, 421);
            // 
            // FrmLogin
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(750, 450);
            Name = "FrmLogin";
            Text = "用户登录界面";
            ButtonLoginClick += FrmLogin_ButtonLoginClick;
            ButtonCancelClick += FrmLogin_ButtonCancelClick;
            ResumeLayout(false);
        }

        #endregion
    }
}