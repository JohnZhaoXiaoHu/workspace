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
    public partial class THMonitorControl : UserControl
    {
        public THMonitorControl()
        {
            InitializeComponent();
        }

       
        private string stationName="1号站点";

        [Category("自定义属性")]
        [Description("站点标题名称")]
        public string StationName
        {
            get { return stationName; }
            set 
            { 
                stationName = value;
                labStationName.Text= stationName;
            }
        }


        private float teamperature = 0.0f;
        [Category("自定义属性")]
        [Description("温度值")]
        public float Teamperature
        {
            get { return teamperature; }
            set 
            {
                teamperature = value;
                meterT.Value = teamperature * 10;
                labT.Text= teamperature.ToString();
            }
        }

        private float humidity = 0.0f;

        [Category("自定义属性")]
        [Description("湿度值")]
        public float Humidity
        {
            get { return humidity; }
            set 
            {
                humidity = value; 
                meterH.Value = humidity * 10;
                labH.Text = humidity.ToString();
            }
        }

    }
}
