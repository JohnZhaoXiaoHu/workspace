using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragVision.Controls
{
    [DefaultEvent("Click")]
    public partial class OperateButton : UserControl
    {
        public OperateButton()
        {
            InitializeComponent();
            pictureBox1.Click += (s, e) =>
            {
                Click?.Invoke(this, e);
            };
            labButtonName.Click += (s, e) =>
            {
                Click?.Invoke(this, e);
            };
        }

        #region 自定义属性
        private string buttonName;


        /// <summary>
        /// 按钮名称
        /// </summary>
        [Category("自定义属性")]
        [Description("按钮名称")]
        public string ButtonName
        {
            get { return buttonName; }
            set 
            { 
                buttonName = value; 
                labButtonName.Text= buttonName;
            }
        }

        private Image buttonImage;

        /// <summary>
        /// 按钮图片
        /// </summary>
        [Category("自定义属性")]
        [Description("按钮图片")]
        public Image ButtonImage
        {
            get { return buttonImage; }
            set
            {
                buttonImage = value;
                pictureBox1.Image= buttonImage;
              
                
            }
        }



        #endregion

        #region 自定义事件
        /// <summary>
        /// 点击事件
        /// </summary>
        [Category("自定义事件")]
        [Description("点击事件")]
        public EventHandler Click { get; set; }
        #endregion
    }
}
