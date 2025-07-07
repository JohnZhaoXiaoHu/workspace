namespace MTHCollection.Project.Dialog
{
    partial class FrmVaribleConfig
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label5 = new Label();
            cbGroupName = new ComboBox();
            btnUpdateVarible = new Button();
            btnDeleteVarible = new Button();
            btnAddVarible = new Button();
            tbRemark = new TextBox();
            label4 = new Label();
            ndLength = new NumericUpDown();
            label3 = new Label();
            label2 = new Label();
            tbName = new TextBox();
            label1 = new Label();
            label6 = new Label();
            label7 = new Label();
            tbDataType = new TextBox();
            ckIsPosedgeAlarm = new CheckBox();
            ckIsFallEdgeAlarm = new CheckBox();
            ndStartAddress = new NumericUpDown();
            dgVarible = new DataGridView();
            VaribleName = new DataGridViewTextBoxColumn();
            GroupName = new DataGridViewTextBoxColumn();
            VaribleType = new DataGridViewTextBoxColumn();
            StartIndex = new DataGridViewTextBoxColumn();
            Scale = new DataGridViewTextBoxColumn();
            Offset = new DataGridViewTextBoxColumn();
            IsPosEdgeAlarm = new DataGridViewCheckBoxColumn();
            IsFallEdgeAlarm = new DataGridViewCheckBoxColumn();
            Remark = new DataGridViewTextBoxColumn();
            ndScale = new NumericUpDown();
            ndOffset = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)ndLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ndStartAddress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgVarible).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ndScale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ndOffset).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(12, 64);
            label5.Name = "label5";
            label5.Size = new Size(90, 21);
            label5.TabIndex = 28;
            label5.Text = "通信组名称";
            // 
            // cbGroupName
            // 
            cbGroupName.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGroupName.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbGroupName.FormattingEnabled = true;
            cbGroupName.Items.AddRange(new object[] { "bool", "short", "int", "long", "float", "double", "ushort", "uint" });
            cbGroupName.Location = new Point(108, 60);
            cbGroupName.Name = "cbGroupName";
            cbGroupName.Size = new Size(121, 29);
            cbGroupName.TabIndex = 20;
            cbGroupName.SelectedIndexChanged += cbGroupName_SelectedIndexChanged;
            // 
            // btnUpdateVarible
            // 
            btnUpdateVarible.BackColor = Color.Transparent;
            btnUpdateVarible.FlatStyle = FlatStyle.Flat;
            btnUpdateVarible.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdateVarible.ForeColor = Color.White;
            btnUpdateVarible.Location = new Point(740, 158);
            btnUpdateVarible.Name = "btnUpdateVarible";
            btnUpdateVarible.Size = new Size(101, 35);
            btnUpdateVarible.TabIndex = 26;
            btnUpdateVarible.Text = "修改变量";
            btnUpdateVarible.UseVisualStyleBackColor = false;
            btnUpdateVarible.Click += btnUpdateVarible_Click;
            // 
            // btnDeleteVarible
            // 
            btnDeleteVarible.BackColor = Color.Transparent;
            btnDeleteVarible.FlatStyle = FlatStyle.Flat;
            btnDeleteVarible.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteVarible.ForeColor = Color.White;
            btnDeleteVarible.Location = new Point(618, 158);
            btnDeleteVarible.Name = "btnDeleteVarible";
            btnDeleteVarible.Size = new Size(101, 35);
            btnDeleteVarible.TabIndex = 24;
            btnDeleteVarible.Text = "删除变量";
            btnDeleteVarible.UseVisualStyleBackColor = false;
            btnDeleteVarible.Click += btnDeleteVarible_Click;
            // 
            // btnAddVarible
            // 
            btnAddVarible.BackColor = Color.Transparent;
            btnAddVarible.FlatStyle = FlatStyle.Flat;
            btnAddVarible.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddVarible.ForeColor = Color.White;
            btnAddVarible.Location = new Point(497, 158);
            btnAddVarible.Name = "btnAddVarible";
            btnAddVarible.Size = new Size(101, 35);
            btnAddVarible.TabIndex = 23;
            btnAddVarible.Text = "新增变量";
            btnAddVarible.UseVisualStyleBackColor = false;
            btnAddVarible.Click += btnAddVarible_Click;
            // 
            // tbRemark
            // 
            tbRemark.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbRemark.Location = new Point(108, 160);
            tbRemark.Name = "tbRemark";
            tbRemark.Size = new Size(370, 29);
            tbRemark.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(12, 164);
            label4.Name = "label4";
            label4.Size = new Size(74, 21);
            label4.TabIndex = 27;
            label4.Text = "备注说明";
            // 
            // ndLength
            // 
            ndLength.Location = new Point(0, 0);
            ndLength.Name = "ndLength";
            ndLength.Size = new Size(120, 23);
            ndLength.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(911, 66);
            label3.Name = "label3";
            label3.Size = new Size(58, 21);
            label3.TabIndex = 25;
            label3.Text = "偏移量";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(556, 65);
            label2.Name = "label2";
            label2.Size = new Size(74, 21);
            label2.TabIndex = 22;
            label2.Text = "起始索引";
            // 
            // tbName
            // 
            tbName.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbName.Location = new Point(386, 62);
            tbName.Name = "tbName";
            tbName.Size = new Size(141, 29);
            tbName.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(290, 66);
            label1.Name = "label1";
            label1.Size = new Size(74, 21);
            label1.TabIndex = 17;
            label1.Text = "变量名称";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(745, 65);
            label6.Name = "label6";
            label6.Size = new Size(74, 21);
            label6.TabIndex = 30;
            label6.Text = "线性系数";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(12, 113);
            label7.Name = "label7";
            label7.Size = new Size(74, 21);
            label7.TabIndex = 32;
            label7.Text = "数据类型";
            // 
            // tbDataType
            // 
            tbDataType.Enabled = false;
            tbDataType.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbDataType.Location = new Point(108, 110);
            tbDataType.Name = "tbDataType";
            tbDataType.Size = new Size(121, 29);
            tbDataType.TabIndex = 33;
            // 
            // ckIsPosedgeAlarm
            // 
            ckIsPosedgeAlarm.AutoSize = true;
            ckIsPosedgeAlarm.BackColor = Color.Transparent;
            ckIsPosedgeAlarm.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckIsPosedgeAlarm.ForeColor = Color.White;
            ckIsPosedgeAlarm.Location = new Point(290, 114);
            ckIsPosedgeAlarm.Name = "ckIsPosedgeAlarm";
            ckIsPosedgeAlarm.Size = new Size(109, 25);
            ckIsPosedgeAlarm.TabIndex = 34;
            ckIsPosedgeAlarm.Text = "上升沿报警";
            ckIsPosedgeAlarm.UseVisualStyleBackColor = false;
            // 
            // ckIsFallEdgeAlarm
            // 
            ckIsFallEdgeAlarm.AutoSize = true;
            ckIsFallEdgeAlarm.BackColor = Color.Transparent;
            ckIsFallEdgeAlarm.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckIsFallEdgeAlarm.ForeColor = Color.White;
            ckIsFallEdgeAlarm.Location = new Point(440, 114);
            ckIsFallEdgeAlarm.Name = "ckIsFallEdgeAlarm";
            ckIsFallEdgeAlarm.Size = new Size(109, 25);
            ckIsFallEdgeAlarm.TabIndex = 35;
            ckIsFallEdgeAlarm.Text = "下降沿报警";
            ckIsFallEdgeAlarm.UseVisualStyleBackColor = false;
            // 
            // ndStartAddress
            // 
            ndStartAddress.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ndStartAddress.Location = new Point(636, 62);
            ndStartAddress.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            ndStartAddress.Name = "ndStartAddress";
            ndStartAddress.Size = new Size(72, 29);
            ndStartAddress.TabIndex = 18;
            // 
            // dgVarible
            // 
            dgVarible.AllowUserToAddRows = false;
            dgVarible.AllowUserToDeleteRows = false;
            dgVarible.AllowUserToResizeColumns = false;
            dgVarible.AllowUserToResizeRows = false;
            dgVarible.BackgroundColor = Color.FromArgb(4, 23, 65);
            dgVarible.BorderStyle = BorderStyle.Fixed3D;
            dgVarible.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(3, 24, 70);
            dataGridViewCellStyle1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgVarible.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgVarible.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgVarible.Columns.AddRange(new DataGridViewColumn[] { VaribleName, GroupName, VaribleType, StartIndex, Scale, Offset, IsPosEdgeAlarm, IsFallEdgeAlarm, Remark });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(4, 23, 65);
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgVarible.DefaultCellStyle = dataGridViewCellStyle2;
            dgVarible.EnableHeadersVisualStyles = false;
            dgVarible.Location = new Point(12, 210);
            dgVarible.Name = "dgVarible";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(4, 23, 65);
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgVarible.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = Color.Transparent;
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.Cyan;
            dgVarible.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgVarible.RowTemplate.Height = 25;
            dgVarible.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgVarible.Size = new Size(1027, 332);
            dgVarible.TabIndex = 36;
            dgVarible.CellClick += dgVarible_CellClick;
            dgVarible.CellFormatting += dgVarible_CellFormatting;
            dgVarible.RowPostPaint += dgVarible_RowPostPaint;
            // 
            // VaribleName
            // 
            VaribleName.DataPropertyName = "VaribleName";
            VaribleName.HeaderText = "变量名称";
            VaribleName.Name = "VaribleName";
            // 
            // GroupName
            // 
            GroupName.DataPropertyName = "GroupName";
            GroupName.HeaderText = "通信组";
            GroupName.Name = "GroupName";
            // 
            // VaribleType
            // 
            VaribleType.DataPropertyName = "VaribleType";
            VaribleType.HeaderText = "数据类型";
            VaribleType.Name = "VaribleType";
            // 
            // StartIndex
            // 
            StartIndex.DataPropertyName = "StartIndex";
            StartIndex.HeaderText = "起始索引";
            StartIndex.Name = "StartIndex";
            // 
            // Scale
            // 
            Scale.DataPropertyName = "Scale";
            Scale.HeaderText = "线性系数";
            Scale.Name = "Scale";
            // 
            // Offset
            // 
            Offset.DataPropertyName = "Offset";
            Offset.HeaderText = "偏移量";
            Offset.Name = "Offset";
            // 
            // IsPosEdgeAlarm
            // 
            IsPosEdgeAlarm.DataPropertyName = "IsPosEdgeAlarm";
            IsPosEdgeAlarm.HeaderText = "上升沿报警";
            IsPosEdgeAlarm.Name = "IsPosEdgeAlarm";
            // 
            // IsFallEdgeAlarm
            // 
            IsFallEdgeAlarm.DataPropertyName = "IsFallEdgeAlarm";
            IsFallEdgeAlarm.HeaderText = "下降沿报警";
            IsFallEdgeAlarm.Name = "IsFallEdgeAlarm";
            // 
            // Remark
            // 
            Remark.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Remark.DataPropertyName = "Remark";
            Remark.HeaderText = "备注说明";
            Remark.Name = "Remark";
            // 
            // ndScale
            // 
            ndScale.DecimalPlaces = 1;
            ndScale.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ndScale.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            ndScale.Location = new Point(820, 63);
            ndScale.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            ndScale.Name = "ndScale";
            ndScale.Size = new Size(78, 29);
            ndScale.TabIndex = 37;
            // 
            // ndOffset
            // 
            ndOffset.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ndOffset.Location = new Point(969, 63);
            ndOffset.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            ndOffset.Name = "ndOffset";
            ndOffset.Size = new Size(72, 29);
            ndOffset.TabIndex = 38;
            // 
            // FrmVaribleConfig
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.BackGround;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1067, 553);
            Controls.Add(ndOffset);
            Controls.Add(ndScale);
            Controls.Add(dgVarible);
            Controls.Add(ckIsFallEdgeAlarm);
            Controls.Add(ckIsPosedgeAlarm);
            Controls.Add(tbDataType);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cbGroupName);
            Controls.Add(btnUpdateVarible);
            Controls.Add(btnDeleteVarible);
            Controls.Add(btnAddVarible);
            Controls.Add(tbRemark);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(ndStartAddress);
            Controls.Add(label2);
            Controls.Add(tbName);
            Controls.Add(label1);
            Name = "FrmVaribleConfig";
            Text = "变量配置";
            TitleColor = Color.DarkBlue;
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += FrmVaribleConfig_Load;
            ((System.ComponentModel.ISupportInitialize)ndLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)ndStartAddress).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgVarible).EndInit();
            ((System.ComponentModel.ISupportInitialize)ndScale).EndInit();
            ((System.ComponentModel.ISupportInitialize)ndOffset).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private ComboBox cbGroupName;
        private Button btnUpdateVarible;
        private Button btnDeleteVarible;
        private Button btnAddVarible;
        private TextBox tbRemark;
        private Label label4;
        private NumericUpDown ndLength;
        private Label label3;
        private Label label2;
        private TextBox tbName;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private Label label6;
        private Label label7;
        private TextBox tbDataType;
        private CheckBox ckIsPosedgeAlarm;
        private CheckBox ckIsFallEdgeAlarm;
        private NumericUpDown ndStartAddress;
        private DataGridView dgVarible;
        private NumericUpDown ndScale;
        private NumericUpDown ndOffset;
        private DataGridViewTextBoxColumn VaribleName;
        private DataGridViewTextBoxColumn GroupName;
        private DataGridViewTextBoxColumn VaribleType;
        private DataGridViewTextBoxColumn StartIndex;
        private DataGridViewTextBoxColumn Scale;
        private DataGridViewTextBoxColumn Offset;
        private DataGridViewCheckBoxColumn IsPosEdgeAlarm;
        private DataGridViewCheckBoxColumn IsFallEdgeAlarm;
        private DataGridViewTextBoxColumn Remark;
    }
}