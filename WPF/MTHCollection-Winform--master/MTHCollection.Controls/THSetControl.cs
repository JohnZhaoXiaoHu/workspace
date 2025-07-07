using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MTHCollection.Common;
using Sunny.UI;
using VaribleConfig.Common;

namespace MTHCollection.Controls
{
    [DefaultEvent("DoubleClickEvent")]
    public partial class THSetControl : UserControl
    {
        public THSetControl()
        {
            InitializeComponent();
        }

        #region 自定义属性
        private string stationName = "1#站点";

        [Category("自定义属性")]
        [Description("站点标题名称")]
        public string StationName
        {
            get { return stationName; }
            set
            {
                stationName = value;
                titleEx.Title = stationName;
                thSetBaseTH.Title = stationName + "温度高限";
                thSetBaseTL.Title = stationName + "温度低限";
                thSetBaseHuH.Title = stationName + "湿度高限";
                thSetBaseHuL.Title = stationName + "湿度低限";
            }
        }

        private float tempratureHigh = 35.0f;

        [Category("自定义属性")]
        [Description("温度高限值")]
        public float TempratureHigh
        {
            get { return tempratureHigh; }
            set
            {
                if (value >= 0)
                {
                    tempratureHigh = value;
                    thSetBaseTH.CurrentValue = tempratureHigh;
                }
                else
                {
                    throw new Exception("温度高限值必须大于等于0");
                }
            }
        }

        private float tempratureLow = 0.0f;

        [Category("自定义属性")]
        [Description("温度低限值")]
        public float TempratureLow
        {
            get { return tempratureLow; }
            set
            {
                if (value >= 0)
                {
                    tempratureLow = value;
                    thSetBaseTL.CurrentValue = tempratureLow;
                }
                else
                {
                    throw new Exception("温度低限值必须大于等于0");
                }
            }
        }

        private float humidityHigh = 45.0f;

        [Category("自定义属性")]
        [Description("湿度高限值")]
        public float HumidityHigh
        {
            get { return humidityHigh; }
            set
            {
                if (value >= 0)
                {
                    humidityHigh = value;
                    thSetBaseHuH.CurrentValue = humidityHigh;
                }
                else
                {
                    throw new Exception("湿度高限制必须大于等于0");
                }
            }
        }

        private float humidityLow = 0.0F;

        [Category("自定义属性")]
        [Description("湿度低限值")]
        public float HumidityLow
        {
            get { return humidityLow; }
            set
            {
                if (value >= 0)
                {
                    humidityLow = value;
                    thSetBaseHuL.CurrentValue = humidityLow;
                }
                else
                {
                    throw new Exception("温度低限值必须大于等于0");
                }
            }
        }

        private bool isTHeightAlarm;

        [Category("自定义属性")]
        [Description("温度高限报警")]
        public bool IsTHeightAlarm
        {
            get { return isTHeightAlarm; }
            set
            {
                if (value != isTHeightAlarm)
                {
                    AlarmStateChanged?.Invoke(lightTHeigh, new EventArgs());
                }
                isTHeightAlarm = value;
                lightTHeigh.State = isTHeightAlarm ? UILightState.On : UILightState.Off;
            }
        }

        private bool isTLowAlarm;

        [Category("自定义属性")]
        [Description("温度低限报警")]
        public bool IsTLowAlarm
        {
            get { return isTLowAlarm; }
            set
            {
                if (value != isTLowAlarm)
                {
                    AlarmStateChanged?.Invoke(lightTLow, new EventArgs());
                }
                isTLowAlarm = value;
                lightTLow.State = isTLowAlarm ? UILightState.On : UILightState.Off;
            }
        }

        private bool isHuHeightAlarm;

        [Category("自定义属性")]
        [Description("湿度高限报警")]
        public bool IsHuHeightAlarm
        {
            get { return isHuHeightAlarm; }
            set
            {
                if (value != isHuHeightAlarm)
                {
                    AlarmStateChanged?.Invoke(lightHuHeigh, new EventArgs());
                }
                isHuHeightAlarm = value;
                lightHuHeigh.State = isHuHeightAlarm ? UILightState.On : UILightState.Off;
            }
        }

        private bool isHuLowAlarm;

        [Category("自定义属性")]
        [Description("湿度低限报警")]
        public bool IsHuLowAlarm
        {
            get { return isHuLowAlarm; }
            set
            {
                if (value != isHuLowAlarm)
                {
                    AlarmStateChanged?.Invoke(lightHuLow, new EventArgs());
                }
                isHuLowAlarm = value;
                lightHuLow.State = isHuLowAlarm ? UILightState.On : UILightState.Off;
            }
        }

        private bool isTemAlarmUse;

        [Category("自定义属性")]
        [Description("是否启用温度报警")]
        public bool IsTemAlarmUse
        {
            get { return isTemAlarmUse; }
            set
            {
                isTemAlarmUse = value;
                ckIsTemAlarmUse.Checked = isTemAlarmUse;
            }
        }

        private bool isHumidityAlarmUse;

        [Category("自定义属性")]
        [Description("是否启用湿度报警")]
        public bool IsHumidityAlarmUse
        {
            get { return isHumidityAlarmUse; }
            set
            {
                isHumidityAlarmUse = value;
                ckIsHumidityAlarmUse.Checked = isHumidityAlarmUse;
            }
        }
        #endregion

        #region 自定义绑定属性
        private string tHeightBindingVarName;

        [Category("自定义绑定属性")]
        [Description("温度高限绑定变量名")]
        public string THeighBindingVarName
        {
            get { return tHeightBindingVarName; }
            set
            {
                tHeightBindingVarName = value;
                thSetBaseTH.BindingVarName = tHeightBindingVarName;
            }
        }

        private string tLowBindingVarName;

        [Category("自定义绑定属性")]
        [Description("温度低限绑定变量名")]
        public string TLowBindingVarName
        {
            get { return tLowBindingVarName; }
            set
            {
                tLowBindingVarName = value;
                thSetBaseTL.BindingVarName = tLowBindingVarName;
            }
        }

        private string huHeightBindingVarName;

        [Category("自定义绑定属性")]
        [Description("湿度高限绑定变量名")]
        public string HuHeightBindingVarName
        {
            get { return huHeightBindingVarName; }
            set
            {
                huHeightBindingVarName = value;
                thSetBaseHuH.BindingVarName = huHeightBindingVarName;
            }
        }

        private string huLowBindingVarName;

        [Category("自定义绑定属性")]
        [Description("湿度低限绑定变量名")]
        public string HuLowBindingVarName
        {
            get { return huLowBindingVarName; }
            set
            {
                huLowBindingVarName = value;
                thSetBaseHuL.BindingVarName = huLowBindingVarName;
            }
        }

        private string tAlarmUseBindingVarName;

        [Category("自定义绑定属性")]
        [Description("温度报警是否启用绑定变量名")]
        public string TAlarmUseBindingVarName
        {
            get { return tAlarmUseBindingVarName; }
            set
            {
                tAlarmUseBindingVarName = value;
                ckIsTemAlarmUse.Tag = tAlarmUseBindingVarName;
            }
        }

        private string hAlarmUseBindingVarName;

        [Category("自定义绑定属性")]
        [Description("湿度报警是否启用绑定变量名")]
        public string HAlarmUseBindingVarName
        {
            get { return hAlarmUseBindingVarName; }
            set
            {
                hAlarmUseBindingVarName = value;
                ckIsHumidityAlarmUse.Tag = hAlarmUseBindingVarName;
            }
        }

        private string currentTemBidingVarName;

        [Category("自定义绑定属性")]
        [Description("当前温度绑定变量名")]
        public string CurrentTemBidingVarName
        {
            get { return currentTemBidingVarName; }
            set { currentTemBidingVarName = value; }
        }

        private string currentHuBidingVarName;

        [Category("自定义绑定属性")]
        [Description("当前湿度绑定变量名")]
        public string CurrentHuBidingVarName
        {
            get { return currentHuBidingVarName; }
            set { currentHuBidingVarName = value; }
        }

        private string temHeightAlarmBidingVarName;

        [Category("自定义绑定属性")]
        [Description("温度高报警绑定变量名")]
        public string TemHeightAlarmBidingVarName
        {
            get { return temHeightAlarmBidingVarName; }
            set
            {
                temHeightAlarmBidingVarName = value;
                lightTHeigh.Tag = temHeightAlarmBidingVarName;
            }
        }

        private string temLowAlarmBidingVarName;

        [Category("自定义绑定属性")]
        [Description("温度低报警绑定变量名")]
        public string TemLowAlarmBidingVarName
        {
            get { return temLowAlarmBidingVarName; }
            set
            {
                temLowAlarmBidingVarName = value;
                lightTLow.Tag = temLowAlarmBidingVarName;
            }
        }

        private string huHeightAlarmBidingVarName;

        [Category("自定义绑定属性")]
        [Description("湿度高报警绑定变量名")]
        public string HuHeightAlarmBidingVarName
        {
            get { return huHeightAlarmBidingVarName; }
            set
            {
                huHeightAlarmBidingVarName = value;
                lightHuHeigh.Tag = huHeightAlarmBidingVarName;
            }
        }

        private string huLowAlarmBidingVarName;

        [Category("自定义绑定属性")]
        [Description("湿度低报警绑定变量名")]
        public string HuLowAlarmBidingVarName
        {
            get { return huLowAlarmBidingVarName; }
            set
            {
                huLowAlarmBidingVarName = value;
                lightHuLow.Tag = huLowAlarmBidingVarName;
            }
        }
        #endregion

        #region 自定义事件
        [Category("自定义事件")]
        [Description("子内容双击事件")]
        public EventHandler DoubleClickEvent;

        [Category("自定义事件")]
        [Description("报警勾选框状态改变事件")]
        public EventHandler AlarmCheckedChanged;

        [Category("自定义事件")]
        [Description("报警状态改变事件")]
        public EventHandler AlarmStateChanged;
        #endregion

        private void thSetBaseTH_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DoubleClickEvent?.Invoke(thSetBaseTH, e);
        }

        private void thSetBaseTL_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DoubleClickEvent?.Invoke(thSetBaseTL, e);
        }

        private void thSetBaseHuH_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DoubleClickEvent?.Invoke(thSetBaseHuH, e);
        }

        private void thSetBaseHuL_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DoubleClickEvent?.Invoke(thSetBaseHuL, e);
        }

        private void ck_CheckedChanged(object sender, EventArgs e)
        {
            UICheckBox uICheckBox = sender as UICheckBox;
            AlarmCheckedChanged?.Invoke(uICheckBox, e);
            if (uICheckBox.Tag.ToString().Equals(tAlarmUseBindingVarName))
            {
                IsTemAlarmUse = uICheckBox.Checked;
            }
            else if (uICheckBox.Tag.ToString().Equals(hAlarmUseBindingVarName))
            {
                IsHumidityAlarmUse = uICheckBox.Checked;
            }
        }
    }
}
