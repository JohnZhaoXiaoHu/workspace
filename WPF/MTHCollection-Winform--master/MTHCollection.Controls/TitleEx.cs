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
    public partial class TitleEx : UserControl
    {
        public TitleEx()
        {
            InitializeComponent();
        }

        private string title="子标题栏";

        [Category("自定义属性")]
        [Description("标题文字")]
        public string Title
        {
            get { return title; }
            set 
            { 
                title= value;
                label1.Text = title;
            }
        }

    }
}
