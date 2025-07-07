namespace DragVision.Start
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            TreeNode treeNode1 = new TreeNode("海康相机采集");
            TreeNode treeNode2 = new TreeNode("大华相机采集");
            TreeNode treeNode3 = new TreeNode("图像处理工具箱", new TreeNode[] { treeNode1, treeNode2 });
            TreeNode treeNode4 = new TreeNode("绘制ROI");
            TreeNode treeNode5 = new TreeNode("ROI工具箱", new TreeNode[] { treeNode4 });
            imageList1 = new ImageList(components);
            menuItem_DeleteFlow = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            splitContainer1 = new SplitContainer();
            toolStrip2 = new ToolStrip();
            btn_FlowRun = new ToolStripButton();
            btn_FlowStop = new ToolStripButton();
            btn_FlowConti = new ToolStripButton();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            splitContainer2 = new SplitContainer();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            splitContainer3 = new SplitContainer();
            splitContainer4 = new SplitContainer();
            splitContainer5 = new SplitContainer();
            groupBox1 = new GroupBox();
            panelView = new Panel();
            halconDisplayControl1 = new Controls.HalconDisplayControl();
            groupBox2 = new GroupBox();
            dgvLog = new DataGridView();
            Time = new DataGridViewTextBoxColumn();
            Message = new DataGridViewTextBoxColumn();
            groupBox3 = new GroupBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            groupBox4 = new GroupBox();
            panel2 = new Panel();
            treeView1 = new TreeView();
            panel1 = new Panel();
            btnAddFlow = new Button();
            toolTip1 = new ToolTip(components);
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            toolStrip2.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
            splitContainer5.Panel1.SuspendLayout();
            splitContainer5.Panel2.SuspendLayout();
            splitContainer5.SuspendLayout();
            groupBox1.SuspendLayout();
            panelView.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLog).BeginInit();
            groupBox3.SuspendLayout();
            tabControl1.SuspendLayout();
            groupBox4.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "工具箱.png");
            imageList1.Images.SetKeyName(1, "插件.png");
            // 
            // menuItem_DeleteFlow
            // 
            menuItem_DeleteFlow.Name = "menuItem_DeleteFlow";
            menuItem_DeleteFlow.Size = new Size(124, 22);
            menuItem_DeleteFlow.Text = "删除流程";
            menuItem_DeleteFlow.Click += menuItem_DeleteFlow_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { menuItem_DeleteFlow });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(125, 26);
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(toolStrip2);
            splitContainer1.Panel1.Controls.Add(toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1445, 522);
            splitContainer1.SplitterDistance = 38;
            splitContainer1.TabIndex = 1;
            // 
            // toolStrip2
            // 
            toolStrip2.Dock = DockStyle.None;
            toolStrip2.Items.AddRange(new ToolStripItem[] { btn_FlowRun, btn_FlowStop, btn_FlowConti });
            toolStrip2.Location = new Point(652, 9);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(192, 25);
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // btn_FlowRun
            // 
            btn_FlowRun.Image = Properties.Resources.启动__1_;
            btn_FlowRun.ImageTransparentColor = Color.Magenta;
            btn_FlowRun.Name = "btn_FlowRun";
            btn_FlowRun.Size = new Size(52, 22);
            btn_FlowRun.Text = "启动";
            btn_FlowRun.ToolTipText = "启动";
            // 
            // btn_FlowStop
            // 
            btn_FlowStop.Image = Properties.Resources.暂停__1_;
            btn_FlowStop.ImageTransparentColor = Color.Magenta;
            btn_FlowStop.Name = "btn_FlowStop";
            btn_FlowStop.Size = new Size(52, 22);
            btn_FlowStop.Text = "停止";
            // 
            // btn_FlowConti
            // 
            btn_FlowConti.Image = Properties.Resources.icon_连续运行;
            btn_FlowConti.ImageTransparentColor = Color.Magenta;
            btn_FlowConti.Name = "btn_FlowConti";
            btn_FlowConti.Size = new Size(76, 22);
            btn_FlowConti.Text = "连续运行";
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2 });
            toolStrip1.Location = new Point(18, 9);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(164, 25);
            toolStrip1.Stretch = true;
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = Properties.Resources.导入方案;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(76, 22);
            toolStripButton1.Text = "导入方案";
            // 
            // toolStripButton2
            // 
            toolStripButton2.Image = Properties.Resources.导出方案;
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(76, 22);
            toolStripButton2.Text = "导出方案";
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(button3);
            splitContainer2.Panel1.Controls.Add(button2);
            splitContainer2.Panel1.Controls.Add(button1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer3);
            splitContainer2.Size = new Size(1445, 480);
            splitContainer2.SplitterDistance = 53;
            splitContainer2.TabIndex = 0;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.BackgroundImage = Properties.Resources.连续运行;
            button3.BackgroundImageLayout = ImageLayout.Zoom;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(3, 226);
            button3.Name = "button3";
            button3.Size = new Size(44, 114);
            button3.TabIndex = 2;
            button3.Text = "连续执行";
            button3.TextAlign = ContentAlignment.BottomCenter;
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.BackgroundImage = Properties.Resources.暂停;
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(0, 103);
            button2.Name = "button2";
            button2.Size = new Size(47, 84);
            button2.TabIndex = 1;
            button2.Text = "暂停";
            button2.TextAlign = ContentAlignment.BottomCenter;
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = Properties.Resources.启动;
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(5, 3);
            button1.Name = "button1";
            button1.Size = new Size(43, 84);
            button1.TabIndex = 0;
            button1.Text = "启动";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = false;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(groupBox4);
            splitContainer3.Size = new Size(1388, 480);
            splitContainer3.SplitterDistance = 1179;
            splitContainer3.TabIndex = 2;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(splitContainer5);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(groupBox3);
            splitContainer4.Size = new Size(1179, 480);
            splitContainer4.SplitterDistance = 570;
            splitContainer4.TabIndex = 0;
            // 
            // splitContainer5
            // 
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.Location = new Point(0, 0);
            splitContainer5.Name = "splitContainer5";
            splitContainer5.Orientation = Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            splitContainer5.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer5.Panel2
            // 
            splitContainer5.Panel2.Controls.Add(groupBox2);
            splitContainer5.Size = new Size(570, 480);
            splitContainer5.SplitterDistance = 250;
            splitContainer5.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panelView);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(570, 250);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "视图显示";
            // 
            // panelView
            // 
            panelView.Controls.Add(halconDisplayControl1);
            panelView.Dock = DockStyle.Fill;
            panelView.Location = new Point(3, 19);
            panelView.Name = "panelView";
            panelView.Size = new Size(564, 228);
            panelView.TabIndex = 0;
            // 
            // halconDisplayControl1
            // 
            halconDisplayControl1.Dock = DockStyle.Fill;
            halconDisplayControl1.Location = new Point(0, 0);
            halconDisplayControl1.Name = "halconDisplayControl1";
            halconDisplayControl1.Size = new Size(564, 228);
            halconDisplayControl1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvLog);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(570, 226);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "消息日志";
            // 
            // dgvLog
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLog.Columns.AddRange(new DataGridViewColumn[] { Time, Message });
            dgvLog.Dock = DockStyle.Bottom;
            dgvLog.Location = new Point(3, 22);
            dgvLog.Name = "dgvLog";
            dgvLog.RowTemplate.Height = 25;
            dgvLog.Size = new Size(564, 201);
            dgvLog.TabIndex = 0;
            // 
            // Time
            // 
            Time.DataPropertyName = "Time";
            Time.HeaderText = "时间";
            Time.Name = "Time";
            Time.Width = 200;
            // 
            // Message
            // 
            Message.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Message.DataPropertyName = "Message";
            Message.HeaderText = "消息";
            Message.Name = "Message";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(tabControl1);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(605, 480);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "流程编辑区";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 19);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(599, 458);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(591, 428);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "流程1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(591, 428);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "流程2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(panel2);
            groupBox4.Controls.Add(panel1);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(0, 0);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(205, 480);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "视觉工具箱";
            // 
            // panel2
            // 
            panel2.Controls.Add(treeView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 68);
            panel2.Name = "panel2";
            panel2.Size = new Size(199, 409);
            panel2.TabIndex = 1;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            treeView1.ImageIndex = 0;
            treeView1.ImageList = imageList1;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "";
            treeNode1.Text = "海康相机采集";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "节点2";
            treeNode2.Text = "大华相机采集";
            treeNode3.Name = "节点0";
            treeNode3.Text = "图像处理工具箱";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "节点1";
            treeNode4.Text = "绘制ROI";
            treeNode5.Name = "节点3";
            treeNode5.Text = "ROI工具箱";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode3, treeNode5 });
            treeView1.SelectedImageIndex = 0;
            treeView1.Size = new Size(199, 409);
            treeView1.TabIndex = 0;
            treeView1.ItemDrag += treeView1_ItemDrag;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnAddFlow);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(199, 49);
            panel1.TabIndex = 0;
            // 
            // btnAddFlow
            // 
            btnAddFlow.BackColor = Color.DarkOrange;
            btnAddFlow.Font = new Font("微软雅黑", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddFlow.ForeColor = Color.White;
            btnAddFlow.Location = new Point(3, 3);
            btnAddFlow.Name = "btnAddFlow";
            btnAddFlow.Size = new Size(204, 40);
            btnAddFlow.TabIndex = 0;
            btnAddFlow.Text = "添加流程";
            btnAddFlow.UseVisualStyleBackColor = false;
            btnAddFlow.Click += btnAddFlow_Click;
            // 
            // toolTip1
            // 
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "启动";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1445, 522);
            Controls.Add(splitContainer1);
            Name = "FormMain";
            Text = "Form1";
            Load += FormMain_Load;
            contextMenuStrip1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            splitContainer5.Panel1.ResumeLayout(false);
            splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
            splitContainer5.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            panelView.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLog).EndInit();
            groupBox3.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ImageList imageList1;
        private ToolStripMenuItem menuItem_DeleteFlow;
        private ContextMenuStrip contextMenuStrip1;
        private SplitContainer splitContainer1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private SplitContainer splitContainer5;
        private GroupBox groupBox1;
        private Panel panelView;
        private Controls.HalconDisplayControl halconDisplayControl1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox4;
        private Panel panel2;
        private TreeView treeView1;
        private Panel panel1;
        private Button btnAddFlow;
        private DataGridView dgvLog;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn Message;
        private ToolTip toolTip1;
        private ToolStrip toolStrip2;
        private ToolStripButton btn_FlowRun;
        private ToolStripButton btn_FlowStop;
        private ToolStripButton btn_FlowConti;
        private Button button1;
        private Button button3;
        private Button button2;
    }
}
