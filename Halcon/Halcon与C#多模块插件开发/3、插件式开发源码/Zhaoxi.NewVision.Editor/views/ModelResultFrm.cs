using HalconDotNet;
using System.Data;
using Zhaoxi.NewVision.Editor.mycontrols;

namespace Zhaoxi.Flow.Editor.Tools
{
    public partial class ModelResultFrm : Form
    {
        private FlowNode previousControl;
        private FlowNode flowControl;
        private HObject modelXld;
        private HTuple modelId;
        private bool isSingle;
        private HObject img;
        private HObject[] imgs;
        private int currentIndex = 0;

        public ModelResultFrm(FlowNode previousControl, FlowNode flowControl)
        {
            InitializeComponent();
            this.previousControl = previousControl;
            this.flowControl = flowControl;
            butt.Enabled = false;
            button6.Enabled = false;
        }
        /// <summary>
        /// 选择模板及轮廓
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "加载模板及轮廓";
            dialog.Filter = "模板及轮廓|*.shm;*.hobj";
            dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var urls = dialog.FileNames;
                var modelUrl = urls.Where(url => url.Contains(".shm")).FirstOrDefault();
                var xldUrl = urls.Where(url => url.Contains(".hobj")).FirstOrDefault();
                // 获取对应的模板ID和轮廓
                HOperatorSet.ReadShapeModel(modelUrl, out modelId);
                HOperatorSet.ReadObject(out modelXld, xldUrl);
            }
        }
        /// <summary>
        /// 加载单图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            imgs = null;
            isSingle = true;
            var dialog = new OpenFileDialog();
            dialog.Title = "待匹配图像";
            dialog.Filter = "匹配图像|*.png;*.jpg;*.bmp";
            dialog.InitialDirectory = @"C:\Users\Gerry\Desktop\源码\图片资源";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var url = dialog.FileName;
                img = new HImage(url);
                hw.DisplayImage(img);
                butt.Enabled = false;
                button6.Enabled = false;
            }


            flowControl.Output = img;
        }
        /// <summary>
        /// 加载多图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            img = null;
            isSingle = false;
            var dialog = new OpenFileDialog();
            dialog.Title = "待匹配图像";
            dialog.Filter = "匹配图像|*.png;*.jpg;*.bmp";
            dialog.RestoreDirectory = true;
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var url = dialog.FileNames;
                if (url.Length > 0)
                {
                    butt.Enabled = true;
                    button6.Enabled = true;
                }
                imgs = new HObject[url.Length];
                for (int i = 0; i < url.Length; i++)
                {
                    imgs[i] = new HImage(url[i]);
                }
                hw.DisplayImage(imgs[0]);
            }
            flowControl.Outputs = imgs;
        }
        /// <summary>
        /// 上一张
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butt_Click(object sender, EventArgs e)
        {
            if (currentIndex - 1 < 0)
            {
                currentIndex = 0;
            }

            if (currentIndex > imgs.Length - 1)
            {
                // 从倒数第二张开始
                currentIndex = imgs.Length - 1 - 1;
            }

            hw.DisplayImage(imgs[currentIndex--]);
        }
        /// <summary>
        /// 下一张
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (currentIndex > imgs.Length - 1)
            {
                currentIndex = imgs.Length - 1;
            }

            if (currentIndex - 1 < 0)
            {
                // 从第二张开始
                currentIndex = 1;
            }
            hw.DisplayImage(imgs[currentIndex++]);
        }
        /// <summary>
        /// 测模板匹配结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            set_display_font(hw.HalconWindow, 16, "mono", "true", "false");
            // 根据模板查找图像中的匹配结果
            if (isSingle)
            {
                ModelMath(img);
            }
            else
            {
                timer1.Start();
                timer1.Interval = 1000;
                HOperatorSet.DispText(hw.HalconWindow, "多图匹配测试开始","window", 12, 12, "red", new HTuple(), new HTuple());
            }
        }

        private void ModelMath(HObject L_Image)
        {
            HTuple hv_Score = new HTuple();
            // 通过模板ID定位模板图像位置及角度
            HOperatorSet.FindShapeModel(L_Image, modelId, 0, (new HTuple(360)).TupleRad()
            , 0.5, 1, 0.5, "least_squares", 0, 0.7, out HTuple hv_Row1, out HTuple hv_Column1,
            out HTuple hv_Angle, out hv_Score);
            if (hv_Score.Type == HTupleType.EMPTY)
            {
                HOperatorSet.DispText(hw.HalconWindow, "配置失败","window", 12, 12, "red", new HTuple(), new HTuple());
                return;
            }
            // 创建一个齐次矩阵
            HOperatorSet.HomMat2dIdentity(out HTuple hv_HomMat2DIdentity);
            //模板仿射变换
            HOperatorSet.HomMat2dTranslate(hv_HomMat2DIdentity, hv_Row1, hv_Column1,
                out HTuple hv_HomMat2DTranslate);
            // 旋转
            HOperatorSet.HomMat2dRotate(hv_HomMat2DTranslate, hv_Angle, hv_Row1, hv_Column1,
                out HTuple hv_HomMat2DRotate);
            // 仿射变换轮廓
            HOperatorSet.AffineTransContourXld(modelXld, out HObject ho_ContoursAffineTrans,
                hv_HomMat2DRotate);
            // 显示结果
            HOperatorSet.SetColor(hw.HalconWindow, "red");
            HOperatorSet.SetLineWidth(hw.HalconWindow, 2);
            HOperatorSet.DispObj(L_Image, hw.HalconWindow);
            HOperatorSet.DispObj(ho_ContoursAffineTrans, hw.HalconWindow);
            // 获取轮廓中心
            HOperatorSet.AreaCenterXld(ho_ContoursAffineTrans, out HTuple Area, out HTuple xldRow, out HTuple xldColumn, out HTuple _);
            HOperatorSet.SetColor(hw.HalconWindow, "green");
            HOperatorSet.SetLineWidth(hw.HalconWindow, 1);
            // 绘制十字准星
            HOperatorSet.DispCross(hw.HalconWindow, xldRow, xldColumn, 60, 0);
            HOperatorSet.DispText(hw.HalconWindow, "匹配坐标：(row=" + hv_Row1.TupleString(".2f") + ",column=" + hv_Column1.TupleString(".2f"), "window", 12, 12, "red", new HTuple(), new HTuple());

        }

        #region Halcon自带的方法
        /// <summary>
        /// 设置Halcon窗口显示字体大小的方法
        /// </summary>
        /// <param name="hv_WindowHandle"></param>
        /// <param name="hv_Size"></param>
        /// <param name="hv_Font"></param>
        /// <param name="hv_Bold"></param>
        /// <param name="hv_Slant"></param>
        public void set_display_font(HTuple hv_WindowHandle, HTuple hv_Size, HTuple hv_Font,
            HTuple hv_Bold, HTuple hv_Slant)
        {



            // Local iconic variables 

            // Local control variables 

            HTuple hv_OS = new HTuple(), hv_Fonts = new HTuple();
            HTuple hv_Style = new HTuple(), hv_Exception = new HTuple();
            HTuple hv_AvailableFonts = new HTuple(), hv_Fdx = new HTuple();
            HTuple hv_Indices = new HTuple();
            HTuple hv_Font_COPY_INP_TMP = new HTuple(hv_Font);
            HTuple hv_Size_COPY_INP_TMP = new HTuple(hv_Size);

            // Initialize local and output iconic variables 
            try
            {
                //This procedure sets the text font of the current window with
                //the specified attributes.
                //
                //Input parameters:
                //WindowHandle: The graphics window for which the font will be set
                //Size: The font size. If Size=-1, the default of 16 is used.
                //Bold: If set to 'true', a bold font is used
                //Slant: If set to 'true', a slanted font is used
                //

                HOperatorSet.GetSystem("operating_system", out hv_OS);
                if ((int)((new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                    new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(-1)))) != 0)
                {

                    hv_Size_COPY_INP_TMP = 16;
                }
                if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Win"))) != 0)
                {
                    //Restore previous behavior
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Size = ((1.13677 * hv_Size_COPY_INP_TMP)).TupleInt()
                                ;

                            hv_Size_COPY_INP_TMP = ExpTmpLocalVar_Size;
                        }
                    }
                }
                else
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Size = hv_Size_COPY_INP_TMP.TupleInt()
                                ;

                            hv_Size_COPY_INP_TMP = ExpTmpLocalVar_Size;
                        }
                    }
                }
                if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))) != 0)
                {

                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Courier";
                    hv_Fonts[1] = "Courier 10 Pitch";
                    hv_Fonts[2] = "Courier New";
                    hv_Fonts[3] = "CourierNew";
                    hv_Fonts[4] = "Liberation Mono";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))) != 0)
                {

                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Consolas";
                    hv_Fonts[1] = "Menlo";
                    hv_Fonts[2] = "Courier";
                    hv_Fonts[3] = "Courier 10 Pitch";
                    hv_Fonts[4] = "FreeMono";
                    hv_Fonts[5] = "Liberation Mono";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {

                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Luxi Sans";
                    hv_Fonts[1] = "DejaVu Sans";
                    hv_Fonts[2] = "FreeSans";
                    hv_Fonts[3] = "Arial";
                    hv_Fonts[4] = "Liberation Sans";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {

                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Times New Roman";
                    hv_Fonts[1] = "Luxi Serif";
                    hv_Fonts[2] = "DejaVu Serif";
                    hv_Fonts[3] = "FreeSerif";
                    hv_Fonts[4] = "Utopia";
                    hv_Fonts[5] = "Liberation Serif";
                }
                else
                {

                    hv_Fonts = new HTuple(hv_Font_COPY_INP_TMP);
                }

                hv_Style = "";
                if ((int)(new HTuple(hv_Bold.TupleEqual("true"))) != 0)
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Style = hv_Style + "Bold";

                            hv_Style = ExpTmpLocalVar_Style;
                        }
                    }
                }
                else if ((int)(new HTuple(hv_Bold.TupleNotEqual("false"))) != 0)
                {

                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Slant.TupleEqual("true"))) != 0)
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Style = hv_Style + "Italic";

                            hv_Style = ExpTmpLocalVar_Style;
                        }
                    }
                }
                else if ((int)(new HTuple(hv_Slant.TupleNotEqual("false"))) != 0)
                {

                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Style.TupleEqual(""))) != 0)
                {

                    hv_Style = "Normal";
                }

                HOperatorSet.QueryFont(hv_WindowHandle, out hv_AvailableFonts);

                hv_Font_COPY_INP_TMP = "";
                for (hv_Fdx = 0; (int)hv_Fdx <= (int)((new HTuple(hv_Fonts.TupleLength())) - 1); hv_Fdx = (int)hv_Fdx + 1)
                {

                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_Indices = hv_AvailableFonts.TupleFind(
                            hv_Fonts.TupleSelect(hv_Fdx));
                    }
                    if ((int)(new HTuple((new HTuple(hv_Indices.TupleLength())).TupleGreater(
                        0))) != 0)
                    {
                        if ((int)(new HTuple(((hv_Indices.TupleSelect(0))).TupleGreaterEqual(0))) != 0)
                        {

                            using (HDevDisposeHelper dh = new HDevDisposeHelper())
                            {
                                hv_Font_COPY_INP_TMP = hv_Fonts.TupleSelect(
                                    hv_Fdx);
                            }
                            break;
                        }
                    }
                }
                if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual(""))) != 0)
                {
                    throw new HalconException("Wrong value of control parameter Font");
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    {
                        HTuple
                          ExpTmpLocalVar_Font = (((hv_Font_COPY_INP_TMP + "-") + hv_Style) + "-") + hv_Size_COPY_INP_TMP;

                        hv_Font_COPY_INP_TMP = ExpTmpLocalVar_Font;
                    }
                }
                HOperatorSet.SetFont(hv_WindowHandle, hv_Font_COPY_INP_TMP);

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {

                throw HDevExpDefaultException;
            }
        }

        #endregion
        int index = 0;
        // 定时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            HOperatorSet.DispText(hw.HalconWindow, "", "window", 12, 12, "green", new HTuple(), new HTuple());
            // 获取测量的图像
            if (imgs.Length > 0)
            {
                // 获取需要处理的图片
                var s_img = imgs[index++];
                // 匹配
                ModelMath(s_img);

                if (index == imgs.Length)
                {
                    timer1.Stop();
                    index = 0;
                    HOperatorSet.ClearWindow(hw.HalconWindow);
                    HOperatorSet.DispText(hw.HalconWindow, "多图匹配测试结束","window", 12, 12, "black", new HTuple(), new HTuple());
                }
            }
        }
    }
}
