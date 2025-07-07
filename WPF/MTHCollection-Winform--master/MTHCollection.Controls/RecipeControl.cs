using MTHCollection.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTHCollection.Controls
{
    public partial class RecipeControl : UserControl
    {
        public RecipeControl()
        {
            InitializeComponent();
        }


        #region 自定义属性
        private string stationTitle;

        [Category("自定义属性")]
        [Description("工站名称标题")]
        public string StationTitle
        {
            get { return stationTitle; }
            set 
            {
                stationTitle = value;
                titleEx.Title= stationTitle;
                labTemHeigh.Text= stationTitle+"温度高限";
                labTemLow.Text = stationTitle + "温度低限";
                labHumidityHeigh.Text = stationTitle + "湿度高限";
                labHumidityLow.Text = stationTitle + "湿度低限";
                
            }
        }

        private RecipeModel bindingRecipe;

        /// <summary>
        /// 绑定的配方实体
        /// </summary>
        [Browsable(false)]
        public RecipeModel BindingRecipe
        {
            get
            {
                bindingRecipe = new RecipeModel();
                bindingRecipe.TemperatureHeigh=(float)ndTemHeigh.Value;
                bindingRecipe.TemperatureLow = (float)ndTemLow.Value;
                bindingRecipe.HumidityHeght = (float)ndHumidityHeigh.Value;
                bindingRecipe.HumidityLow = (float)ndHumidityLow.Value;
                bindingRecipe.IsTemperatureAlarmUse = ckTemAlarmUse.Checked;
                bindingRecipe.IsHumidityAlarmUse = ckHumidityAlarmUse.Checked;
                return bindingRecipe; 
            }
            set 
            {
                bindingRecipe = value;
                if (bindingRecipe != null)
                {
                    ndTemHeigh.Value=(decimal)bindingRecipe.TemperatureHeigh;
                    ndTemLow.Value = (decimal)bindingRecipe.TemperatureLow;
                    ndHumidityHeigh.Value = (decimal)bindingRecipe.HumidityHeght;
                    ndHumidityLow.Value = (decimal)bindingRecipe.HumidityLow;
                    ckTemAlarmUse.Checked = bindingRecipe.IsTemperatureAlarmUse;
                    ckHumidityAlarmUse.Checked= bindingRecipe.IsHumidityAlarmUse;
                }
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
            }
        }


        #endregion
    }
}
