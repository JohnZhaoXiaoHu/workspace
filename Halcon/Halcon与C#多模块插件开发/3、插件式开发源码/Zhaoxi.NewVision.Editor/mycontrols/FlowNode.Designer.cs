namespace Zhaoxi.NewVision.Editor.mycontrols
{
    partial class FlowNode
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
            label1 = new Label();
            lbTitle = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Teal;
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(36, 42);
            label1.TabIndex = 0;
            label1.MouseDoubleClick += FlowNode_MouseDoubleClick;
            // 
            // lbTitle
            // 
            lbTitle.Dock = DockStyle.Left;
            lbTitle.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lbTitle.Location = new Point(36, 0);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(162, 42);
            lbTitle.TabIndex = 1;
            lbTitle.Text = "测试";
            lbTitle.TextAlign = ContentAlignment.MiddleCenter;
            lbTitle.MouseDoubleClick += FlowNode_MouseDoubleClick;
            // 
            // FlowNode
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lbTitle);
            Controls.Add(label1);
            Name = "FlowNode";
            Size = new Size(197, 42);
            MouseDoubleClick += FlowNode_MouseDoubleClick;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label lbTitle;
    }
}
