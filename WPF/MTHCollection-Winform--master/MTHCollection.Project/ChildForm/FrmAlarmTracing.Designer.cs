namespace MTHCollection.Project.ChildForm
{
    partial class FrmAlarmTracing
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label1 = new Label();
            cbAlarmType = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            btnOutputExcel = new Button();
            btnTimeSearch = new Button();
            dgAlarmTracing = new DataGridView();
            AlarmTime = new DataGridViewTextBoxColumn();
            AlarmType = new DataGridViewTextBoxColumn();
            AlarmContent = new DataGridViewTextBoxColumn();
            UserName = new DataGridViewTextBoxColumn();
            VaribleName = new DataGridViewTextBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            dtStartTime = new Sunny.UI.UIDatetimePicker();
            dtEndTime = new Sunny.UI.UIDatetimePicker();
            ((System.ComponentModel.ISupportInitialize)dgAlarmTracing).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(40, 17);
            label1.Name = "label1";
            label1.Size = new Size(78, 21);
            label1.TabIndex = 0;
            label1.Text = "报警类型:";
            // 
            // cbAlarmType
            // 
            cbAlarmType.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbAlarmType.FormattingEnabled = true;
            cbAlarmType.Items.AddRange(new object[] { "全部", "启用", "禁用" });
            cbAlarmType.Location = new Point(139, 14);
            cbAlarmType.Name = "cbAlarmType";
            cbAlarmType.Size = new Size(152, 29);
            cbAlarmType.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(368, 20);
            label2.Name = "label2";
            label2.Size = new Size(78, 21);
            label2.TabIndex = 3;
            label2.Text = "开始时间:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(722, 20);
            label3.Name = "label3";
            label3.Size = new Size(78, 21);
            label3.TabIndex = 4;
            label3.Text = "结束时间:";
            // 
            // btnOutputExcel
            // 
            btnOutputExcel.FlatStyle = FlatStyle.Flat;
            btnOutputExcel.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnOutputExcel.ForeColor = Color.White;
            btnOutputExcel.Location = new Point(1211, 11);
            btnOutputExcel.Name = "btnOutputExcel";
            btnOutputExcel.Size = new Size(96, 35);
            btnOutputExcel.TabIndex = 22;
            btnOutputExcel.Text = "导出Excel";
            btnOutputExcel.UseVisualStyleBackColor = true;
            btnOutputExcel.Click += btnOutputExcel_Click;
            // 
            // btnTimeSearch
            // 
            btnTimeSearch.FlatStyle = FlatStyle.Flat;
            btnTimeSearch.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnTimeSearch.ForeColor = Color.White;
            btnTimeSearch.Location = new Point(1072, 11);
            btnTimeSearch.Name = "btnTimeSearch";
            btnTimeSearch.Size = new Size(96, 35);
            btnTimeSearch.TabIndex = 21;
            btnTimeSearch.Text = "时间查询";
            btnTimeSearch.UseVisualStyleBackColor = true;
            btnTimeSearch.Click += btnTimeSearch_Click;
            // 
            // dgAlarmTracing
            // 
            dgAlarmTracing.AllowUserToAddRows = false;
            dgAlarmTracing.AllowUserToDeleteRows = false;
            dgAlarmTracing.AllowUserToResizeColumns = false;
            dgAlarmTracing.AllowUserToResizeRows = false;
            dgAlarmTracing.BackgroundColor = Color.FromArgb(4, 21, 65);
            dgAlarmTracing.BorderStyle = BorderStyle.Fixed3D;
            dgAlarmTracing.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(4, 21, 65);
            dataGridViewCellStyle1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgAlarmTracing.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgAlarmTracing.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgAlarmTracing.Columns.AddRange(new DataGridViewColumn[] { AlarmTime, AlarmType, AlarmContent, UserName, VaribleName, Id });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(4, 21, 65);
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = Color.Cyan;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgAlarmTracing.DefaultCellStyle = dataGridViewCellStyle2;
            dgAlarmTracing.EnableHeadersVisualStyles = false;
            dgAlarmTracing.GridColor = Color.White;
            dgAlarmTracing.Location = new Point(40, 66);
            dgAlarmTracing.MultiSelect = false;
            dgAlarmTracing.Name = "dgAlarmTracing";
            dgAlarmTracing.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(4, 21, 65);
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgAlarmTracing.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = Color.Transparent;
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(128, 128, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.Cyan;
            dgAlarmTracing.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgAlarmTracing.RowTemplate.Height = 25;
            dgAlarmTracing.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgAlarmTracing.Size = new Size(1293, 580);
            dgAlarmTracing.TabIndex = 23;
            dgAlarmTracing.CellFormatting += dgAlarmTracing_CellFormatting;
            dgAlarmTracing.RowPostPaint += dgAlarmTracing_RowPostPaint;
            // 
            // AlarmTime
            // 
            AlarmTime.DataPropertyName = "AlarmTime";
            AlarmTime.FillWeight = 200F;
            AlarmTime.HeaderText = "日期时间";
            AlarmTime.Name = "AlarmTime";
            AlarmTime.Width = 200;
            // 
            // AlarmType
            // 
            AlarmType.DataPropertyName = "AlarmType";
            AlarmType.FillWeight = 120F;
            AlarmType.HeaderText = "报警类型";
            AlarmType.Name = "AlarmType";
            // 
            // AlarmContent
            // 
            AlarmContent.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            AlarmContent.DataPropertyName = "AlarmContent";
            AlarmContent.HeaderText = "日志报警信息";
            AlarmContent.Name = "AlarmContent";
            // 
            // UserName
            // 
            UserName.DataPropertyName = "UserName";
            UserName.FillWeight = 120F;
            UserName.HeaderText = "操作员";
            UserName.Name = "UserName";
            UserName.Width = 120;
            // 
            // VaribleName
            // 
            VaribleName.DataPropertyName = "VaribleName";
            VaribleName.HeaderText = "变量名称";
            VaribleName.Name = "VaribleName";
            VaribleName.Width = 160;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.Visible = false;
            // 
            // dtStartTime
            // 
            dtStartTime.FillColor = Color.White;
            dtStartTime.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtStartTime.Location = new Point(476, 17);
            dtStartTime.Margin = new Padding(4, 5, 4, 5);
            dtStartTime.MaxLength = 19;
            dtStartTime.MinimumSize = new Size(63, 0);
            dtStartTime.Name = "dtStartTime";
            dtStartTime.Padding = new Padding(0, 0, 30, 2);
            dtStartTime.Size = new Size(200, 29);
            dtStartTime.SymbolDropDown = 61555;
            dtStartTime.SymbolNormal = 61555;
            dtStartTime.SymbolSize = 24;
            dtStartTime.TabIndex = 24;
            dtStartTime.Text = "2025-01-13 18:32:02";
            dtStartTime.TextAlignment = ContentAlignment.MiddleLeft;
            dtStartTime.Value = new DateTime(2025, 1, 13, 18, 32, 2, 934);
            dtStartTime.Watermark = "";
            // 
            // dtEndTime
            // 
            dtEndTime.FillColor = Color.White;
            dtEndTime.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtEndTime.Location = new Point(821, 17);
            dtEndTime.Margin = new Padding(4, 5, 4, 5);
            dtEndTime.MaxLength = 19;
            dtEndTime.MinimumSize = new Size(63, 0);
            dtEndTime.Name = "dtEndTime";
            dtEndTime.Padding = new Padding(0, 0, 30, 2);
            dtEndTime.Size = new Size(200, 29);
            dtEndTime.SymbolDropDown = 61555;
            dtEndTime.SymbolNormal = 61555;
            dtEndTime.SymbolSize = 24;
            dtEndTime.TabIndex = 25;
            dtEndTime.Text = "2025-01-13 18:32:35";
            dtEndTime.TextAlignment = ContentAlignment.MiddleLeft;
            dtEndTime.Value = new DateTime(2025, 1, 13, 18, 32, 35, 998);
            dtEndTime.Watermark = "";
            // 
            // FrmAlarmTracing
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(dtEndTime);
            Controls.Add(dtStartTime);
            Controls.Add(dgAlarmTracing);
            Controls.Add(btnOutputExcel);
            Controls.Add(btnTimeSearch);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cbAlarmType);
            Controls.Add(label1);
            Name = "FrmAlarmTracing";
            Size = new Size(1440, 960);
            Load += FrmAlarmTracing_Load;
            ((System.ComponentModel.ISupportInitialize)dgAlarmTracing).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbAlarmType;
        private Label label2;
        private Label label3;
        private Button btnOutputExcel;
        private Button btnTimeSearch;
        private DataGridView dgAlarmTracing;
        private DataGridViewTextBoxColumn AlarmTime;
        private DataGridViewTextBoxColumn AlarmType;
        private DataGridViewTextBoxColumn AlarmContent;
        private DataGridViewTextBoxColumn UserName;
        private DataGridViewTextBoxColumn VaribleName;
        private DataGridViewTextBoxColumn Id;
        private Sunny.UI.UIDatetimePicker dtStartTime;
        private Sunny.UI.UIDatetimePicker dtEndTime;
    }
}
