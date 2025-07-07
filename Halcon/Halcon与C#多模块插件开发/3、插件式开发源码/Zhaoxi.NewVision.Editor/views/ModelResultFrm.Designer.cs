using Zhaoxi.NewVision.Editor.mycontrols;

namespace Zhaoxi.Flow.Editor.Tools
{
    partial class ModelResultFrm
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
            components = new System.ComponentModel.Container();
            hw = new MyHWindowControl();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            butt = new Button();
            button6 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // hw
            // 
            hw.Location = new Point(22, 12);
            hw.Name = "hw";
            hw.Size = new Size(544, 387);
            hw.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(192, 435);
            button1.Name = "button1";
            button1.Size = new Size(160, 53);
            button1.TabIndex = 1;
            button1.Text = "加载单图";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(363, 435);
            button2.Name = "button2";
            button2.Size = new Size(160, 53);
            button2.TabIndex = 1;
            button2.Text = "加载多图";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(532, 435);
            button3.Name = "button3";
            button3.Size = new Size(160, 53);
            button3.TabIndex = 1;
            button3.Text = "测试结果";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(22, 435);
            button4.Name = "button4";
            button4.Size = new Size(160, 53);
            button4.TabIndex = 1;
            button4.Text = "选择模板及轮廓";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // butt
            // 
            butt.Location = new Point(598, 38);
            butt.Name = "butt";
            butt.Size = new Size(94, 34);
            butt.TabIndex = 2;
            butt.Text = "上一张";
            butt.UseVisualStyleBackColor = true;
            butt.Click += butt_Click;
            // 
            // button6
            // 
            button6.Location = new Point(598, 129);
            button6.Name = "button6";
            button6.Size = new Size(94, 34);
            button6.TabIndex = 2;
            button6.Text = "下一张";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // ModelResultFrm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(722, 513);
            Controls.Add(button6);
            Controls.Add(butt);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button4);
            Controls.Add(button1);
            Controls.Add(hw);
            Name = "ModelResultFrm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "模板匹配结果";
            ResumeLayout(false);
        }

        #endregion

        private MyHWindowControl hw;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button butt;
        private Button button6;
        private System.Windows.Forms.Timer timer1;
    }
}