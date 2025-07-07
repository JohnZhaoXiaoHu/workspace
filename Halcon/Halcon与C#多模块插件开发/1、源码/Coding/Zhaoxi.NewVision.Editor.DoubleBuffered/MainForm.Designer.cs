namespace Zhaoxi.NewVision.Editor
{
    partial class MainForm
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
            groupBox1 = new GroupBox();
            pl_flowregion = new mycontrols.MyPanel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            tm_link = new ToolStripMenuItem();
            groupBox2 = new GroupBox();
            pl_Model = new Panel();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            lb_Model = new Label();
            pl_ImgHandle = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            lb_ImgHandle = new Label();
            groupBox1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            pl_Model.SuspendLayout();
            pl_ImgHandle.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pl_flowregion);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(804, 839);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "流程编辑区域";
            // 
            // pl_flowregion
            // 
            pl_flowregion.AllowDrop = true;
            pl_flowregion.ContextMenuStrip = contextMenuStrip1;
            pl_flowregion.Dock = DockStyle.Fill;
            pl_flowregion.Location = new Point(3, 26);
            pl_flowregion.Name = "pl_flowregion";
            pl_flowregion.Size = new Size(798, 810);
            pl_flowregion.TabIndex = 0;
            pl_flowregion.DragDrop += pl_flowregion_DragDrop;
            pl_flowregion.DragEnter += pl_flowregion_DragEnter;
            pl_flowregion.Paint += pl_flowregion_Paint;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { tm_link });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(117, 34);
            // 
            // tm_link
            // 
            tm_link.Name = "tm_link";
            tm_link.Size = new Size(116, 30);
            tm_link.Text = "连线";
            tm_link.Click += tm_link_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(pl_Model);
            groupBox2.Controls.Add(lb_Model);
            groupBox2.Controls.Add(pl_ImgHandle);
            groupBox2.Controls.Add(lb_ImgHandle);
            groupBox2.Location = new Point(822, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(375, 839);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "视觉工具箱";
            // 
            // pl_Model
            // 
            pl_Model.BorderStyle = BorderStyle.FixedSingle;
            pl_Model.Controls.Add(label12);
            pl_Model.Controls.Add(label13);
            pl_Model.Controls.Add(label14);
            pl_Model.Controls.Add(label15);
            pl_Model.Dock = DockStyle.Top;
            pl_Model.Location = new Point(3, 436);
            pl_Model.Name = "pl_Model";
            pl_Model.Size = new Size(369, 310);
            pl_Model.TabIndex = 3;
            // 
            // label12
            // 
            label12.BackColor = Color.Teal;
            label12.ForeColor = SystemColors.ControlLightLight;
            label12.Location = new Point(39, 245);
            label12.Name = "label12";
            label12.Size = new Size(303, 44);
            label12.TabIndex = 0;
            label12.Text = "清除模板";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            label12.MouseDown += Tool_MouseDown;
            // 
            // label13
            // 
            label13.BackColor = Color.Teal;
            label13.ForeColor = SystemColors.ControlLightLight;
            label13.Location = new Point(39, 176);
            label13.Name = "label13";
            label13.Size = new Size(303, 44);
            label13.TabIndex = 0;
            label13.Text = "应用模板";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            label13.MouseDown += Tool_MouseDown;
            // 
            // label14
            // 
            label14.BackColor = Color.Teal;
            label14.ForeColor = SystemColors.ControlLightLight;
            label14.Location = new Point(39, 100);
            label14.Name = "label14";
            label14.Size = new Size(303, 44);
            label14.TabIndex = 0;
            label14.Text = "模板参数设置";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            label14.MouseDown += Tool_MouseDown;
            // 
            // label15
            // 
            label15.BackColor = Color.Teal;
            label15.ForeColor = SystemColors.ControlLightLight;
            label15.Location = new Point(39, 23);
            label15.Name = "label15";
            label15.Size = new Size(303, 44);
            label15.TabIndex = 0;
            label15.Text = "新建模板";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            label15.MouseDown += Tool_MouseDown;
            // 
            // lb_Model
            // 
            lb_Model.BackColor = Color.Teal;
            lb_Model.Cursor = Cursors.Hand;
            lb_Model.Dock = DockStyle.Top;
            lb_Model.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lb_Model.ForeColor = SystemColors.ControlLightLight;
            lb_Model.Location = new Point(3, 386);
            lb_Model.Margin = new Padding(3, 10, 3, 0);
            lb_Model.Name = "lb_Model";
            lb_Model.Size = new Size(369, 50);
            lb_Model.TabIndex = 2;
            lb_Model.Text = "模板匹配工具";
            lb_Model.TextAlign = ContentAlignment.MiddleCenter;
            lb_Model.Click += lb_Model_Click;
            // 
            // pl_ImgHandle
            // 
            pl_ImgHandle.BorderStyle = BorderStyle.FixedSingle;
            pl_ImgHandle.Controls.Add(label6);
            pl_ImgHandle.Controls.Add(label5);
            pl_ImgHandle.Controls.Add(label4);
            pl_ImgHandle.Controls.Add(label3);
            pl_ImgHandle.Dock = DockStyle.Top;
            pl_ImgHandle.Location = new Point(3, 76);
            pl_ImgHandle.Name = "pl_ImgHandle";
            pl_ImgHandle.Size = new Size(369, 310);
            pl_ImgHandle.TabIndex = 1;
            // 
            // label6
            // 
            label6.BackColor = Color.Teal;
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(39, 245);
            label6.Name = "label6";
            label6.Size = new Size(303, 44);
            label6.TabIndex = 0;
            label6.Text = "图像锁定";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            label6.MouseDown += Tool_MouseDown;
            // 
            // label5
            // 
            label5.BackColor = Color.Teal;
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(39, 176);
            label5.Name = "label5";
            label5.Size = new Size(303, 44);
            label5.TabIndex = 0;
            label5.Text = "形态处理";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            label5.MouseDown += Tool_MouseDown;
            // 
            // label4
            // 
            label4.BackColor = Color.Teal;
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(39, 100);
            label4.Name = "label4";
            label4.Size = new Size(303, 44);
            label4.TabIndex = 0;
            label4.Text = "二值化";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.MouseDown += Tool_MouseDown;
            // 
            // label3
            // 
            label3.BackColor = Color.Teal;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(39, 23);
            label3.Name = "label3";
            label3.Size = new Size(303, 44);
            label3.TabIndex = 0;
            label3.Text = "图像采集";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.MouseDown += Tool_MouseDown;
            // 
            // lb_ImgHandle
            // 
            lb_ImgHandle.BackColor = Color.Teal;
            lb_ImgHandle.Cursor = Cursors.Hand;
            lb_ImgHandle.Dock = DockStyle.Top;
            lb_ImgHandle.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lb_ImgHandle.ForeColor = SystemColors.ControlLightLight;
            lb_ImgHandle.Location = new Point(3, 26);
            lb_ImgHandle.Margin = new Padding(3, 0, 3, 10);
            lb_ImgHandle.Name = "lb_ImgHandle";
            lb_ImgHandle.Size = new Size(369, 50);
            lb_ImgHandle.TabIndex = 0;
            lb_ImgHandle.Text = "图像处理工具";
            lb_ImgHandle.TextAlign = ContentAlignment.MiddleCenter;
            lb_ImgHandle.Click += lb_ImgHandle_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1209, 863);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "MainForm";
            Text = "朝夕的自研的视觉流程编辑器实战";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            pl_Model.ResumeLayout(false);
            pl_ImgHandle.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label lb_ImgHandle;
        private Panel pl_Model;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label lb_Model;
        private Panel pl_ImgHandle;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tm_link;
        private mycontrols.MyPanel pl_flowregion;
    }
}
