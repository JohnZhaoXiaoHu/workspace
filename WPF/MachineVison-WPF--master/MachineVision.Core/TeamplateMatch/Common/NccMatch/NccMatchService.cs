using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using MachineVision.Core.TeamplateMatch.Common;
using MachineVision.Core.TeamplateMatch.Extensions;
using Prism.Mvvm;

namespace MachineVision.Core.TeamplateMatch
{
    public class NccMatchService : BindableBase, ITeamplateMatchService
    {
        #region 字段和属性
        private NccCreateParamter createParamter;
        private NccFindParamter findParamter;
        private TeamplateMatchResult matchResult;

        private HTuple ho_ModleId;

        private Stopwatch stopwatch;

        private ROIParamter roi;

        /// <summary>
        /// 创建模板参数
        /// </summary>
        public NccCreateParamter CreateParamter
        {
            get { return createParamter; }
            set
            {
                createParamter = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 查找模板参数
        /// </summary>
        public NccFindParamter FindParamter
        {
            get { return findParamter; }
            set
            {
                findParamter = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 匹配结果
        /// </summary>

        public TeamplateMatchResult MatchResult
        {
            get { return matchResult; }
            set
            {
                matchResult = value;
                RaisePropertyChanged();
            }
        }

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
        public NccMatchService()
        {
            CreateParamter = new NccCreateParamter();
            FindParamter = new NccFindParamter();
            CreateParamter.InitParamterValue();
            FindParamter.InitParamterValue();
            MatchResult = new TeamplateMatchResult();
        }
        #endregion



        #region 方法
        /// <summary>
        /// 创建匹配模板
        /// </summary>
        public async Task CreateMachTeamplate(HObject EditImage, HObject ho_teamplateImage)
        {
            try
            {
                //将图像转为灰度图
                HOperatorSet.Rgb1ToGray(EditImage, out EditImage);
                //抠出绘制区域的图像
                HOperatorSet.ReduceDomain(EditImage, ho_teamplateImage, out ho_teamplateImage);

                //利用抠出来的区域创建匹配模板
                await Task.Run(() =>
                {
                    HOperatorSet.CreateNccModel(
                        ho_teamplateImage,
                        CreateParamter.NumLevels,
                        CreateParamter.AngleStart,
                        CreateParamter.AngleExtent,
                        CreateParamter.AngleStep,
                        CreateParamter.Metric,
                        out ho_ModleId
                    );
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"模板创建时出现异常:" + ex.Message);
            }
        }

        /// <summary>
        /// 查找匹配模板
        /// </summary>
        /// <param name="EditImage"></param>
        /// <returns></returns>
        public async Task<TeamplateMatchResult> FindMatchTeamplate(HObject EditImage)
        {
            HObject ReduceImage;
            HOperatorSet.GenEmptyObj(out ReduceImage);

            //将图像转为灰度图
            HOperatorSet.Rgb1ToGray(EditImage, out EditImage);

            if (ROI != null) //获取ROI区域的图片
            {
                ReduceImage = ROI.GetROiImage(EditImage);
            }
            else //如果没有ROI则使用原图
            {
                ReduceImage = EditImage;
            }

            HTuple ho_row = null,
                ho_column = null,
                ho_angle = null,
                ho_Score = null;
            stopwatch = new Stopwatch();
            stopwatch.Start();
            if (ho_ModleId == null)
            {
                throw new Exception("请先创建模板");
            }
            await Task.Run(() =>
            {
                HOperatorSet.FindNccModel(
                    ReduceImage,
                    ho_ModleId,
                    FindParamter.AngleStart,
                    FindParamter.AngleExtent,
                    FindParamter.MinScore,
                    FindParamter.NumMatches,
                    FindParamter.MaxOverlap,
                    FindParamter.SubPixel,
                    FindParamter.NumLevels,
                    out ho_row,
                    out ho_column,
                    out ho_angle,
                    out ho_Score
                );
            });

            stopwatch.Stop();

            //清空ROI区域
            ROI = null;

            if (ho_Score != null && ho_Score.Length > 0)
            {
                MatchResult.TimeSpan = stopwatch.ElapsedMilliseconds;
                MatchResult.Results.Clear();
                for (int i = 0; i < ho_Score.Length; i++)
                {
                    MatchResult.Results.Add(
                        new MatchResult()
                        {
                            Index = i + 1,
                            Row = Math.Round(ho_row.DArr[i], 2),
                            Cloumn = Math.Round(ho_column.DArr[i], 2),
                            Angle = Math.Round(ho_angle.DArr[i], 2),
                            Score = Math.Round(ho_Score.DArr[i], 2),
                            Contours = GetNccContours(
                                ho_ModleId,
                                ho_row.DArr[i],
                                ho_column.DArr[i],
                                ho_angle.DArr[i],
                                0
                            ),
                        }
                    );
                }
                MatchResult.IsSucess = true;
                MatchResult.MatchCount = MatchResult.Results.Count;
            }
            else
            {
                MatchResult.IsSucess = false;
            }

            return MatchResult;
        }
        
        /// <summary>
        /// 获取Ncc模板匹配的轮廓
        /// </summary>
        /// <param name="hv_ModelID"></param>
        /// <param name="hv_Row"></param>
        /// <param name="hv_Column"></param>
        /// <param name="hv_Angle"></param>
        /// <param name="hv_Model"></param>
        /// <returns></returns>
        private HObject GetNccContours(
            HTuple hv_ModelID,
            HTuple hv_Row,
            HTuple hv_Column,
            HTuple hv_Angle,
            HTuple hv_Model
        )
        {
            // Local iconic variables

            HObject ho_ModelRegion = null,
                ho_ModelContours = null;
            HObject ho_ContoursAffinTrans = null,
                ho_Cross = null;

            // Local control variables

            HTuple hv_NumMatches = new HTuple(),
                hv_Index = new HTuple();
            HTuple hv_Match = new HTuple(),
                hv_HomMat2DIdentity = new HTuple();
            HTuple hv_HomMat2DRotate = new HTuple(),
                hv_HomMat2DTranslate = new HTuple();
            HTuple hv_RowTrans = new HTuple(),
                hv_ColTrans = new HTuple();
            HTuple hv_Model_COPY_INP_TMP = new HTuple(hv_Model);

            // Initialize local and output iconic variables
            HOperatorSet.GenEmptyObj(out ho_ModelRegion);
            HOperatorSet.GenEmptyObj(out ho_ModelContours);
            HOperatorSet.GenEmptyObj(out ho_ContoursAffinTrans);
            HOperatorSet.GenEmptyObj(out ho_Cross);
            //This procedure displays the results of Correlation-Based Matching.
            //
            hv_NumMatches.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_NumMatches = new HTuple(hv_Row.TupleLength());
            }
            if ((int)(new HTuple(hv_NumMatches.TupleGreater(0))) != 0)
            {
                if (
                    (int)(
                        new HTuple((new HTuple(hv_Model_COPY_INP_TMP.TupleLength())).TupleEqual(0))
                    ) != 0
                )
                {
                    hv_Model_COPY_INP_TMP.Dispose();
                    HOperatorSet.TupleGenConst(hv_NumMatches, 0, out hv_Model_COPY_INP_TMP);
                }
                else if (
                    (int)(
                        new HTuple((new HTuple(hv_Model_COPY_INP_TMP.TupleLength())).TupleEqual(1))
                    ) != 0
                )
                {
                    {
                        HTuple ExpTmpOutVar_0;
                        HOperatorSet.TupleGenConst(
                            hv_NumMatches,
                            hv_Model_COPY_INP_TMP,
                            out ExpTmpOutVar_0
                        );
                        hv_Model_COPY_INP_TMP.Dispose();
                        hv_Model_COPY_INP_TMP = ExpTmpOutVar_0;
                    }
                }
                for (
                    hv_Index = 0;
                    (int)hv_Index <= (int)((new HTuple(hv_ModelID.TupleLength())) - 1);
                    hv_Index = (int)hv_Index + 1
                )
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        ho_ModelRegion.Dispose();
                        HOperatorSet.GetNccModelRegion(
                            out ho_ModelRegion,
                            hv_ModelID.TupleSelect(hv_Index)
                        );
                    }
                    ho_ModelContours.Dispose();
                    HOperatorSet.GenContourRegionXld(
                        ho_ModelRegion,
                        out ho_ModelContours,
                        "border_holes"
                    );

                    HTuple end_val13 = hv_NumMatches - 1;
                    HTuple step_val13 = 1;
                    for (
                        hv_Match = 0;
                        hv_Match.Continue(end_val13, step_val13);
                        hv_Match = hv_Match.TupleAdd(step_val13)
                    )
                    {
                        if (
                            (int)(
                                new HTuple(
                                    hv_Index.TupleEqual(hv_Model_COPY_INP_TMP.TupleSelect(hv_Match))
                                )
                            ) != 0
                        )
                        {
                            hv_HomMat2DIdentity.Dispose();
                            HOperatorSet.HomMat2dIdentity(out hv_HomMat2DIdentity);
                            using (HDevDisposeHelper dh = new HDevDisposeHelper())
                            {
                                hv_HomMat2DRotate.Dispose();
                                HOperatorSet.HomMat2dRotate(
                                    hv_HomMat2DIdentity,
                                    hv_Angle.TupleSelect(hv_Match),
                                    0,
                                    0,
                                    out hv_HomMat2DRotate
                                );
                            }
                            using (HDevDisposeHelper dh = new HDevDisposeHelper())
                            {
                                hv_HomMat2DTranslate.Dispose();
                                HOperatorSet.HomMat2dTranslate(
                                    hv_HomMat2DRotate,
                                    hv_Row.TupleSelect(hv_Match),
                                    hv_Column.TupleSelect(hv_Match),
                                    out hv_HomMat2DTranslate
                                );
                            }
                            ho_ContoursAffinTrans.Dispose();
                            HOperatorSet.AffineTransContourXld(
                                ho_ModelContours,
                                out ho_ContoursAffinTrans,
                                hv_HomMat2DTranslate
                            );

                            hv_RowTrans.Dispose();
                            hv_ColTrans.Dispose();
                            HOperatorSet.AffineTransPixel(
                                hv_HomMat2DTranslate,
                                0,
                                0,
                                out hv_RowTrans,
                                out hv_ColTrans
                            );
                            using (HDevDisposeHelper dh = new HDevDisposeHelper())
                            {
                                ho_Cross.Dispose();
                                HOperatorSet.GenCrossContourXld(
                                    out ho_Cross,
                                    hv_RowTrans,
                                    hv_ColTrans,
                                    6,
                                    hv_Angle.TupleSelect(hv_Match)
                                );
                            }
                            if (HDevWindowStack.IsOpen())
                            {
                                HOperatorSet.DispObj(ho_Cross, HDevWindowStack.GetActive());
                            }
                        }
                    }
                }
            }
            ho_ModelRegion.Dispose();
            ho_ModelContours.Dispose();
            ho_Cross.Dispose();

            hv_Model_COPY_INP_TMP.Dispose();
            hv_NumMatches.Dispose();
            hv_Index.Dispose();
            hv_Match.Dispose();
            hv_HomMat2DIdentity.Dispose();
            hv_HomMat2DRotate.Dispose();
            hv_HomMat2DTranslate.Dispose();
            hv_RowTrans.Dispose();
            hv_ColTrans.Dispose();

            return ho_ContoursAffinTrans;
        }

        #endregion
    }
}
