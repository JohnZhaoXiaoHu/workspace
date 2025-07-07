namespace MTHCollection.Controls
{
    partial class THSetBaseControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            labSymbol = new Label();
            labValue = new Label();
            labTitle = new Label();
            SuspendLayout();
            // 
            // labSymbol
            // 
            labSymbol.AutoSize = true;
            labSymbol.Cursor = Cursors.No;
            labSymbol.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labSymbol.ForeColor = Color.White;
            labSymbol.Location = new Point(231, 3);
            labSymbol.Name = "labSymbol";
            labSymbol.Size = new Size(26, 21);
            labSymbol.TabIndex = 32;
            labSymbol.Text = "℃";
            // 
            // labValue
            // 
            labValue.AutoSize = true;
            labValue.Cursor = Cursors.No;
            labValue.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labValue.ForeColor = Color.White;
            labValue.Location = new Point(158, 3);
            labValue.Name = "labValue";
            labValue.Size = new Size(28, 21);
            labValue.TabIndex = 31;
            labValue.Text = "35";
            // 
            // labTitle
            // 
            labTitle.AutoSize = true;
            labTitle.Cursor = Cursors.No;
            labTitle.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labTitle.ForeColor = Color.White;
            labTitle.Location = new Point(4, 3);
            labTitle.Name = "labTitle";
            labTitle.Size = new Size(125, 21);
            labTitle.TabIndex = 30;
            labTitle.Text = "1#站点温度高限";
            // 
            // THSetBaseControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(labSymbol);
            Controls.Add(labValue);
            Controls.Add(labTitle);
            Name = "THSetBaseControl";
            Size = new Size(264, 29);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labSymbol;
        private Label labValue;
        private Label labTitle;
    }
}
