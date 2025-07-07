namespace DragVision.Plugin.Dialog.模版匹配工具
{
    partial class FrmFindNccMatch
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            cbNumLevels = new ComboBox();
            label8 = new Label();
            cbSubpixel = new ComboBox();
            label7 = new Label();
            textMaxOverlap = new TextBox();
            label6 = new Label();
            textNumMatch = new TextBox();
            label5 = new Label();
            textMinScore = new TextBox();
            label4 = new Label();
            textAngleExtend = new TextBox();
            label3 = new Label();
            textAngleStart = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnExcuteComplete = new Button();
            btnFindMatch = new Button();
            Angle = new DataGridViewTextBoxColumn();
            Column = new DataGridViewTextBoxColumn();
            Row = new DataGridViewTextBoxColumn();
            textMatchedNum = new TextBox();
            label11 = new Label();
            textMatchTimeSpan = new TextBox();
            label10 = new Label();
            dgMatchResult = new DataGridView();
            Score = new DataGridViewTextBoxColumn();
            halconDisplayControl1 = new Controls.HalconDisplayControl();
            splitContainer2 = new SplitContainer();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)dgMatchResult).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // cbNumLevels
            // 
            cbNumLevels.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            cbNumLevels.FormattingEnabled = true;
            cbNumLevels.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbNumLevels.Location = new Point(98, 294);
            cbNumLevels.Name = "cbNumLevels";
            cbNumLevels.Size = new Size(147, 28);
            cbNumLevels.TabIndex = 19;
            cbNumLevels.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(3, 298);
            label8.Name = "label8";
            label8.Size = new Size(83, 19);
            label8.TabIndex = 18;
            label8.Text = "金字塔层数:";
            // 
            // cbSubpixel
            // 
            cbSubpixel.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            cbSubpixel.FormattingEnabled = true;
            cbSubpixel.Items.AddRange(new object[] { "false ", "true" });
            cbSubpixel.Location = new Point(97, 250);
            cbSubpixel.Name = "cbSubpixel";
            cbSubpixel.Size = new Size(147, 28);
            cbSubpixel.TabIndex = 17;
            cbSubpixel.Text = "true";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(3, 254);
            label7.Name = "label7";
            label7.Size = new Size(83, 19);
            label7.TabIndex = 16;
            label7.Text = "亚像素精度:";
            // 
            // textMaxOverlap
            // 
            textMaxOverlap.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            textMaxOverlap.Location = new Point(97, 208);
            textMaxOverlap.Name = "textMaxOverlap";
            textMaxOverlap.Size = new Size(147, 26);
            textMaxOverlap.TabIndex = 15;
            textMaxOverlap.Text = "0.5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(8, 212);
            label6.Name = "label6";
            label6.Size = new Size(83, 19);
            label6.TabIndex = 14;
            label6.Text = "最大重叠率:";
            // 
            // textNumMatch
            // 
            textNumMatch.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            textNumMatch.Location = new Point(97, 163);
            textNumMatch.Name = "textNumMatch";
            textNumMatch.Size = new Size(147, 26);
            textNumMatch.TabIndex = 13;
            textNumMatch.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(10, 167);
            label5.Name = "label5";
            label5.Size = new Size(69, 19);
            label5.TabIndex = 12;
            label5.Text = "匹配数量:";
            // 
            // textMinScore
            // 
            textMinScore.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            textMinScore.Location = new Point(97, 118);
            textMinScore.Name = "textMinScore";
            textMinScore.Size = new Size(147, 26);
            textMinScore.TabIndex = 11;
            textMinScore.Text = "0.7";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(10, 122);
            label4.Name = "label4";
            label4.Size = new Size(69, 19);
            label4.TabIndex = 10;
            label4.Text = "最小分数:";
            // 
            // textAngleExtend
            // 
            textAngleExtend.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            textAngleExtend.Location = new Point(97, 77);
            textAngleExtend.Name = "textAngleExtend";
            textAngleExtend.Size = new Size(147, 26);
            textAngleExtend.TabIndex = 9;
            textAngleExtend.Text = "360";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(10, 81);
            label3.Name = "label3";
            label3.Size = new Size(69, 19);
            label3.TabIndex = 8;
            label3.Text = "角度范围:";
            // 
            // textAngleStart
            // 
            textAngleStart.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            textAngleStart.Location = new Point(97, 38);
            textAngleStart.Name = "textAngleStart";
            textAngleStart.Size = new Size(147, 26);
            textAngleStart.TabIndex = 7;
            textAngleStart.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(10, 42);
            label2.Name = "label2";
            label2.Size = new Size(69, 19);
            label2.TabIndex = 5;
            label2.Text = "起始角度:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(45, 5);
            label1.Name = "label1";
            label1.Size = new Size(170, 22);
            label1.TabIndex = 4;
            label1.Text = "查找形状匹配模板参数";
            // 
            // btnExcuteComplete
            // 
            btnExcuteComplete.BackColor = Color.Teal;
            btnExcuteComplete.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnExcuteComplete.ForeColor = Color.White;
            btnExcuteComplete.Location = new Point(45, 481);
            btnExcuteComplete.Name = "btnExcuteComplete";
            btnExcuteComplete.Size = new Size(130, 50);
            btnExcuteComplete.TabIndex = 3;
            btnExcuteComplete.Text = "执行完成";
            btnExcuteComplete.UseVisualStyleBackColor = false;
            btnExcuteComplete.Click += btnExcuteComplete_Click;
            // 
            // btnFindMatch
            // 
            btnFindMatch.BackColor = Color.Teal;
            btnFindMatch.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnFindMatch.ForeColor = Color.White;
            btnFindMatch.Location = new Point(45, 411);
            btnFindMatch.Name = "btnFindMatch";
            btnFindMatch.Size = new Size(130, 50);
            btnFindMatch.TabIndex = 2;
            btnFindMatch.Text = "查找匹配";
            btnFindMatch.UseVisualStyleBackColor = false;
            btnFindMatch.Click += btnFindMatch_Click;
            // 
            // Angle
            // 
            Angle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Angle.DataPropertyName = "Angle";
            Angle.FillWeight = 120F;
            Angle.HeaderText = "角度";
            Angle.Name = "Angle";
            // 
            // Column
            // 
            Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column.DataPropertyName = "Column";
            Column.FillWeight = 120F;
            Column.HeaderText = "纵坐标";
            Column.Name = "Column";
            // 
            // Row
            // 
            Row.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Row.DataPropertyName = "Row";
            Row.FillWeight = 150F;
            Row.HeaderText = "横坐标";
            Row.Name = "Row";
            // 
            // textMatchedNum
            // 
            textMatchedNum.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            textMatchedNum.Location = new Point(397, 6);
            textMatchedNum.Name = "textMatchedNum";
            textMatchedNum.Size = new Size(147, 26);
            textMatchedNum.TabIndex = 25;
            textMatchedNum.Text = "0";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(294, 8);
            label11.Name = "label11";
            label11.Size = new Size(97, 19);
            label11.TabIndex = 24;
            label11.Text = "匹配到的数量:";
            // 
            // textMatchTimeSpan
            // 
            textMatchTimeSpan.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            textMatchTimeSpan.Location = new Point(78, 4);
            textMatchTimeSpan.Name = "textMatchTimeSpan";
            textMatchTimeSpan.Size = new Size(147, 26);
            textMatchTimeSpan.TabIndex = 23;
            textMatchTimeSpan.Text = "0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(3, 6);
            label10.Name = "label10";
            label10.Size = new Size(69, 19);
            label10.TabIndex = 22;
            label10.Text = "匹配耗时:";
            // 
            // dgMatchResult
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgMatchResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgMatchResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgMatchResult.Columns.AddRange(new DataGridViewColumn[] { Row, Column, Angle, Score });
            dgMatchResult.Dock = DockStyle.Bottom;
            dgMatchResult.Location = new Point(0, 39);
            dgMatchResult.Name = "dgMatchResult";
            dgMatchResult.RowHeadersVisible = false;
            dgMatchResult.RowTemplate.Height = 25;
            dgMatchResult.Size = new Size(580, 180);
            dgMatchResult.TabIndex = 0;
            // 
            // Score
            // 
            Score.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Score.DataPropertyName = "Score";
            Score.FillWeight = 120F;
            Score.HeaderText = "分数";
            Score.Name = "Score";
            // 
            // halconDisplayControl1
            // 
            halconDisplayControl1.Dock = DockStyle.Fill;
            halconDisplayControl1.Location = new Point(0, 0);
            halconDisplayControl1.Name = "halconDisplayControl1";
            halconDisplayControl1.Size = new Size(580, 314);
            halconDisplayControl1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(halconDisplayControl1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(textMatchedNum);
            splitContainer2.Panel2.Controls.Add(label11);
            splitContainer2.Panel2.Controls.Add(textMatchTimeSpan);
            splitContainer2.Panel2.Controls.Add(label10);
            splitContainer2.Panel2.Controls.Add(dgMatchResult);
            splitContainer2.Size = new Size(580, 537);
            splitContainer2.SplitterDistance = 314;
            splitContainer2.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(cbNumLevels);
            splitContainer1.Panel2.Controls.Add(label8);
            splitContainer1.Panel2.Controls.Add(cbSubpixel);
            splitContainer1.Panel2.Controls.Add(label7);
            splitContainer1.Panel2.Controls.Add(textMaxOverlap);
            splitContainer1.Panel2.Controls.Add(label6);
            splitContainer1.Panel2.Controls.Add(textNumMatch);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(textMinScore);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(textAngleExtend);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(textAngleStart);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(btnExcuteComplete);
            splitContainer1.Panel2.Controls.Add(btnFindMatch);
            splitContainer1.Size = new Size(849, 537);
            splitContainer1.SplitterDistance = 580;
            splitContainer1.TabIndex = 1;
            // 
            // FrmFindNccMatch
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(849, 537);
            Controls.Add(splitContainer1);
            Name = "FrmFindNccMatch";
            Text = "FrmFindNccMatch";
            Load += FrmFindNccMatch_Load;
            ((System.ComponentModel.ISupportInitialize)dgMatchResult).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ComboBox cbNumLevels;
        private Label label8;
        private ComboBox cbSubpixel;
        private Label label7;
        private TextBox textMaxOverlap;
        private Label label6;
        private TextBox textNumMatch;
        private Label label5;
        private TextBox textMinScore;
        private Label label4;
        private TextBox textAngleExtend;
        private Label label3;
        private TextBox textAngleStart;
        private Label label2;
        private Label label1;
        private Button btnExcuteComplete;
        private Button btnFindMatch;
        private DataGridViewTextBoxColumn Angle;
        private DataGridViewTextBoxColumn Column;
        private DataGridViewTextBoxColumn Row;
        private TextBox textMatchedNum;
        private Label label11;
        private TextBox textMatchTimeSpan;
        private Label label10;
        private DataGridView dgMatchResult;
        private DataGridViewTextBoxColumn Score;
        private Controls.HalconDisplayControl halconDisplayControl1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer1;
    }
}