namespace MTHCollection.Controls
{
    partial class THSetControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(THSetControl));
            lightHuLow = new Sunny.UI.UILight();
            lightHuHeigh = new Sunny.UI.UILight();
            lightTLow = new Sunny.UI.UILight();
            lightTHeigh = new Sunny.UI.UILight();
            ckIsTemAlarmUse = new Sunny.UI.UICheckBox();
            ckIsHumidityAlarmUse = new Sunny.UI.UICheckBox();
            titleEx = new TitleEx();
            thSetBaseTH = new THSetBaseControl();
            thSetBaseTL = new THSetBaseControl();
            thSetBaseHuH = new THSetBaseControl();
            thSetBaseHuL = new THSetBaseControl();
            SuspendLayout();
            // 
            // lightHuLow
            // 
            lightHuLow.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lightHuLow.Location = new Point(282, 196);
            lightHuLow.MinimumSize = new Size(1, 1);
            lightHuLow.Name = "lightHuLow";
            lightHuLow.OffColor = Color.FromArgb(0, 192, 0);
            lightHuLow.OnColor = Color.Red;
            lightHuLow.Radius = 31;
            lightHuLow.Size = new Size(31, 35);
            lightHuLow.State = Sunny.UI.UILightState.Off;
            lightHuLow.TabIndex = 42;
            lightHuLow.Text = "uiLight4";
            // 
            // lightHuHeigh
            // 
            lightHuHeigh.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lightHuHeigh.Location = new Point(282, 155);
            lightHuHeigh.MinimumSize = new Size(1, 1);
            lightHuHeigh.Name = "lightHuHeigh";
            lightHuHeigh.OffColor = Color.FromArgb(0, 192, 0);
            lightHuHeigh.OnColor = Color.Red;
            lightHuHeigh.Radius = 31;
            lightHuHeigh.Size = new Size(31, 35);
            lightHuHeigh.State = Sunny.UI.UILightState.Off;
            lightHuHeigh.TabIndex = 38;
            lightHuHeigh.Text = "uiLight3";
            // 
            // lightTLow
            // 
            lightTLow.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lightTLow.Location = new Point(282, 111);
            lightTLow.MinimumSize = new Size(1, 1);
            lightTLow.Name = "lightTLow";
            lightTLow.OffColor = Color.FromArgb(0, 192, 0);
            lightTLow.OnColor = Color.Red;
            lightTLow.Radius = 31;
            lightTLow.Size = new Size(31, 35);
            lightTLow.State = Sunny.UI.UILightState.Off;
            lightTLow.TabIndex = 34;
            lightTLow.Text = "uiLight2";
            // 
            // lightTHeigh
            // 
            lightTHeigh.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lightTHeigh.Location = new Point(282, 63);
            lightTHeigh.MinimumSize = new Size(1, 1);
            lightTHeigh.Name = "lightTHeigh";
            lightTHeigh.OffColor = Color.FromArgb(0, 192, 0);
            lightTHeigh.OnColor = Color.Red;
            lightTHeigh.Radius = 31;
            lightTHeigh.Size = new Size(31, 35);
            lightTHeigh.State = Sunny.UI.UILightState.Off;
            lightTHeigh.TabIndex = 30;
            lightTHeigh.Text = "uiLight1";
            // 
            // ckIsTemAlarmUse
            // 
            ckIsTemAlarmUse.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckIsTemAlarmUse.ForeColor = Color.White;
            ckIsTemAlarmUse.Location = new Point(8, 250);
            ckIsTemAlarmUse.MinimumSize = new Size(1, 1);
            ckIsTemAlarmUse.Name = "ckIsTemAlarmUse";
            ckIsTemAlarmUse.Size = new Size(150, 29);
            ckIsTemAlarmUse.TabIndex = 47;
            ckIsTemAlarmUse.Text = "温度报警启用";
            ckIsTemAlarmUse.CheckedChanged += ck_CheckedChanged;
            // 
            // ckIsHumidityAlarmUse
            // 
            ckIsHumidityAlarmUse.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckIsHumidityAlarmUse.ForeColor = Color.White;
            ckIsHumidityAlarmUse.Location = new Point(172, 250);
            ckIsHumidityAlarmUse.MinimumSize = new Size(1, 1);
            ckIsHumidityAlarmUse.Name = "ckIsHumidityAlarmUse";
            ckIsHumidityAlarmUse.Size = new Size(150, 29);
            ckIsHumidityAlarmUse.TabIndex = 48;
            ckIsHumidityAlarmUse.Text = "湿度报警启用";
            ckIsHumidityAlarmUse.CheckedChanged += ck_CheckedChanged;
            // 
            // titleEx
            // 
            titleEx.BackColor = Color.Transparent;
            titleEx.BackgroundImage = (Image)resources.GetObject("titleEx.BackgroundImage");
            titleEx.BackgroundImageLayout = ImageLayout.Stretch;
            titleEx.Location = new Point(11, 31);
            titleEx.Name = "titleEx";
            titleEx.Size = new Size(121, 31);
            titleEx.TabIndex = 49;
            titleEx.Title = "1#站点";
            // 
            // thSetBaseTH
            // 
            thSetBaseTH.BackColor = Color.Transparent;
            thSetBaseTH.BindingVarName = null;
            thSetBaseTH.CurrentValue = 0F;
            thSetBaseTH.Cursor = Cursors.Hand;
            thSetBaseTH.Location = new Point(12, 68);
            thSetBaseTH.Name = "thSetBaseTH";
            thSetBaseTH.Size = new Size(264, 29);
            thSetBaseTH.Symbol = "℃";
            thSetBaseTH.TabIndex = 50;
            thSetBaseTH.Title = "1#站点温度高限";
            thSetBaseTH.MouseDoubleClick += thSetBaseTH_MouseDoubleClick;
            // 
            // thSetBaseTL
            // 
            thSetBaseTL.BackColor = Color.Transparent;
            thSetBaseTL.BindingVarName = null;
            thSetBaseTL.CurrentValue = 0F;
            thSetBaseTL.Cursor = Cursors.Hand;
            thSetBaseTL.Location = new Point(12, 111);
            thSetBaseTL.Name = "thSetBaseTL";
            thSetBaseTL.Size = new Size(264, 29);
            thSetBaseTL.Symbol = "℃";
            thSetBaseTL.TabIndex = 51;
            thSetBaseTL.Title = "1#站点温度低限";
            thSetBaseTL.MouseDoubleClick += thSetBaseTL_MouseDoubleClick;
            // 
            // thSetBaseHuH
            // 
            thSetBaseHuH.BackColor = Color.Transparent;
            thSetBaseHuH.BindingVarName = null;
            thSetBaseHuH.CurrentValue = 0F;
            thSetBaseHuH.Cursor = Cursors.Hand;
            thSetBaseHuH.Location = new Point(11, 157);
            thSetBaseHuH.Name = "thSetBaseHuH";
            thSetBaseHuH.Size = new Size(264, 29);
            thSetBaseHuH.Symbol = "%";
            thSetBaseHuH.TabIndex = 52;
            thSetBaseHuH.Title = "1#站点湿度高限";
            thSetBaseHuH.MouseDoubleClick += thSetBaseHuH_MouseDoubleClick;
            // 
            // thSetBaseHuL
            // 
            thSetBaseHuL.BackColor = Color.Transparent;
            thSetBaseHuL.BindingVarName = null;
            thSetBaseHuL.CurrentValue = 0F;
            thSetBaseHuL.Cursor = Cursors.Hand;
            thSetBaseHuL.Location = new Point(12, 201);
            thSetBaseHuL.Name = "thSetBaseHuL";
            thSetBaseHuL.Size = new Size(264, 29);
            thSetBaseHuL.Symbol = "%";
            thSetBaseHuL.TabIndex = 53;
            thSetBaseHuL.Title = "1#站点湿度低限";
            thSetBaseHuL.MouseDoubleClick += thSetBaseHuL_MouseDoubleClick;
            // 
            // THSetControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(thSetBaseHuL);
            Controls.Add(thSetBaseHuH);
            Controls.Add(thSetBaseTL);
            Controls.Add(thSetBaseTH);
            Controls.Add(titleEx);
            Controls.Add(ckIsHumidityAlarmUse);
            Controls.Add(ckIsTemAlarmUse);
            Controls.Add(lightHuLow);
            Controls.Add(lightHuHeigh);
            Controls.Add(lightTLow);
            Controls.Add(lightTHeigh);
            Name = "THSetControl";
            Size = new Size(322, 294);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILight lightHuLow;
        private Sunny.UI.UILight lightHuHeigh;
        private Sunny.UI.UILight lightTLow;
        private Sunny.UI.UILight lightTHeigh;
       
        private Sunny.UI.UICheckBox ckIsTemAlarmUse;
        private Sunny.UI.UICheckBox ckIsHumidityAlarmUse;
        private TitleEx titleEx;
        private THSetBaseControl thSetBaseTH;
        private THSetBaseControl thSetBaseTL;
        private THSetBaseControl thSetBaseHuH;
        private THSetBaseControl thSetBaseHuL;
    }
}
