using HalconDotNet;
using MachineVision.Core.Extension;
using MachineVision.Core.TeamplateMatch.Common;
using MachineVision.Core.TeamplateMatch.Extensions;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Core.Ocr
{
    public class QrcodeService:BindableBase
    {
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

        /// <summary>
        /// 二维码识别模型句柄
        /// </summary>
        private HTuple hv_DataCodeHandle;
        #endregion

        #region 构造方法
        public QrcodeService()
        {
            HOperatorSet.CreateDataCode2dModel("QR Code", new HTuple(), new HTuple(), out hv_DataCodeHandle);
        }
        #endregion

        #region 方法
        public async Task<OcrMatchResult> FindMatchTeamplate(HObject EditImage,HWindow hWindow)
        {
            OcrMatchResult matchResult;
            HObject ho_SymbolXLDs;
            HOperatorSet.GenEmptyObj(out ho_SymbolXLDs);
            HTuple hv_DecodedDataStrings=null;
            double timeSpan =await TimerHelper.GetTimer(() => {
                    HOperatorSet.FindDataCode2d(EditImage, out  ho_SymbolXLDs, hv_DataCodeHandle,
                new HTuple(), new HTuple(), out HTuple hv_ResultHandles, out  hv_DecodedDataStrings);
            });
            

            if(!string.IsNullOrEmpty(hv_DecodedDataStrings))
            {
                matchResult = new OcrMatchResult()
                {
                    IsSuccess = true,
                    TimeSpan=timeSpan,
                    Message=$"匹配结果:({hv_DecodedDataStrings}),匹配耗时:{timeSpan}ms"

                };
                if(hWindow!=null)
                {
                    HOperatorSet.SetColor(hWindow, "red");
                    HOperatorSet.DispObj(ho_SymbolXLDs, hWindow);
                }
            }
            else
            {
                matchResult = new OcrMatchResult() { IsSuccess = false, TimeSpan = timeSpan };
            }
            return matchResult;
        }
        #endregion 
    }
}
