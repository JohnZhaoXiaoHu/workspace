using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using MachineVision.Core.Extension;
using MachineVision.Core.TeamplateMatch.Extensions;
using Prism.Mvvm;

namespace MachineVision.Core.TeamplateMatch.Common.LocalDeformableMatch
{
    public class LocalDeformableService : BindableBase, ITeamplateMatchService
    {
        #region 字段和属性
        private LocalDeformableCreateParamter createParamter;
        private localDeformableFindParamter findParamter;
        private TeamplateMatchResult matchResult;

        private HTuple ho_ModleId;

        private Stopwatch stopwatch;

        private ROIParamter roi;

        /// <summary>
        /// 创建模板参数
        /// </summary>
        public LocalDeformableCreateParamter CreateParamter
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
        public localDeformableFindParamter FindParamter
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
        public LocalDeformableService()
        {
            CreateParamter = new LocalDeformableCreateParamter();
            FindParamter = new localDeformableFindParamter();
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
                //抠出绘制区域的图像
                HOperatorSet.ReduceDomain(EditImage, ho_teamplateImage, out ho_teamplateImage);

                //利用抠出来的区域创建匹配模板
                await Task.Run(() =>
                {
                    HOperatorSet.CreateLocalDeformableModel(
                        ho_teamplateImage,
                        CreateParamter.NumLevels,
                        CreateParamter.AngleStart,
                        CreateParamter.AngleExtent,
                        CreateParamter.AngleStep,
                        CreateParamter.ScaleRMin,
                        CreateParamter.ScaleRMax,
                        CreateParamter.ScaleRStep,
                        CreateParamter.ScaleCMin,
                        CreateParamter.ScaleCMax,
                        CreateParamter.ScaleCStep,
                        CreateParamter.Optimization,
                        CreateParamter.Metric,
                        CreateParamter.Contrast,
                        CreateParamter.MinContrast,
                        new HTuple(),
                        new HTuple(),
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

            if (ho_ModleId == null)
            {
                throw new Exception("请先创建模板");
            }

            HObject ho_ImageRectified = new HObject();
            HObject ho_VectorField = new HObject();
            HObject ho_DeformedContours = new HObject();

            var timeSpan = await TimerHelper.GetTimer(() =>
            {
                HOperatorSet.FindLocalDeformableModel(
                    ReduceImage,
                    out ho_ImageRectified,
                    out ho_VectorField,
                    out ho_DeformedContours,
                    ho_ModleId,
                    FindParamter.AngleStart,
                    FindParamter.AngleExtent,
                    FindParamter.ScaleRMin,
                    FindParamter.ScaleRMax,
                    FindParamter.ScaleCMin,
                    FindParamter.ScaleCMax,
                    FindParamter.MinScore,
                    FindParamter.NumMatches,
                    FindParamter.MaxOverlap,
                    FindParamter.NumLevels,
                    FindParamter.Greediness,
                    new HTuple(),
                    new HTuple(),
                    new HTuple(),
                    out ho_Score,
                    out ho_row,
                    out ho_column
                );
            });

            //获取匹配轮廓

            //清空ROI区域
            ROI = null;

            if (ho_Score != null && ho_Score.Length > 0)
            {
                MatchResult.TimeSpan = timeSpan;
                MatchResult.Results.Clear();
                for (int i = 0; i < ho_Score.Length; i++)
                {


                    MatchResult.Results.Add(
                        new MatchResult()
                        {
                            Index = i + 1,
                            Row = Math.Round(ho_row.DArr[i], 2),
                            Cloumn = Math.Round(ho_column.DArr[i], 2),
                            /*Angle = Math.Round(ho_angle.DArr[i], 2),*/
                            Score = Math.Round(ho_Score.DArr[i], 2),
                            /*Contours = ho_DeformedContours*/
                        }
                    );
                }
               
                //MatchResult.IsSucess = true;
                MatchResult.MatchCount = MatchResult.Results.Count;
            }
            else
            {
                MatchResult.IsSucess = false;
            }

            return MatchResult;
        }
        #endregion
    }
}
