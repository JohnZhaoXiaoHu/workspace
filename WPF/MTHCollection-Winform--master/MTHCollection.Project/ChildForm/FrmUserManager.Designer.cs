namespace MTHCollection.Project.ChildForm
{
    partial class FrmUserManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserManager));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            titleEx1 = new Controls.TitleEx();
            label1 = new Label();
            tbUserName = new TextBox();
            tbPassword = new TextBox();
            label2 = new Label();
            tbConfirmPassword = new TextBox();
            label3 = new Label();
            titleEx2 = new Controls.TitleEx();
            ckParamSet = new Sunny.UI.UICheckBox();
            ckRecipe = new Sunny.UI.UICheckBox();
            ckAlarmTracing = new Sunny.UI.UICheckBox();
            ckHistoryTend = new Sunny.UI.UICheckBox();
            ckUserManager = new Sunny.UI.UICheckBox();
            btnSelectAllOrNot = new Button();
            titleEx3 = new Controls.TitleEx();
            btnAddUser = new Button();
            btnUpdateUser = new Button();
            btnDeleteUser = new Button();
            btnClearMessage = new Button();
            dgUserManager = new DataGridView();
            UserName = new DataGridViewTextBoxColumn();
            Password = new DataGridViewTextBoxColumn();
            ParamSetPermission = new DataGridViewTextBoxColumn();
            RecipePermission = new DataGridViewTextBoxColumn();
            AlarmTracingPermission = new DataGridViewTextBoxColumn();
            HistoryTendPermission = new DataGridViewTextBoxColumn();
            UserManagerPermission = new DataGridViewTextBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgUserManager).BeginInit();
            SuspendLayout();
            // 
            // titleEx1
            // 
            titleEx1.BackColor = Color.Transparent;
            titleEx1.BackgroundImage = (Image)resources.GetObject("titleEx1.BackgroundImage");
            titleEx1.BackgroundImageLayout = ImageLayout.Stretch;
            titleEx1.Location = new Point(15, 16);
            titleEx1.Name = "titleEx1";
            titleEx1.Size = new Size(97, 33);
            titleEx1.TabIndex = 0;
            titleEx1.Title = "用户信息";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(35, 78);
            label1.Name = "label1";
            label1.Size = new Size(90, 21);
            label1.TabIndex = 16;
            label1.Text = "用户名称：";
            // 
            // tbUserName
            // 
            tbUserName.BackColor = Color.FromArgb(0, 29, 85);
            tbUserName.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbUserName.ForeColor = Color.White;
            tbUserName.Location = new Point(114, 75);
            tbUserName.Name = "tbUserName";
            tbUserName.Size = new Size(168, 29);
            tbUserName.TabIndex = 17;
            // 
            // tbPassword
            // 
            tbPassword.BackColor = Color.FromArgb(0, 29, 85);
            tbPassword.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbPassword.ForeColor = Color.White;
            tbPassword.Location = new Point(114, 123);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(168, 29);
            tbPassword.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(35, 126);
            label2.Name = "label2";
            label2.Size = new Size(90, 21);
            label2.TabIndex = 18;
            label2.Text = "用户密码：";
            // 
            // tbConfirmPassword
            // 
            tbConfirmPassword.BackColor = Color.FromArgb(0, 29, 85);
            tbConfirmPassword.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbConfirmPassword.ForeColor = Color.White;
            tbConfirmPassword.Location = new Point(114, 174);
            tbConfirmPassword.Name = "tbConfirmPassword";
            tbConfirmPassword.Size = new Size(168, 29);
            tbConfirmPassword.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(35, 177);
            label3.Name = "label3";
            label3.Size = new Size(90, 21);
            label3.TabIndex = 20;
            label3.Text = "确认密码：";
            // 
            // titleEx2
            // 
            titleEx2.BackColor = Color.Transparent;
            titleEx2.BackgroundImage = (Image)resources.GetObject("titleEx2.BackgroundImage");
            titleEx2.BackgroundImageLayout = ImageLayout.Stretch;
            titleEx2.Location = new Point(15, 252);
            titleEx2.Name = "titleEx2";
            titleEx2.Size = new Size(97, 33);
            titleEx2.TabIndex = 22;
            titleEx2.Title = "权限配置";
            // 
            // ckParamSet
            // 
            ckParamSet.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckParamSet.ForeColor = Color.White;
            ckParamSet.Location = new Point(35, 303);
            ckParamSet.MinimumSize = new Size(1, 1);
            ckParamSet.Name = "ckParamSet";
            ckParamSet.Size = new Size(150, 29);
            ckParamSet.TabIndex = 23;
            ckParamSet.Text = "参数设置";
            // 
            // ckRecipe
            // 
            ckRecipe.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckRecipe.ForeColor = Color.White;
            ckRecipe.Location = new Point(212, 303);
            ckRecipe.MinimumSize = new Size(1, 1);
            ckRecipe.Name = "ckRecipe";
            ckRecipe.Size = new Size(150, 29);
            ckRecipe.TabIndex = 24;
            ckRecipe.Text = "配方管理";
            // 
            // ckAlarmTracing
            // 
            ckAlarmTracing.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckAlarmTracing.ForeColor = Color.White;
            ckAlarmTracing.Location = new Point(35, 367);
            ckAlarmTracing.MinimumSize = new Size(1, 1);
            ckAlarmTracing.Name = "ckAlarmTracing";
            ckAlarmTracing.Size = new Size(150, 29);
            ckAlarmTracing.TabIndex = 25;
            ckAlarmTracing.Text = "报警追溯";
            // 
            // ckHistoryTend
            // 
            ckHistoryTend.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckHistoryTend.ForeColor = Color.White;
            ckHistoryTend.Location = new Point(212, 367);
            ckHistoryTend.MinimumSize = new Size(1, 1);
            ckHistoryTend.Name = "ckHistoryTend";
            ckHistoryTend.Size = new Size(150, 29);
            ckHistoryTend.TabIndex = 26;
            ckHistoryTend.Text = "历史趋势";
            // 
            // ckUserManager
            // 
            ckUserManager.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckUserManager.ForeColor = Color.White;
            ckUserManager.Location = new Point(35, 441);
            ckUserManager.MinimumSize = new Size(1, 1);
            ckUserManager.Name = "ckUserManager";
            ckUserManager.Size = new Size(150, 29);
            ckUserManager.TabIndex = 27;
            ckUserManager.Text = "用户管理";
            // 
            // btnSelectAllOrNot
            // 
            btnSelectAllOrNot.FlatStyle = FlatStyle.Flat;
            btnSelectAllOrNot.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSelectAllOrNot.ForeColor = Color.White;
            btnSelectAllOrNot.Location = new Point(212, 435);
            btnSelectAllOrNot.Name = "btnSelectAllOrNot";
            btnSelectAllOrNot.Size = new Size(96, 35);
            btnSelectAllOrNot.TabIndex = 28;
            btnSelectAllOrNot.Text = "全选/不选";
            btnSelectAllOrNot.UseVisualStyleBackColor = true;
            btnSelectAllOrNot.Click += btnSelectAllOrNot_Click;
            // 
            // titleEx3
            // 
            titleEx3.BackColor = Color.Transparent;
            titleEx3.BackgroundImage = (Image)resources.GetObject("titleEx3.BackgroundImage");
            titleEx3.BackgroundImageLayout = ImageLayout.Stretch;
            titleEx3.Location = new Point(15, 529);
            titleEx3.Name = "titleEx3";
            titleEx3.Size = new Size(97, 33);
            titleEx3.TabIndex = 29;
            titleEx3.Title = "用户操作";
            // 
            // btnAddUser
            // 
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(35, 584);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(96, 35);
            btnAddUser.TabIndex = 30;
            btnAddUser.Text = "添加用户";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.FlatStyle = FlatStyle.Flat;
            btnUpdateUser.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdateUser.ForeColor = Color.White;
            btnUpdateUser.Location = new Point(212, 584);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(96, 35);
            btnUpdateUser.TabIndex = 31;
            btnUpdateUser.Text = "修改用户";
            btnUpdateUser.UseVisualStyleBackColor = true;
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.Location = new Point(35, 664);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(96, 35);
            btnDeleteUser.TabIndex = 32;
            btnDeleteUser.Text = "删除用户";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnClearMessage
            // 
            btnClearMessage.FlatStyle = FlatStyle.Flat;
            btnClearMessage.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnClearMessage.ForeColor = Color.White;
            btnClearMessage.Location = new Point(212, 664);
            btnClearMessage.Name = "btnClearMessage";
            btnClearMessage.Size = new Size(96, 35);
            btnClearMessage.TabIndex = 33;
            btnClearMessage.Text = "清空信息";
            btnClearMessage.UseVisualStyleBackColor = true;
            btnClearMessage.Click += btnClearMessage_Click;
            // 
            // dgUserManager
            // 
            dgUserManager.AllowUserToAddRows = false;
            dgUserManager.AllowUserToDeleteRows = false;
            dgUserManager.AllowUserToResizeColumns = false;
            dgUserManager.AllowUserToResizeRows = false;
            dgUserManager.BackgroundColor = Color.FromArgb(4, 21, 65);
            dgUserManager.BorderStyle = BorderStyle.Fixed3D;
            dgUserManager.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(4, 21, 65);
            dataGridViewCellStyle1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgUserManager.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgUserManager.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgUserManager.Columns.AddRange(new DataGridViewColumn[] { UserName, Password, ParamSetPermission, RecipePermission, AlarmTracingPermission, HistoryTendPermission, UserManagerPermission, Id });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(4, 21, 65);
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = Color.Cyan;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgUserManager.DefaultCellStyle = dataGridViewCellStyle2;
            dgUserManager.EnableHeadersVisualStyles = false;
            dgUserManager.GridColor = Color.White;
            dgUserManager.Location = new Point(386, 40);
            dgUserManager.MultiSelect = false;
            dgUserManager.Name = "dgUserManager";
            dgUserManager.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(4, 21, 65);
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgUserManager.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = Color.Transparent;
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(128, 128, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.Cyan;
            dgUserManager.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgUserManager.RowTemplate.Height = 25;
            dgUserManager.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgUserManager.Size = new Size(1023, 638);
            dgUserManager.TabIndex = 34;
            dgUserManager.CellFormatting += dgUserManager_CellFormatting;
            dgUserManager.RowPostPaint += dgUserManager_RowPostPaint;
            // 
            // UserName
            // 
            UserName.DataPropertyName = "UserName";
            UserName.HeaderText = "用户名";
            UserName.Name = "UserName";
            UserName.Width = 140;
            // 
            // Password
            // 
            Password.DataPropertyName = "Password";
            Password.HeaderText = "用户密码";
            Password.Name = "Password";
            Password.Width = 140;
            // 
            // ParamSetPermission
            // 
            ParamSetPermission.DataPropertyName = "ParamSetPermission";
            ParamSetPermission.HeaderText = "参数设置";
            ParamSetPermission.Name = "ParamSetPermission";
            ParamSetPermission.Width = 140;
            // 
            // RecipePermission
            // 
            RecipePermission.DataPropertyName = "RecipePermission";
            RecipePermission.HeaderText = "配方管理";
            RecipePermission.Name = "RecipePermission";
            RecipePermission.Width = 140;
            // 
            // AlarmTracingPermission
            // 
            AlarmTracingPermission.DataPropertyName = "AlarmTracingPermission";
            AlarmTracingPermission.HeaderText = "报警追溯";
            AlarmTracingPermission.Name = "AlarmTracingPermission";
            AlarmTracingPermission.Width = 140;
            // 
            // HistoryTendPermission
            // 
            HistoryTendPermission.DataPropertyName = "HistoryTendPermission";
            HistoryTendPermission.HeaderText = "历史趋势";
            HistoryTendPermission.Name = "HistoryTendPermission";
            HistoryTendPermission.Width = 140;
            // 
            // UserManagerPermission
            // 
            UserManagerPermission.DataPropertyName = "UserManagerPermission";
            UserManagerPermission.HeaderText = "用户管理";
            UserManagerPermission.Name = "UserManagerPermission";
            UserManagerPermission.Width = 140;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.Visible = false;
            // 
            // FrmUserManager
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(dgUserManager);
            Controls.Add(btnClearMessage);
            Controls.Add(btnDeleteUser);
            Controls.Add(btnUpdateUser);
            Controls.Add(btnAddUser);
            Controls.Add(titleEx3);
            Controls.Add(btnSelectAllOrNot);
            Controls.Add(ckUserManager);
            Controls.Add(ckHistoryTend);
            Controls.Add(ckAlarmTracing);
            Controls.Add(ckRecipe);
            Controls.Add(ckParamSet);
            Controls.Add(titleEx2);
            Controls.Add(tbConfirmPassword);
            Controls.Add(label3);
            Controls.Add(tbPassword);
            Controls.Add(label2);
            Controls.Add(tbUserName);
            Controls.Add(label1);
            Controls.Add(titleEx1);
            Name = "FrmUserManager";
            Size = new Size(1440, 960);
            Load += FrmUserManager_Load;
            ((System.ComponentModel.ISupportInitialize)dgUserManager).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.TitleEx titleEx1;
        private Label label1;
        private TextBox tbUserName;
        private TextBox tbPassword;
        private Label label2;
        private TextBox tbConfirmPassword;
        private Label label3;
        private Controls.TitleEx titleEx2;
        private Sunny.UI.UICheckBox ckParamSet;
        private Sunny.UI.UICheckBox ckRecipe;
        private Sunny.UI.UICheckBox ckAlarmTracing;
        private Sunny.UI.UICheckBox ckHistoryTend;
        private Sunny.UI.UICheckBox ckUserManager;
        private Button btnSelectAllOrNot;
        private Controls.TitleEx titleEx3;
        private Button btnAddUser;
        private Button btnUpdateUser;
        private Button btnDeleteUser;
        private Button btnClearMessage;
        private DataGridView dgUserManager;
        private DataGridViewTextBoxColumn UserName;
        private DataGridViewTextBoxColumn Password;
        private DataGridViewTextBoxColumn ParamSetPermission;
        private DataGridViewTextBoxColumn RecipePermission;
        private DataGridViewTextBoxColumn AlarmTracingPermission;
        private DataGridViewTextBoxColumn HistoryTendPermission;
        private DataGridViewTextBoxColumn UserManagerPermission;
        private DataGridViewTextBoxColumn Id;
    }
}
