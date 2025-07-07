namespace MTHCollection.Project.ChildForm
{
    partial class FrmRecipe
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
            Models.RecipeModel recipeModel1 = new Models.RecipeModel();
            Models.RecipeModel recipeModel2 = new Models.RecipeModel();
            Models.RecipeModel recipeModel3 = new Models.RecipeModel();
            Models.RecipeModel recipeModel4 = new Models.RecipeModel();
            Models.RecipeModel recipeModel5 = new Models.RecipeModel();
            Models.RecipeModel recipeModel6 = new Models.RecipeModel();
            dgRecipe = new DataGridView();
            RecipeIndex = new DataGridViewTextBoxColumn();
            RecipeName = new DataGridViewTextBoxColumn();
            label1 = new Label();
            tbCurrentRecipeName = new TextBox();
            label2 = new Label();
            tbRecipeName = new TextBox();
            btnAddRecipe = new Button();
            btnUpdateRecipe = new Button();
            btnDeleteRecipe = new Button();
            btnApplyRecipe = new Button();
            recipeControl1 = new Controls.RecipeControl();
            recipeControl2 = new Controls.RecipeControl();
            recipeControl3 = new Controls.RecipeControl();
            recipeControl4 = new Controls.RecipeControl();
            recipeControl5 = new Controls.RecipeControl();
            recipeControl6 = new Controls.RecipeControl();
            ((System.ComponentModel.ISupportInitialize)dgRecipe).BeginInit();
            SuspendLayout();
            // 
            // dgRecipe
            // 
            dgRecipe.AllowUserToAddRows = false;
            dgRecipe.AllowUserToDeleteRows = false;
            dgRecipe.AllowUserToResizeColumns = false;
            dgRecipe.AllowUserToResizeRows = false;
            dgRecipe.BackgroundColor = Color.FromArgb(4, 21, 65);
            dgRecipe.BorderStyle = BorderStyle.Fixed3D;
            dgRecipe.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(4, 21, 65);
            dataGridViewCellStyle1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgRecipe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgRecipe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgRecipe.Columns.AddRange(new DataGridViewColumn[] { RecipeIndex, RecipeName });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(4, 21, 65);
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = Color.Cyan;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgRecipe.DefaultCellStyle = dataGridViewCellStyle2;
            dgRecipe.EnableHeadersVisualStyles = false;
            dgRecipe.GridColor = Color.White;
            dgRecipe.Location = new Point(8, 11);
            dgRecipe.MultiSelect = false;
            dgRecipe.Name = "dgRecipe";
            dgRecipe.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(4, 21, 65);
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgRecipe.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgRecipe.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = Color.Transparent;
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(128, 128, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.Cyan;
            dgRecipe.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgRecipe.RowTemplate.Height = 25;
            dgRecipe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgRecipe.Size = new Size(268, 403);
            dgRecipe.TabIndex = 14;
            dgRecipe.CellClick += dgRecipe_CellClick;
            dgRecipe.CellFormatting += dgRecipe_CellFormatting;
            // 
            // RecipeIndex
            // 
            RecipeIndex.DataPropertyName = "RecipeIndex";
            RecipeIndex.HeaderText = "序号";
            RecipeIndex.Name = "RecipeIndex";
            RecipeIndex.Width = 80;
            // 
            // RecipeName
            // 
            RecipeName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RecipeName.DataPropertyName = "RecipeName";
            RecipeName.HeaderText = "配方名称";
            RecipeName.Name = "RecipeName";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(11, 448);
            label1.Name = "label1";
            label1.Size = new Size(90, 21);
            label1.TabIndex = 15;
            label1.Text = "当前配方：";
            // 
            // tbCurrentRecipeName
            // 
            tbCurrentRecipeName.Enabled = false;
            tbCurrentRecipeName.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbCurrentRecipeName.Location = new Point(107, 445);
            tbCurrentRecipeName.Name = "tbCurrentRecipeName";
            tbCurrentRecipeName.Size = new Size(158, 29);
            tbCurrentRecipeName.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(11, 508);
            label2.Name = "label2";
            label2.Size = new Size(90, 21);
            label2.TabIndex = 17;
            label2.Text = "配方名称：";
            // 
            // tbRecipeName
            // 
            tbRecipeName.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbRecipeName.Location = new Point(107, 505);
            tbRecipeName.Name = "tbRecipeName";
            tbRecipeName.Size = new Size(158, 29);
            tbRecipeName.TabIndex = 18;
            // 
            // btnAddRecipe
            // 
            btnAddRecipe.FlatStyle = FlatStyle.Flat;
            btnAddRecipe.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddRecipe.ForeColor = Color.White;
            btnAddRecipe.Location = new Point(14, 556);
            btnAddRecipe.Name = "btnAddRecipe";
            btnAddRecipe.Size = new Size(96, 35);
            btnAddRecipe.TabIndex = 19;
            btnAddRecipe.Text = "添加配方";
            btnAddRecipe.UseVisualStyleBackColor = true;
            btnAddRecipe.Click += btnAddRecipe_Click;
            // 
            // btnUpdateRecipe
            // 
            btnUpdateRecipe.FlatStyle = FlatStyle.Flat;
            btnUpdateRecipe.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdateRecipe.ForeColor = Color.White;
            btnUpdateRecipe.Location = new Point(153, 556);
            btnUpdateRecipe.Name = "btnUpdateRecipe";
            btnUpdateRecipe.Size = new Size(96, 35);
            btnUpdateRecipe.TabIndex = 20;
            btnUpdateRecipe.Text = "修改配方";
            btnUpdateRecipe.UseVisualStyleBackColor = true;
            btnUpdateRecipe.Click += btnUpdateRecipe_Click;
            // 
            // btnDeleteRecipe
            // 
            btnDeleteRecipe.FlatStyle = FlatStyle.Flat;
            btnDeleteRecipe.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteRecipe.ForeColor = Color.White;
            btnDeleteRecipe.Location = new Point(14, 632);
            btnDeleteRecipe.Name = "btnDeleteRecipe";
            btnDeleteRecipe.Size = new Size(96, 35);
            btnDeleteRecipe.TabIndex = 21;
            btnDeleteRecipe.Text = "删除配方";
            btnDeleteRecipe.UseVisualStyleBackColor = true;
            btnDeleteRecipe.Click += btnDeleteRecipe_Click;
            // 
            // btnApplyRecipe
            // 
            btnApplyRecipe.FlatStyle = FlatStyle.Flat;
            btnApplyRecipe.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnApplyRecipe.ForeColor = Color.White;
            btnApplyRecipe.Location = new Point(153, 632);
            btnApplyRecipe.Name = "btnApplyRecipe";
            btnApplyRecipe.Size = new Size(96, 35);
            btnApplyRecipe.TabIndex = 22;
            btnApplyRecipe.Text = "应用配方";
            btnApplyRecipe.UseVisualStyleBackColor = true;
            btnApplyRecipe.Click += btnApplyRecipe_Click;
            // 
            // recipeControl1
            // 
            recipeControl1.BackColor = Color.Transparent;
            recipeModel1.HumidityHeght = 0F;
            recipeModel1.HumidityLow = 0F;
            recipeModel1.IsHumidityAlarmUse = false;
            recipeModel1.IsTemperatureAlarmUse = false;
            recipeModel1.TemperatureHeigh = 0F;
            recipeModel1.TemperatureLow = 0F;
            recipeControl1.BindingRecipe = recipeModel1;
            recipeControl1.ForeColor = Color.White;
            recipeControl1.HAlarmUseBindingVarName = "模块1湿度报警启用";
            recipeControl1.HuHeightBindingVarName = "模块1湿度高限";
            recipeControl1.HuLowBindingVarName = "模块1湿度低限";
            recipeControl1.Location = new Point(385, 23);
            recipeControl1.Margin = new Padding(4, 3, 4, 3);
            recipeControl1.Name = "recipeControl1";
            recipeControl1.Size = new Size(328, 338);
            recipeControl1.StationTitle = "1#站点";
            recipeControl1.TabIndex = 23;
            recipeControl1.TAlarmUseBindingVarName = "模块1温度报警启用";
            recipeControl1.THeighBindingVarName = "模块1温度高限";
            recipeControl1.TLowBindingVarName = "模块1温度低限";
            // 
            // recipeControl2
            // 
            recipeControl2.BackColor = Color.Transparent;
            recipeModel2.HumidityHeght = 0F;
            recipeModel2.HumidityLow = 0F;
            recipeModel2.IsHumidityAlarmUse = false;
            recipeModel2.IsTemperatureAlarmUse = false;
            recipeModel2.TemperatureHeigh = 0F;
            recipeModel2.TemperatureLow = 0F;
            recipeControl2.BindingRecipe = recipeModel2;
            recipeControl2.ForeColor = Color.White;
            recipeControl2.HAlarmUseBindingVarName = "模块2湿度报警启用";
            recipeControl2.HuHeightBindingVarName = "模块2湿度高限";
            recipeControl2.HuLowBindingVarName = "模块2湿度低限";
            recipeControl2.Location = new Point(719, 23);
            recipeControl2.Margin = new Padding(4, 3, 4, 3);
            recipeControl2.Name = "recipeControl2";
            recipeControl2.Size = new Size(328, 338);
            recipeControl2.StationTitle = "2#站点";
            recipeControl2.TabIndex = 24;
            recipeControl2.TAlarmUseBindingVarName = "模块2温度报警启用";
            recipeControl2.THeighBindingVarName = "模块2温度高限";
            recipeControl2.TLowBindingVarName = "模块2温度低限";
            // 
            // recipeControl3
            // 
            recipeControl3.BackColor = Color.Transparent;
            recipeModel3.HumidityHeght = 0F;
            recipeModel3.HumidityLow = 0F;
            recipeModel3.IsHumidityAlarmUse = false;
            recipeModel3.IsTemperatureAlarmUse = false;
            recipeModel3.TemperatureHeigh = 0F;
            recipeModel3.TemperatureLow = 0F;
            recipeControl3.BindingRecipe = recipeModel3;
            recipeControl3.ForeColor = Color.White;
            recipeControl3.HAlarmUseBindingVarName = "模块3湿度报警启用";
            recipeControl3.HuHeightBindingVarName = "模块3湿度高限";
            recipeControl3.HuLowBindingVarName = "模块3湿度低限";
            recipeControl3.Location = new Point(1078, 23);
            recipeControl3.Margin = new Padding(4, 3, 4, 3);
            recipeControl3.Name = "recipeControl3";
            recipeControl3.Size = new Size(328, 338);
            recipeControl3.StationTitle = "3#站点";
            recipeControl3.TabIndex = 25;
            recipeControl3.TAlarmUseBindingVarName = "模块3温度报警启用";
            recipeControl3.THeighBindingVarName = "模块3温度高限";
            recipeControl3.TLowBindingVarName = "模块3温度低限";
            // 
            // recipeControl4
            // 
            recipeControl4.BackColor = Color.Transparent;
            recipeModel4.HumidityHeght = 0F;
            recipeModel4.HumidityLow = 0F;
            recipeModel4.IsHumidityAlarmUse = false;
            recipeModel4.IsTemperatureAlarmUse = false;
            recipeModel4.TemperatureHeigh = 0F;
            recipeModel4.TemperatureLow = 0F;
            recipeControl4.BindingRecipe = recipeModel4;
            recipeControl4.ForeColor = Color.White;
            recipeControl4.HAlarmUseBindingVarName = "模块4湿度报警启用";
            recipeControl4.HuHeightBindingVarName = "模块4湿度高限";
            recipeControl4.HuLowBindingVarName = "模块4湿度低限";
            recipeControl4.Location = new Point(385, 406);
            recipeControl4.Margin = new Padding(4, 3, 4, 3);
            recipeControl4.Name = "recipeControl4";
            recipeControl4.Size = new Size(328, 338);
            recipeControl4.StationTitle = "4#站点";
            recipeControl4.TabIndex = 26;
            recipeControl4.TAlarmUseBindingVarName = "模块4温度报警启用";
            recipeControl4.THeighBindingVarName = "模块4温度高限";
            recipeControl4.TLowBindingVarName = "模块4温度低限";
            // 
            // recipeControl5
            // 
            recipeControl5.BackColor = Color.Transparent;
            recipeModel5.HumidityHeght = 0F;
            recipeModel5.HumidityLow = 0F;
            recipeModel5.IsHumidityAlarmUse = false;
            recipeModel5.IsTemperatureAlarmUse = false;
            recipeModel5.TemperatureHeigh = 0F;
            recipeModel5.TemperatureLow = 0F;
            recipeControl5.BindingRecipe = recipeModel5;
            recipeControl5.ForeColor = Color.White;
            recipeControl5.HAlarmUseBindingVarName = "模块5湿度报警启用";
            recipeControl5.HuHeightBindingVarName = "模块5湿度高限";
            recipeControl5.HuLowBindingVarName = "模块5湿度低限";
            recipeControl5.Location = new Point(719, 406);
            recipeControl5.Margin = new Padding(4, 3, 4, 3);
            recipeControl5.Name = "recipeControl5";
            recipeControl5.Size = new Size(328, 338);
            recipeControl5.StationTitle = "5#站点";
            recipeControl5.TabIndex = 27;
            recipeControl5.TAlarmUseBindingVarName = "模块5温度报警启用";
            recipeControl5.THeighBindingVarName = "模块5温度高限";
            recipeControl5.TLowBindingVarName = "模块5温度低限";
            // 
            // recipeControl6
            // 
            recipeControl6.BackColor = Color.Transparent;
            recipeModel6.HumidityHeght = 0F;
            recipeModel6.HumidityLow = 0F;
            recipeModel6.IsHumidityAlarmUse = false;
            recipeModel6.IsTemperatureAlarmUse = false;
            recipeModel6.TemperatureHeigh = 0F;
            recipeModel6.TemperatureLow = 0F;
            recipeControl6.BindingRecipe = recipeModel6;
            recipeControl6.ForeColor = Color.White;
            recipeControl6.HAlarmUseBindingVarName = "模块6湿度报警启用";
            recipeControl6.HuHeightBindingVarName = "模块6湿度高限";
            recipeControl6.HuLowBindingVarName = "模块6湿度低限";
            recipeControl6.Location = new Point(1078, 406);
            recipeControl6.Margin = new Padding(4, 3, 4, 3);
            recipeControl6.Name = "recipeControl6";
            recipeControl6.Size = new Size(328, 338);
            recipeControl6.StationTitle = "6#站点";
            recipeControl6.TabIndex = 28;
            recipeControl6.TAlarmUseBindingVarName = "模块6温度报警启用";
            recipeControl6.THeighBindingVarName = "模块6温度高限";
            recipeControl6.TLowBindingVarName = "模块6温度低限";
            // 
            // FrmRecipe
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BackgroundImageLayout = ImageLayout.None;
            Controls.Add(recipeControl6);
            Controls.Add(recipeControl5);
            Controls.Add(recipeControl4);
            Controls.Add(recipeControl3);
            Controls.Add(recipeControl2);
            Controls.Add(recipeControl1);
            Controls.Add(btnApplyRecipe);
            Controls.Add(btnDeleteRecipe);
            Controls.Add(btnUpdateRecipe);
            Controls.Add(btnAddRecipe);
            Controls.Add(tbRecipeName);
            Controls.Add(label2);
            Controls.Add(tbCurrentRecipeName);
            Controls.Add(label1);
            Controls.Add(dgRecipe);
            DoubleBuffered = true;
            Name = "FrmRecipe";
            Size = new Size(1440, 960);
            Load += FrmRecipe_Load;
            ((System.ComponentModel.ISupportInitialize)dgRecipe).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgRecipe;
        private Label label1;
        private TextBox tbCurrentRecipeName;
        private Label label2;
        private TextBox tbRecipeName;
        private Button btnAddRecipe;
        private Button btnUpdateRecipe;
        private Button btnDeleteRecipe;
        private Button btnApplyRecipe;
        private Controls.RecipeControl recipeControl1;
        private Controls.RecipeControl recipeControl2;
        private Controls.RecipeControl recipeControl3;
        private Controls.RecipeControl recipeControl4;
        private Controls.RecipeControl recipeControl5;
        private Controls.RecipeControl recipeControl6;
        private DataGridViewTextBoxColumn RecipeIndex;
        private DataGridViewTextBoxColumn RecipeName;
    }
}
