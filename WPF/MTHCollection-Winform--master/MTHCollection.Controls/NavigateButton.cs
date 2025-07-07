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
    [DefaultEvent("Click")]
    public partial class NavigateButton : UserControl
    {
        public NavigateButton()
        {
            InitializeComponent();
        }

        private bool isLeft=true;

        [Category("自定义属性")]
        [Description("是否为左按钮")]
        public bool IsLeft
        {
            get { return isLeft; }
            set
            {
                isLeft = value;
                ChangeButtonState();
            }
        }

        private bool isSelected;

        [Category("自定义属性")]
        [Description("是否选中")]
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                ChangeButtonState();
            }
        }

        private string buttonTitle = "导航按钮";

        [Category("自定义属性")]
        [Description("导航按钮显示的文本")]
        public string ButtonTitle
        {
            get { return buttonTitle; }
            set
            {
                buttonTitle = value;
                label1.Text = value;
            }
        }

        private void ChangeButtonState()
        {
            if (IsLeft)
            {
                this.BackgroundImage =
                    (isSelected == true)
                        ? Properties.Resources.LeftSelected
                        : Properties.Resources.LeftUnSelected;
            }
            else
            {
                this.BackgroundImage =
                    (isSelected == true)
                        ? Properties.Resources.RightSelected
                        : Properties.Resources.RightUnSelected;
            }
        }

      
        public EventHandler Click;

        private void label1_Click(object sender, EventArgs e)
        {
            this.Click?.Invoke(this, e);
        }
    }
}
