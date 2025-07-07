using HalconDotNet;
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
    public partial class HalconDisplayControl : UserControl
    {
        public HalconDisplayControl()
        {
            InitializeComponent();
        }

        HSmartWindowControl hsmart= new HSmartWindowControl();
        private void HalconDisplayControl_Load(object sender, EventArgs e)
        {
            hsmart.Dock= DockStyle.Fill;
            panel1.Controls.Add(hsmart);
            hsmart.HalconWindow.SetPart(0, 0, -1, -1);
            MouseWheel += hSmartWindowControl1_MouseWheel;
        }

        /// <summary>
        /// 获取halcon的显示窗口
        /// </summary>
        /// <returns></returns>
        public HWindow GetHWindow()
        {
            
            return hsmart.HalconWindow;
        }

        /// <summary>
        /// halcon显示窗口缩放图像的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hSmartWindowControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                MouseEventArgs newe = new MouseEventArgs(e.Button, e.Clicks, e.X - Location.X, e.Y - Location.Y, e.Delta);
                if (hsmart.RectangleToScreen(hsmart.ClientRectangle).Contains(MousePosition))
                {

                    hsmart.HSmartWindowControl_MouseWheel(sender, newe);
                }
            }
            catch (Exception ex)
            {

            }
        }



    }
}
