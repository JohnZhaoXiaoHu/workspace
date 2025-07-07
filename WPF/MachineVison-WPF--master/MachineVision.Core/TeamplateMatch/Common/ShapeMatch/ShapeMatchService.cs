using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HalconDotNet;
using MachineVision.Core.TeamplateMatch.Common;
using MachineVision.Core.TeamplateMatch.Extensions;
using Prism.Mvvm;

namespace MachineVision.Core.TeamplateMatch
{
   

    /// <summary>
    /// 模板匹配服务
    /// </summary>
    public class ShapeMatchService : BindableBase, ITeamplateMatchService
    {
        #region 字段和属性
        private ShapeCreateParamter createParamter;
        private ShapeFindParamter findParamter;
        private TeamplateMatchResult matchResult;

        private HTuple ho_ModleId;

        private Stopwatch stopwatch;

        private ROIParamter roi;

        /// <summary>
        /// 创建模板参数
        /// </summary>
        public ShapeCreateParamter CreateParamter
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
        public ShapeFindParamter FindParamter
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
        public ShapeMatchService()
        {
            CreateParamter = new ShapeCreateParamter();
            FindParamter = new ShapeFindParamter();
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
                    HOperatorSet.CreateShapeModel(
                        ho_teamplateImage,
                        CreateParamter.NumLevels,
                        CreateParamter.AngleStart,
                        CreateParamter.AngleExtent,
                        CreateParamter.AngleStep,
                        CreateParamter.Optimization,
                        CreateParamter.Metric,
                        CreateParamter.Contrast,
                        CreateParamter.MinContrast,
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
            if(ROI!=null)//获取ROI区域的图片
            {
                ReduceImage = ROI.GetROiImage(EditImage);
            }
            else//如果没有ROI则使用原图
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
                HOperatorSet.FindShapeModel(
                    ReduceImage,
                    ho_ModleId,
                    FindParamter.AngleStart,
                    FindParamter.AngleExtent,
                    FindParamter.MinScore,
                    FindParamter.NumMatches,
                    FindParamter.MaxOverlap,
                    FindParamter.SubPixel,
                    FindParamter.NumLevels,
                    FindParamter.Greediness,
                    out ho_row,
                    out ho_column,
                    out ho_angle,
                    out ho_Score
                );
            });

            stopwatch.Stop();

            //清空ROI区域
             ROI = null;

            //获取形状模板的轮廓
            HOperatorSet.GetShapeModelContours(out HObject ho_ModelContours, ho_ModleId, 1);

            if (ho_Score != null && ho_Score.Length > 0)
            {
                MatchResult.TimeSpan = stopwatch.ElapsedMilliseconds;
                MatchResult.Results.Clear();
                for (int i = 0; i < ho_Score.Length; i++)
                {
                    //计算轮廓匹配的目标位置对象,从点对应关系和角度计算刚性仿射变换
                    HOperatorSet.VectorAngleToRigid(
                        0,
                        0,
                        0,
                        ho_row.DArr[i],
                        ho_column.DArr[i],
                        ho_angle.DArr[i],
                        out HTuple ho_HomMat2D
                    );

                    //计算仿射变换后的轮廓
                    HOperatorSet.AffineTransContourXld(
                        ho_ModelContours,
                        out HObject ho_TransContours,
                        ho_HomMat2D
                    );

                    MatchResult.Results.Add(
                        new MatchResult()
                        {
                            Index = i + 1,
                            Row = Math.Round(ho_row.DArr[i],2),
                            Cloumn = Math.Round(ho_column.DArr[i],2),
                            Angle = Math.Round(ho_angle.DArr[i],2),
                            Score = Math.Round(ho_Score.DArr[i],2),
                            Contours = ho_TransContours
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
        #endregion
    }
}
