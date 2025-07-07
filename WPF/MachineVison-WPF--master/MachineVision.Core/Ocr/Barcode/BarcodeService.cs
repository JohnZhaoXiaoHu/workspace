using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using MachineVision.Core.Extension;
using MachineVision.Core.TeamplateMatch;
using MachineVision.Core.TeamplateMatch.Common;
using MachineVision.Core.TeamplateMatch.Extensions;
using Prism.Mvvm;

namespace MachineVision.Core.Ocr
{
    public class BarcodeService : BindableBase
    {
        #region halocn变量
        HObject ho_Image = null,
            ho_SymbolRegions = null;

        // Local control variables

        HTuple hv_BarCodeHandle = new HTuple(),
            hv_WindowHandle = new HTuple();
        HTuple hv_I = new HTuple(),
            hv_DecodedDataStrings = new HTuple();
        HTuple hv_Reference = new HTuple(),
            hv_String = new HTuple();
        HTuple hv_J = new HTuple(),
            hv_Char = new HTuple();
        #endregion

        #region 字段和属性

        private ROIParamter roi;
        public ROIParamter ROI
        {
            get { return roi; }
            set
            {
                roi = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region 构造方法
        public BarcodeService()
        {
            HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.GenEmptyObj(out ho_SymbolRegions);
            HOperatorSet.CreateBarCodeModel(new HTuple(), new HTuple(), out hv_BarCodeHandle);
        }
        #endregion


        #region 方法
        public async Task<OcrMatchResult> FindMatchTeamplate(HObject EditImage,HWindow hWindow)
        {
            OcrMatchResult matchResult = null;

            HObject ReduceImage;
            HOperatorSet.GenEmptyObj(out ReduceImage);
            if (ROI != null) //获取ROI区域的图片
            {
                ReduceImage = ROI.GetROiImage(EditImage);
            }
            else //如果没有ROI则使用原图
            {
                ReduceImage = EditImage;
            }

            var timeSpan =await TimerHelper.GetTimer( () =>
            {
                
                    HOperatorSet.FindBarCode(
                        ReduceImage,
                        out ho_SymbolRegions,
                        hv_BarCodeHandle,
                        "Code 128",
                        out hv_DecodedDataStrings
                    );

                    HOperatorSet.GetBarCodeResult(
                        hv_BarCodeHandle,
                        0,
                        "decoded_reference",
                        out hv_Reference
                    );
                
            });

            hv_String = "";
            HTuple end_val32 = (hv_DecodedDataStrings.TupleStrlen()) - 1;
            HTuple step_val32 = 1;
            for (hv_J = 0; hv_J.Continue(end_val32, step_val32); hv_J = hv_J.TupleAdd(step_val32))
            {
                if (
                    (int)(
                        new HTuple(
                            (
                                (((hv_DecodedDataStrings.TupleStrBitSelect(hv_J))).TupleOrd())
                            ).TupleLess(32)
                        )
                    ) != 0
                )
                {
                    hv_Char.Dispose();
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_Char =
                            "\\x"
                            + (
                                (
                                    (((hv_DecodedDataStrings.TupleStrBitSelect(hv_J))).TupleOrd())
                                ).TupleString("02x")
                            );
                    }
                }
                else
                {
                    hv_Char.Dispose();
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_Char = hv_DecodedDataStrings.TupleStrBitSelect(hv_J);
                    }
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    {
                        HTuple ExpTmpLocalVar_String = hv_String + hv_Char;
                        hv_String.Dispose();
                        hv_String = ExpTmpLocalVar_String;
                    }
                }
            }

            if (!string.IsNullOrEmpty(hv_String))
            {
                matchResult = new OcrMatchResult()
                {
                    IsSuccess = true,
                    Message = $"匹配成功,匹配结果:{hv_String},匹配耗时:{timeSpan}ms",
                    TimeSpan = timeSpan
                };
                if(hWindow != null)
                {
                    HOperatorSet.SetColor(hWindow, "red");
                    HOperatorSet.DispObj(ho_SymbolRegions, hWindow);
                }
            }
            else
            {
                matchResult = new OcrMatchResult() { IsSuccess = false, Message = "未匹配到任何结果!" };
            }
            return matchResult;
        }
        #endregion 


    }
}
