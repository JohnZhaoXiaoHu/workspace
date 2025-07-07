using MTHCollection.Controls;
using MTHCollection.Models;
using MTHCollection.Project.Dialog;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaribleConfig.Common;
using VaribleConfig.DAL.Helper;

namespace MTHCollection.Project.ChildForm
{
    public partial class FrmParamSet : UserControl
    {
        public FrmParamSet()
        {
            InitializeComponent();
        }

        private void FrmParamSet_Load(object sender, EventArgs e)
        {

            tbIP.Text = CommonParam.CurrentDevice.IP;
            tbPort.Text = CommonParam.CurrentDevice.Port.ToString();

            foreach (var control in this.Controls)
            {
                if (control is THSetControl)
                {
                    ((THSetControl)control).DoubleClickEvent += THSet_DoubleClick;
                    ((THSetControl)control).AlarmCheckedChanged += AlarmCheckChanged_Click;
                    ((THSetControl)control).AlarmStateChanged += AlarmStateChanged_Click;
                }
            }

            GetAllAlarmUseValue();

            timer1.Interval = 1000;
            timer1.Start();

        }

        #region 确定设置按钮事件
        private void btnSureSetting_Click(object sender, EventArgs e)
        {
            if (!DataValidationHelper.IsIPAddress(tbIP.Text.Trim()))
            {
                MessageBox.Show("请输入有效的IP地址", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DataValidationHelper.IsPort(tbPort.Text.Trim()))
            {
                MessageBox.Show("请输入有效的端口号", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CommonParam.CurrentDevice.IP = tbIP.Text;
            CommonParam.CurrentDevice.Port = int.Parse(tbPort.Text);
            new JsonFileHelper().SerializeAndSave(CommonParam.CurrentDevice, "Device.json");
            MessageBox.Show("保存通信配置成功!");
        }
        #endregion

        #region 取消设置按钮事件
        private void btnCancelSetting_Click(object sender, EventArgs e)
        {
            tbIP.Text = string.Empty;
            tbPort.Text = string.Empty;
        }
        #endregion

        #region 通信组配置按钮事件
        private void btnGroupConfig_Click(object sender, EventArgs e)
        {
            FrmGroupConfig frmGroupConfig = new FrmGroupConfig();
            frmGroupConfig.ShowDialog();
        }
        #endregion


        #region 变量配置按钮事件
        private void btnVaribleConfig_Click(object sender, EventArgs e)
        {
            FrmVaribleConfig frmVaribleConfig = new FrmVaribleConfig();
            frmVaribleConfig.ShowDialog();
        }
        #endregion


        #region 高低限参数设置修改
        private void THSet_DoubleClick(object sender, EventArgs e)
        {
            THSetBaseControl tHSetBaseControl=sender as THSetBaseControl;
            FrmUpdateParam frmUpdateParam = new FrmUpdateParam();
            frmUpdateParam.Tag= tHSetBaseControl;
            frmUpdateParam.ShowDialog();

        }
        #endregion

        #region 报警参数设置修改
        private void AlarmCheckChanged_Click(object sender, EventArgs e)
        {
            UICheckBox checkBox=sender as UICheckBox;
            if(checkBox !=null)
            {
               string varibleName= checkBox.Tag.ToString();
               short value= checkBox.Checked ? (short)1 : (short)0;
               if(!string.IsNullOrWhiteSpace(varibleName))
                {
                    CommonParam.WriteData(varibleName, value);
                }
            }
        }

        #endregion

        #region  报警状态改变事件
        private void AlarmStateChanged_Click(object sender, EventArgs e)
        {
            UILight uILight = sender as UILight;
            if (uILight != null)
            {
                string varibleName = uILight.Tag.ToString();
                short value = uILight.State== UILightState.On ? (short)0 : (short)1;
                CommonParam.WriteData(varibleName, value);
            }
        }

        #endregion


        #region  从设备中读取限位值和报警相关值

        /// <summary>
        /// 获取所有高低限变量值
        /// </summary>
        private void GetAllLimitValue()
        {
            foreach(var control in this.Controls)
            {
                if(control is THSetControl tHSet)
                {
                    tHSet.TempratureHigh = (float)CommonParam.CurrentDevice[tHSet.THeighBindingVarName];
                    tHSet.TempratureLow = (float)CommonParam.CurrentDevice[tHSet.TLowBindingVarName];
                    tHSet.IsTHeightAlarm = (float)CommonParam.CurrentDevice[tHSet.CurrentTemBidingVarName] > tHSet.TempratureHigh;
                    tHSet.IsTLowAlarm = (float)CommonParam.CurrentDevice[tHSet.CurrentTemBidingVarName] < tHSet.TempratureLow ;
                    tHSet.HumidityHigh = (float)CommonParam.CurrentDevice[tHSet.HuHeightBindingVarName];
                    tHSet.HumidityLow = (float)CommonParam.CurrentDevice[tHSet.HuLowBindingVarName];
                    tHSet.IsHuHeightAlarm = (float)CommonParam.CurrentDevice[tHSet.CurrentHuBidingVarName] > tHSet.HumidityHigh ;
                    tHSet.IsHuLowAlarm = (float)CommonParam.CurrentDevice[tHSet.CurrentHuBidingVarName] < tHSet.HumidityLow ;
                }
            }
        }

        /// <summary>
        /// 获取所有报警使用变量值
        /// </summary>
        private void GetAllAlarmUseValue()
        {
            foreach(var control in this.Controls)
            {
                if (control is THSetControl tHSet)
                {
                    if(CommonParam.CurrentDevice.IsConnected)
                    {
                        tHSet.IsTemAlarmUse = ((float)CommonParam.CurrentDevice[tHSet.TAlarmUseBindingVarName] > 0);
                        tHSet.IsHumidityAlarmUse = ((float)CommonParam.CurrentDevice[tHSet.HAlarmUseBindingVarName] > 0);
                    }
                }
            }
        }

        /// <summary>
        /// 定时器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(CommonParam.CurrentDevice.IsConnected)
            {
                
                GetAllLimitValue();
                
            }
        }
        #endregion

       
    }
}
