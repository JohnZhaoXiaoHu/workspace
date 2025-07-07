using Zhaoxi.NewVision.Editor.mycontrols;

namespace Zhaoxi.Vision.Flow.Proj.VFrame
{
    partial class CreateModelFrm
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
            groupBox1 = new GroupBox();
            cmbNumLevels = new ComboBox();
            txtMincontrast = new TextBox();
            label6 = new Label();
            txtContrast = new TextBox();
            label5 = new Label();
            txtMetric = new TextBox();
            label8 = new Label();
            txtOptimization = new TextBox();
            label4 = new Label();
            txtStartangle = new TextBox();
            label3 = new Label();
            txtStepangle = new TextBox();
            txtExtentAngle = new TextBox();
            label7 = new Label();
            label2 = new Label();
            label1 = new Label();
            button2 = new Button();
            myModelHW = new MyHWindowControl();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(89, 578);
            button1.Name = "button1";
            button1.Size = new Size(344, 50);
            button1.TabIndex = 1;
            button1.Text = "创建匹配模板";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbNumLevels);
            groupBox1.Controls.Add(txtMincontrast);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtContrast);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtMetric);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtOptimization);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtStartangle);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtStepangle);
            groupBox1.Controls.Add(txtExtentAngle);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(613, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(325, 528);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "模板参数设置";
            // 
            // cmbNumLevels
            // 
            cmbNumLevels.FormattingEnabled = true;
            cmbNumLevels.Items.AddRange(new object[] { "auto", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cmbNumLevels.Location = new Point(140, 34);
            cmbNumLevels.Name = "cmbNumLevels";
            cmbNumLevels.Size = new Size(150, 32);
            cmbNumLevels.TabIndex = 2;
            cmbNumLevels.Text = "auto";
            // 
            // txtMincontrast
            // 
            txtMincontrast.Location = new Point(140, 469);
            txtMincontrast.Name = "txtMincontrast";
            txtMincontrast.Size = new Size(150, 30);
            txtMincontrast.TabIndex = 1;
            txtMincontrast.Text = "40";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 475);
            label6.Name = "label6";
            label6.Size = new Size(100, 24);
            label6.TabIndex = 0;
            label6.Text = "最小对比度";
            // 
            // txtContrast
            // 
            txtContrast.Location = new Point(140, 413);
            txtContrast.Name = "txtContrast";
            txtContrast.Size = new Size(150, 30);
            txtContrast.TabIndex = 1;
            txtContrast.Text = "25";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 416);
            label5.Name = "label5";
            label5.Size = new Size(100, 24);
            label5.TabIndex = 0;
            label5.Text = "对比度阈值";
            // 
            // txtMetric
            // 
            txtMetric.Location = new Point(140, 352);
            txtMetric.Name = "txtMetric";
            txtMetric.Size = new Size(150, 30);
            txtMetric.TabIndex = 1;
            txtMetric.Text = "use_polarity";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(46, 355);
            label8.Name = "label8";
            label8.Size = new Size(82, 24);
            label8.TabIndex = 0;
            label8.Text = "匹配指标";
            // 
            // txtOptimization
            // 
            txtOptimization.Location = new Point(140, 290);
            txtOptimization.Name = "txtOptimization";
            txtOptimization.Size = new Size(150, 30);
            txtOptimization.TabIndex = 1;
            txtOptimization.Text = "auto";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 293);
            label4.Name = "label4";
            label4.Size = new Size(82, 24);
            label4.TabIndex = 0;
            label4.Text = "优化类型";
            // 
            // txtStartangle
            // 
            txtStartangle.Location = new Point(140, 95);
            txtStartangle.Name = "txtStartangle";
            txtStartangle.Size = new Size(150, 30);
            txtStartangle.TabIndex = 1;
            txtStartangle.Text = "4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 37);
            label3.Name = "label3";
            label3.Size = new Size(82, 24);
            label3.TabIndex = 0;
            label3.Text = "金字塔数";
            // 
            // txtStepangle
            // 
            txtStepangle.Location = new Point(140, 220);
            txtStepangle.Name = "txtStepangle";
            txtStepangle.Size = new Size(150, 30);
            txtStepangle.TabIndex = 1;
            txtStepangle.Text = "auto";
            // 
            // txtExtentAngle
            // 
            txtExtentAngle.Location = new Point(140, 160);
            txtExtentAngle.Name = "txtExtentAngle";
            txtExtentAngle.Size = new Size(150, 30);
            txtExtentAngle.TabIndex = 1;
            txtExtentAngle.Text = "360";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(46, 223);
            label7.Name = "label7";
            label7.Size = new Size(82, 24);
            label7.TabIndex = 0;
            label7.Text = "角度步长";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 163);
            label2.Name = "label2";
            label2.Size = new Size(82, 24);
            label2.TabIndex = 0;
            label2.Text = "角度范围";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 98);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 0;
            label1.Text = "起始角度";
            // 
            // button2
            // 
            button2.Location = new Point(527, 578);
            button2.Name = "button2";
            button2.Size = new Size(344, 50);
            button2.TabIndex = 1;
            button2.Text = "完成";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // myModelHW
            // 
            myModelHW.BackColor = Color.Black;
            myModelHW.BorderColor = Color.Black;
            myModelHW.ImagePart = new Rectangle(0, 0, 640, 480);
            myModelHW.Location = new Point(12, 12);
            myModelHW.Name = "myModelHW";
            myModelHW.Size = new Size(586, 528);
            myModelHW.TabIndex = 3;
            myModelHW.WindowSize = new Size(586, 528);
            // 
            // CreateModelFrm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 647);
            Controls.Add(myModelHW);
            Controls.Add(groupBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "CreateModelFrm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "创建模板窗口";
            Load += CreateModelFrm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private GroupBox groupBox1;
        private TextBox txtOptimization;
        private Label label4;
        private TextBox txtStartangle;
        private Label label3;
        private TextBox txtExtentAngle;
        private Label label2;
        private Label label1;
        private TextBox txtMincontrast;
        private Label label6;
        private TextBox txtContrast;
        private Label label5;
        private Button button2;
        private ComboBox cmbNumLevels;
        private TextBox txtStepangle;
        private Label label7;
        private TextBox txtMetric;
        private Label label8;
        private MyHWindowControl myModelHW;
    }
}