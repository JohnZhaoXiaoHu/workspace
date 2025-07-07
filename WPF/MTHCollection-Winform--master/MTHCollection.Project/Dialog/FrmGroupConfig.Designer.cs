namespace MTHCollection.Project.Dialog
{
    partial class FrmGroupConfig
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
            cbSaveArea = new ComboBox();
            Remark = new DataGridViewTextBoxColumn();
            SaveAreaName = new DataGridViewTextBoxColumn();
            Length = new DataGridViewTextBoxColumn();
            StartAddress = new DataGridViewTextBoxColumn();
            GroupName = new DataGridViewTextBoxColumn();
            dgGroup = new DataGridView();
            btnUpdateGroup = new Button();
            btnDeleteGroup = new Button();
            btnAddGroup = new Button();
            label4 = new Label();
            tbRemark = new TextBox();
            label3 = new Label();
            ndLength = new NumericUpDown();
            ndStartAddress = new NumericUpDown();
            label2 = new Label();
            tbName = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgGroup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ndLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ndStartAddress).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(672, 63);
            label5.Name = "label5";
            label5.Size = new Size(90, 21);
            label5.TabIndex = 15;
            label5.Text = "存储区名称";
            // 
            // cbSaveArea
            // 
            cbSaveArea.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbSaveArea.FormattingEnabled = true;
            cbSaveArea.Items.AddRange(new object[] { "Bool", "Short", "Int", "Long", "Float", "Double", "Ushort", "Uint" });
            cbSaveArea.Location = new Point(768, 59);
            cbSaveArea.Name = "cbSaveArea";
            cbSaveArea.Size = new Size(121, 29);
            cbSaveArea.TabIndex = 3;
            // 
            // Remark
            // 
            Remark.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Remark.DataPropertyName = "Remark";
            Remark.HeaderText = "备注说明";
            Remark.Name = "Remark";
            // 
            // SaveAreaName
            // 
            SaveAreaName.DataPropertyName = "SaveAreaName";
            SaveAreaName.HeaderText = "存储区名称";
            SaveAreaName.Name = "SaveAreaName";
            // 
            // Length
            // 
            Length.DataPropertyName = "Length";
            Length.HeaderText = "长度";
            Length.Name = "Length";
            // 
            // StartAddress
            // 
            StartAddress.DataPropertyName = "StartAddress";
            StartAddress.HeaderText = "起始地址";
            StartAddress.Name = "StartAddress";
            // 
            // GroupName
            // 
            GroupName.DataPropertyName = "GroupName";
            GroupName.HeaderText = "通信组名称";
            GroupName.Name = "GroupName";
            // 
            // dgGroup
            // 
            dgGroup.AllowUserToAddRows = false;
            dgGroup.AllowUserToDeleteRows = false;
            dgGroup.AllowUserToResizeColumns = false;
            dgGroup.AllowUserToResizeRows = false;
            dgGroup.BackgroundColor = Color.FromArgb(4, 21, 65);
            dgGroup.BorderStyle = BorderStyle.Fixed3D;
            dgGroup.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(4, 21, 65);
            dataGridViewCellStyle1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgGroup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgGroup.Columns.AddRange(new DataGridViewColumn[] { GroupName, StartAddress, Length, SaveAreaName, Remark });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(4, 21, 65);
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = Color.Cyan;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgGroup.DefaultCellStyle = dataGridViewCellStyle2;
            dgGroup.EnableHeadersVisualStyles = false;
            dgGroup.GridColor = Color.White;
            dgGroup.Location = new Point(25, 177);
            dgGroup.MultiSelect = false;
            dgGroup.Name = "dgGroup";
            dgGroup.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(4, 21, 65);
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgGroup.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = Color.Transparent;
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(128, 128, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.Cyan;
            dgGroup.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgGroup.RowTemplate.Height = 25;
            dgGroup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgGroup.Size = new Size(816, 283);
            dgGroup.TabIndex = 13;
            dgGroup.CellClick += dgGroup_CellClick;
            dgGroup.CellFormatting += dgGroup_CellFormatting;
            dgGroup.RowPostPaint += dgGroup_RowPostPaint;
            // 
            // btnUpdateGroup
            // 
            btnUpdateGroup.BackColor = Color.Transparent;
            btnUpdateGroup.FlatStyle = FlatStyle.Flat;
            btnUpdateGroup.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdateGroup.ForeColor = Color.White;
            btnUpdateGroup.Location = new Point(740, 117);
            btnUpdateGroup.Name = "btnUpdateGroup";
            btnUpdateGroup.Size = new Size(101, 35);
            btnUpdateGroup.TabIndex = 7;
            btnUpdateGroup.Text = "修改通讯组";
            btnUpdateGroup.UseVisualStyleBackColor = false;
            btnUpdateGroup.Click += btnUpdateGroup_Click;
            // 
            // btnDeleteGroup
            // 
            btnDeleteGroup.BackColor = Color.Transparent;
            btnDeleteGroup.FlatStyle = FlatStyle.Flat;
            btnDeleteGroup.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteGroup.ForeColor = Color.White;
            btnDeleteGroup.Location = new Point(618, 117);
            btnDeleteGroup.Name = "btnDeleteGroup";
            btnDeleteGroup.Size = new Size(101, 35);
            btnDeleteGroup.TabIndex = 6;
            btnDeleteGroup.Text = "删除通讯组";
            btnDeleteGroup.UseVisualStyleBackColor = false;
            btnDeleteGroup.Click += btnDeleteGroup_Click;
            // 
            // btnAddGroup
            // 
            btnAddGroup.BackColor = Color.Transparent;
            btnAddGroup.FlatStyle = FlatStyle.Flat;
            btnAddGroup.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddGroup.ForeColor = Color.White;
            btnAddGroup.Location = new Point(497, 117);
            btnAddGroup.Name = "btnAddGroup";
            btnAddGroup.Size = new Size(101, 35);
            btnAddGroup.TabIndex = 5;
            btnAddGroup.Text = "新增通讯组";
            btnAddGroup.UseVisualStyleBackColor = false;
            btnAddGroup.Click += btnAddGroup_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(12, 123);
            label4.Name = "label4";
            label4.Size = new Size(74, 21);
            label4.TabIndex = 8;
            label4.Text = "备注说明";
            // 
            // tbRemark
            // 
            tbRemark.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbRemark.Location = new Point(108, 119);
            tbRemark.Name = "tbRemark";
            tbRemark.Size = new Size(370, 29);
            tbRemark.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(527, 61);
            label3.Name = "label3";
            label3.Size = new Size(42, 21);
            label3.TabIndex = 6;
            label3.Text = "长度";
            // 
            // ndLength
            // 
            ndLength.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ndLength.Location = new Point(588, 57);
            ndLength.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            ndLength.Name = "ndLength";
            ndLength.Size = new Size(59, 29);
            ndLength.TabIndex = 2;
            // 
            // ndStartAddress
            // 
            ndStartAddress.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ndStartAddress.Location = new Point(358, 55);
            ndStartAddress.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            ndStartAddress.Name = "ndStartAddress";
            ndStartAddress.Size = new Size(120, 29);
            ndStartAddress.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(278, 58);
            label2.Name = "label2";
            label2.Size = new Size(74, 21);
            label2.TabIndex = 4;
            label2.Text = "起始地址";
            // 
            // tbName
            // 
            tbName.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbName.Location = new Point(108, 55);
            tbName.Name = "tbName";
            tbName.Size = new Size(141, 29);
            tbName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 59);
            label1.Name = "label1";
            label1.Size = new Size(90, 21);
            label1.TabIndex = 0;
            label1.Text = "通信组名称";
            // 
            // FrmGroupConfig
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.BackGround;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(903, 475);
            Controls.Add(label5);
            Controls.Add(cbSaveArea);
            Controls.Add(dgGroup);
            Controls.Add(btnUpdateGroup);
            Controls.Add(btnDeleteGroup);
            Controls.Add(btnAddGroup);
            Controls.Add(tbRemark);
            Controls.Add(label4);
            Controls.Add(ndLength);
            Controls.Add(label3);
            Controls.Add(ndStartAddress);
            Controls.Add(label2);
            Controls.Add(tbName);
            Controls.Add(label1);
            Name = "FrmGroupConfig";
            Text = "通信组配置";
            TitleColor = Color.DarkBlue;
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += FrmGroupConfig_Load;
            ((System.ComponentModel.ISupportInitialize)dgGroup).EndInit();
            ((System.ComponentModel.ISupportInitialize)ndLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)ndStartAddress).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private ComboBox cbSaveArea;
        private DataGridViewTextBoxColumn Remark;
        private DataGridViewTextBoxColumn SaveAreaName;
        private DataGridViewTextBoxColumn Length;
        private DataGridViewTextBoxColumn StartAddress;
        private DataGridViewTextBoxColumn GroupName;
        private DataGridView dgGroup;
        private Button btnUpdateGroup;
        private Button btnDeleteGroup;
        private Button btnAddGroup;
        private Label label4;
        private TextBox tbRemark;
        private Label label3;
        private NumericUpDown ndLength;
        private NumericUpDown ndStartAddress;
        private Label label2;
        private TextBox tbName;
        private Label label1;
    }
}