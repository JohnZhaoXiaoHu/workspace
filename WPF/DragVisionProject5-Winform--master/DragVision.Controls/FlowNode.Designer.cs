namespace DragVision.Controls
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
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            panelState = new Panel();
            panelContent = new Panel();
            panelTop = new Panel();
            panelBottom = new Panel();
            labFlowName = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            删除当前节点ToolStripMenuItem = new ToolStripMenuItem();
            删除输入连线ToolStripMenuItem = new ToolStripMenuItem();
            删除输出连线ToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelContent.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(panelState);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelContent);
            splitContainer1.Size = new Size(173, 47);
            splitContainer1.SplitterDistance = 25;
            splitContainer1.TabIndex = 0;
            // 
            // panelState
            // 
            panelState.BackColor = Color.FromArgb(0, 192, 192);
            panelState.Dock = DockStyle.Fill;
            panelState.Location = new Point(0, 0);
            panelState.Name = "panelState";
            panelState.Size = new Size(25, 47);
            panelState.TabIndex = 0;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Controls.Add(panelTop);
            panelContent.Controls.Add(panelBottom);
            panelContent.Controls.Add(labFlowName);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(144, 47);
            panelContent.TabIndex = 0;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.RosyBrown;
            panelTop.Location = new Point(54, -1);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(10, 10);
            panelTop.TabIndex = 2;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.RosyBrown;
            panelBottom.Location = new Point(54, 37);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(10, 10);
            panelBottom.TabIndex = 1;
            // 
            // labFlowName
            // 
            labFlowName.AutoSize = true;
            labFlowName.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labFlowName.ForeColor = Color.Blue;
            labFlowName.Location = new Point(2, 13);
            labFlowName.Name = "labFlowName";
            labFlowName.Size = new Size(104, 17);
            labFlowName.TabIndex = 0;
            labFlowName.Text = "海康相机图像采集";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 删除当前节点ToolStripMenuItem, 删除输入连线ToolStripMenuItem, 删除输出连线ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(149, 70);
            // 
            // 删除当前节点ToolStripMenuItem
            // 
            删除当前节点ToolStripMenuItem.Name = "删除当前节点ToolStripMenuItem";
            删除当前节点ToolStripMenuItem.Size = new Size(148, 22);
            删除当前节点ToolStripMenuItem.Text = "删除当前节点";
            删除当前节点ToolStripMenuItem.Click += 删除当前节点ToolStripMenuItem_Click;
            // 
            // 删除输入连线ToolStripMenuItem
            // 
            删除输入连线ToolStripMenuItem.Name = "删除输入连线ToolStripMenuItem";
            删除输入连线ToolStripMenuItem.Size = new Size(148, 22);
            删除输入连线ToolStripMenuItem.Text = "删除输入连线";
            删除输入连线ToolStripMenuItem.Click += 删除输入连线ToolStripMenuItem_Click;
            // 
            // 删除输出连线ToolStripMenuItem
            // 
            删除输出连线ToolStripMenuItem.Name = "删除输出连线ToolStripMenuItem";
            删除输出连线ToolStripMenuItem.Size = new Size(148, 22);
            删除输出连线ToolStripMenuItem.Text = "删除输出连线";
            删除输出连线ToolStripMenuItem.Click += 删除输出连线ToolStripMenuItem_Click;
            // 
            // FlowNode
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(splitContainer1);
            Name = "FlowNode";
            Size = new Size(173, 47);
            Load += FlowNode_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panelState;
        private Panel panelContent;
        private Label labFlowName;
        private Panel panelBottom;
        private Panel panelTop;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 删除当前节点ToolStripMenuItem;
        private ToolStripMenuItem 删除输入连线ToolStripMenuItem;
        private ToolStripMenuItem 删除输出连线ToolStripMenuItem;
    }
}
