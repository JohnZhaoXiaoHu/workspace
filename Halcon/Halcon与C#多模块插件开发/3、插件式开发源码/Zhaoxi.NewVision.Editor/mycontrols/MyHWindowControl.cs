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

namespace Zhaoxi.NewVision.Editor.mycontrols
{
    public partial class MyHWindowControl : HWindowControl
    {
        public MyHWindowControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示图像
        /// </summary>
        /// <param name="image"></param>
        public void DisplayImage(HObject image)
        {
            ImgIsNotStretchDisplay(image, HalconWindow);
        }

        /// <summary>
        /// 实现图像等比缩放显示
        /// </summary>
        /// <param name="L_Img"></param>
        /// <param name="Hwindow"></param>
        public void ImgIsNotStretchDisplay(HObject L_Img, HTuple Hwindow)
        {
            HOperatorSet.GetImageSize(L_Img, out var width, out var height);
            HOperatorSet.GetWindowExtents(Hwindow, out var _, out var _, out var width2, out var height2);
            HTuple hTuple = 1.0 * height2 / width2 * width;
            if (hTuple > height)
            {
                hTuple = 1.0 * (hTuple - height) / 2;
                HOperatorSet.SetPart(Hwindow, -hTuple, 0, hTuple + height, width);
            }
            else
            {
                HTuple hTuple2 = 1.0 * width2 / height2 * height;
                hTuple2 = 1.0 * (hTuple2 - width) / 2;
                HOperatorSet.SetPart(Hwindow, 0, -hTuple2, height, hTuple2 + width);
            }

            HOperatorSet.DispObj(L_Img, Hwindow);
        }
    }
}
