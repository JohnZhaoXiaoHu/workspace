namespace GYPlugin.CreateModel
{
    partial class CreateModelView
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
            button1 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(228, 133);
            button1.Name = "button1";
            button1.Size = new Size(254, 115);
            button1.TabIndex = 0;
            button1.Text = "创建模板";
            button1.UseVisualStyleBackColor = true;
            // 
            // CreateModelView
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 502);
            Controls.Add(button1);
            Name = "CreateModelView";
            Text = "CreateModelView";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
    }
}