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
    public partial class THSetBaseControl : UserControl
    {
        public THSetBaseControl()
        {
            InitializeComponent();
        }

        private string title="1#站点温度高限";

        [Category("自定义属性")]
        [Description("标题")]
        public string Title
        {
            get { return title; }
            set 
            {
                title = value; 
                labTitle.Text = value;
            }
        }

        private float currentValue;

        [Category("自定义属性")]
        [Description("当前值")]
        public float CurrentValue
        {
            get { return currentValue; }
            set 
            { 
                currentValue = value;
                labValue.Text = currentValue.ToString();
            }
        }

        private string symbolString;
        [Category("自定义属性")]
        [Description("符号")]
        public string Symbol
        {
            get { return symbolString; }
            set
            {
                symbolString = value;
                labSymbol.Text = value;
            }
        }

        private string bindingVarName;

        /// <summary>
        /// 绑定变量名
        /// </summary>
        [Category("自定义绑定属性")]
        [Description("绑定的变量名称")]
        public string BindingVarName
        {
            get { return bindingVarName; }
            set { bindingVarName = value; }
        }


    }
}
