using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HalconDotNet;
using MachineVision.Defect.Models;
using MachineVision.Defect.Models.Result;
using MachineVision.Shared2.Info;

namespace MachineVision.Defect.Services
{
    /// <summary>
    /// 检测服务类
    /// </summary>
    public class InspectionService
    {
        #region  私有字段
        private string baseDirectory = AppDomain.CurrentDomain.BaseDirectory + $"project\\";

        private HTuple hv_Smoothness = 25;
        #endregion


        #region 获取检测区域参数
        /// <summary>
        /// 获取检测区域参数
        /// </summary>
        /// <param name="drawInfo">已绘制的检测区域范围</param>
        /// <param name="SelectedInspectRegion">当前选中的检测区域</param>
        /// <param name="CurrentProject">当前的项目</param>
        public void GetInsectRegionParamter(
            ReferPointDrawInfo drawInfo,
            InsectRegionModel SelectedInspectRegion,
            ProjectModel CurrentProject
        )
        {
            var paramter = SelectedInspectRegion.RegionParamter;
            paramter.Row1 = drawInfo.HTuples[0];
            paramter.Column1 = drawInfo.HTuples[1];
            paramter.Row2 = drawInfo.HTuples[2];
            paramter.Column2 = drawInfo.HTuples[3];
            paramter.Width = paramter.Row2 - paramter.Row1;
            paramter.Height = paramter.Column2 - paramter.Column1;
            paramter.RowCenter = paramter.Row1 + (paramter.Width / 2);
            paramter.ColumnCenter = paramter.Column1 + (paramter.Height / 2);
            SelectedInspectRegion.RowSpacing =
                paramter.RowCenter - CurrentProject.ReferPointParamtter.RowCenter;
            SelectedInspectRegion.ColumnSpacing =
                paramter.ColumnCenter - CurrentProject.ReferPointParamtter.ColumnCenter;
        }
        #endregion


        #region 获取检测区域的模板图像
        /// <summary>
        /// 获取检测区域模板图像
        /// </summary>
        /// <param name="editImage">正在编辑的图片</param>
        /// <param name="selectedInspectRegion">选中的检测区域</param>
        /// <returns></returns>
        public HObject GetInspectRegionTeamplateImage(
            HImage editImage,
            InsectRegionModel selectedInspectRegion
        )
        {
            var row1 = selectedInspectRegion.RegionParamter.Row1;
            var column1 = selectedInspectRegion.RegionParamter.Column1;
            var row2 = selectedInspectRegion.RegionParamter.Row2;
            var column2 = selectedInspectRegion.RegionParamter.Column2;
            if (row1 == row2 || column1 == column2)
            {
                return null;
            }

            HOperatorSet.GenRectangle1(out HObject rectangle, row1, column1, row2, column2);
            HOperatorSet.ReduceDomain(editImage, rectangle, out HObject teamplateImage);
            HOperatorSet.CropDomain(teamplateImage, out teamplateImage);
            HOperatorSet.Rgb1ToGray(teamplateImage, out teamplateImage);
            return teamplateImage;
        }
        #endregion


        #region  创建局部可形变模板
        /// <summary>
        /// 创建局部可变形模板
        /// </summary>
        /// <returns></returns>
        public HTuple CreateDeformableModle(HObject teamplateImage)
        {
            HOperatorSet.CreateLocalDeformableModel(
                 teamplateImage,
                 "auto",
                 new HTuple(),
                 new HTuple(),
                 "auto",
                 0.9,
                 new HTuple(),
                 "auto",
                 0.9,
                 new HTuple(),
                 "auto",
                 "none",
                 "use_polarity",
                 "auto",
                 "auto",
                 new HTuple(),
                 new HTuple(),
                 out HTuple hv_ModelID
             );

            return hv_ModelID;
        }
        #endregion

        #region 保存可局部形变模板
        public void SaveDeformableModle(
            HObject teamplateImage,
            HTuple modleID,
            string projectName,
            string imageName,
            string modelName
        )
        {
            string basePath = baseDirectory + $"{projectName}\\";
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            string imageFullName = basePath + imageName;
            string modelFullName = basePath + modelName;
            HOperatorSet.WriteImage(teamplateImage, "png", 0, imageFullName);
            HOperatorSet.WriteDeformableModel(modleID, modelFullName);
        }
        #endregion


        #region 创建差异模型
        public HTuple CreateVariationModel(HObject teamplateImage)
        {
            HOperatorSet.GetImageSize(teamplateImage, out HTuple width, out HTuple height);
            HOperatorSet.CreateVariationModel(
                width,
                height,
                "byte",
                "standard",
                out HTuple hv_VriationModelID
            );
            return hv_VriationModelID;
        }
        #endregion



        #region 训练差异模型
       /* public async Task TrainVariationModel(
            IList<ImageFileModel> ImageList,
            InsectRegionModel selectedInsectRegion,
            ProjectModel currentProjectModel
        )
        {
            //创建异步训练任务列表
            *//* List<Task> tasks = new List<Task>();

             //遍历图片对象列表，加入差异模型训练任务列表
             foreach (var item in ImageList)
             {
                 tasks.Add(
                     Task.Run(() =>
                     {
                         var image = item.EditImage;

                         //还原检测区域的坐标参数
                         this.UpdateInspectRegionByReferencePoint(currentProjectModel, image, selectedInsectRegion);
                         HObject ho_ImageReduced = this.GetInspectRegionTeamplateImage(
                             image,
                             selectedInsectRegion
                         );


                         HOperatorSet.FindLocalDeformableModel(
                             ho_ImageReduced,
                             out HObject ho_ImageRectified,
                             out HObject ho_VectorField,
                             out HObject ho_DeformedContours,
                             selectedInsectRegion.RegionParamter.ModleId,
                             -0.39,
                             0.79,
                             0.9,
                             1.2,
                             0.9,
                             1.2,
                             0.89,
                             0,
                             0.8,
                             0,
                             0.9,
                             (
                                 (new HTuple("image_rectified")).TupleConcat("vector_field")
                             ).TupleConcat("deformed_contours"),
                             (
                                 (new HTuple("deformation_smoothness")).TupleConcat("expand_border")
                             ).TupleConcat("subpixel"),
                             hv_Smoothness.TupleConcat((new HTuple(0)).TupleConcat(1)),
                             out HTuple hv_Score,
                             out HTuple hv_Row,
                             out HTuple hv_Column
                         );
                         HOperatorSet.TrainVariationModel(ho_ImageRectified, selectedInsectRegion.VariationModelID);
                     })
                 );
             }

             //等待所有训练任务完成
             await Task.WhenAll(tasks);*//*



            //遍历图片对象列表，进行差异模型训练
            await Parallel.ForEachAsync(
                ImageList,
                (item, token) =>
                {
                    var image = item.EditImage;

                    //还原检测区域的坐标参数
                    this.UpdateInspectRegionByReferencePoint(
                        currentProjectModel,
                        image,
                        selectedInsectRegion
                    );

                    HObject ho_ImageReduced = this.GetInspectRegionTeamplateImage(
                        image,
                        selectedInsectRegion
                    );

                    HOperatorSet.FindLocalDeformableModel(
                        ho_ImageReduced,
                        out HObject ho_ImageRectified,
                        out HObject ho_VectorField,
                        out HObject ho_DeformedContours,
                        selectedInsectRegion.RegionParamter.ModleId,
                        -0.39,
                        0.79,
                        0.9,
                        1.1,
                        0.9,
                        1.1,
                        0.89,
                        0,
                        0.8,
                        0,
                        0.9,
                        ((new HTuple("image_rectified")).TupleConcat("vector_field")).TupleConcat(
                            "deformed_contours"
                        ),
                        (
                            (new HTuple("deformation_smoothness")).TupleConcat("expand_border")
                        ).TupleConcat("subpixel"),
                        hv_Smoothness.TupleConcat((new HTuple(0)).TupleConcat(1)),
                        out HTuple hv_Score,
                        out HTuple hv_Row,
                        out HTuple hv_Column
                    );
                    HOperatorSet.TrainVariationModel(
                        ho_ImageRectified,
                        selectedInsectRegion.VariationModelID
                    );
                    return ValueTask.CompletedTask;
                }
            );
        }*/

       
        #endregion


        #region 保存差异模型
        public void SaveVariationModel(
            HTuple variationModelID,
            string projectName,
            string modelName
        )
        {
            HOperatorSet.GetVariationModel(
                out HObject meanImage,
                out HObject varImage,
                variationModelID
            );
            string modelFullName = baseDirectory + $"{projectName}\\" + modelName;
            HOperatorSet.WriteVariationModel(variationModelID, modelFullName);
        }

        #endregion


        #region 切换新的图片时，通过参考点位置还原检测区域的位置参数
        public void UpdateInspectRegionByReferencePoint(
            ProjectModel projectModel,
            HObject image,
            InsectRegionModel currentRegionModel
        )
        {
            var modelID = projectModel.ReferPointParamtter.ModleId;
            HTuple hv_angleStart = 0;
            HTuple hv_angleExtent = 360;
            HTuple hv_minScore = 0.79;
            HTuple hv_numMatches = 0;
            HTuple hv_maxOverlap = 0.5;
            HTuple hv_subPixel = "true";
            HTuple hv_numLevels = 0;
            HTuple hv_row = null,
                hv_column = null,
                hv_angle = null,
                hv_score = null;

          

            //图像转换为灰度图像，然后进行NCC匹配
            HOperatorSet.Rgb1ToGray(image, out HObject grayImage);

            HOperatorSet.FindNccModel(
                grayImage,
                modelID,
                hv_angleStart,
                hv_angleExtent,
                hv_minScore,
                hv_numMatches,
                hv_maxOverlap,
                hv_subPixel,
                hv_numLevels,
                out hv_row,
                out hv_column,
                out hv_angle,
                out hv_score
            );

            if (hv_score.Length == 1)
            {
                //还原检测区域的中点坐标以及左上角和右下角坐标
                currentRegionModel.RegionParamter.RowCenter =
                    hv_row.DArr[0] + currentRegionModel.RowSpacing;
                currentRegionModel.RegionParamter.ColumnCenter =
                    hv_column.DArr[0] + currentRegionModel.ColumnSpacing;
                currentRegionModel.RegionParamter.Row1 =
                    currentRegionModel.RegionParamter.RowCenter
                    - currentRegionModel.RegionParamter.Width / 2;
                currentRegionModel.RegionParamter.Column1 =
                    currentRegionModel.RegionParamter.ColumnCenter
                    - currentRegionModel.RegionParamter.Height / 2;
                currentRegionModel.RegionParamter.Row2 =
                    currentRegionModel.RegionParamter.RowCenter
                    + currentRegionModel.RegionParamter.Width / 2;
                currentRegionModel.RegionParamter.Column2 =
                    currentRegionModel.RegionParamter.ColumnCenter
                    + currentRegionModel.RegionParamter.Height / 2;
            }
        }

        #endregion


        #region 显示检测区域的检测范围
        public void ShowTestRegion(InsectRegionModel regionModel, HWindow window)
        {
            HOperatorSet.SetColor(window, "green");
            var row1 = regionModel.RegionParamter.Row1;
            var column1 = regionModel.RegionParamter.Column1;
            var row2 = regionModel.RegionParamter.Row2;
            var column2 = regionModel.RegionParamter.Column2;
            HOperatorSet.GenRectangle1(out HObject rectangle, row1, column1, row2, column2);
            HOperatorSet.GenContourRegionXld(rectangle, out HObject contourRegion, "border");
            HOperatorSet.DispObj(contourRegion, window);
        }
        #endregion


        #region 执行检测
        /// <summary>
        /// 执行检测
        /// </summary>
        /// <param name="inspectImage">检测区域的检测图片</param>
        /// <param name="insectRegion">当前的检测区域</param>
        /// <returns></returns>
        public DeformableInspectResult ExcuteInspect(
            HObject inspectImage,
            InsectRegionModel inspectRegion
        )
        {
            //获取变化的差异模型
            HOperatorSet.GetVariationModel(
                out HObject meanImage,
                out HObject varImage,
                inspectRegion.VariationModelID
            );

            //准备差异模型
            HOperatorSet.PrepareVariationModel(inspectRegion.VariationModelID, 40, 2);

            //匹配局部可形变模型
            //查找局部可形变匹配模板
            HOperatorSet.FindLocalDeformableModel(
                inspectImage,
                out HObject ho_ImageRectified,
                out HObject ho_VectorField,
                out HObject ho_DeformedContours,
                inspectRegion.RegionParamter.ModleId,
                -0.39,
                0.79,
                0.9,
                1.2,
                0.9,
                1.2,
                0.89,
                0,
                0.8,
                0,
                0.9,
                ((new HTuple("image_rectified")).TupleConcat("vector_field")).TupleConcat(
                    "deformed_contours"
                ),
                ((new HTuple("deformation_smoothness")).TupleConcat("expand_border")).TupleConcat(
                    "subpixel"
                ),
                hv_Smoothness.TupleConcat((new HTuple(0)).TupleConcat(1)),
                out HTuple hv_Score,
                out HTuple hv_Row,
                out HTuple hv_Column
            );


            //判断和返回检测结果
            return this.GetDeformableInspectResult(hv_Score,inspectImage, ho_ImageRectified, inspectRegion);
        }

        /// <summary>
        /// 获取检测结果
        /// </summary>
        /// <param name="hv_Score">局部可变形模板匹配分数</param>
        /// <param name="ho_ImageRectified">局部可变形模板的纠正后图像</param>
        /// <param name="insectRegion">当前的检测区域</param>
        /// <returns></returns>
        private DeformableInspectResult GetDeformableInspectResult(
            HTuple hv_Score,
            HObject teamplateImage,
            HObject ho_ImageRectified,
            InsectRegionModel insectRegion
        )
        {
            DeformableInspectResult inspectResult = null;
            if (hv_Score.Length == 1)
            {
                //与差异模型进行比较
                HOperatorSet.CompareVariationModel(
                    ho_ImageRectified,
                    out HObject defoambleRegion,
                    insectRegion.VariationModelID
                );

                //连接差异区域
                HOperatorSet.Connection(defoambleRegion, out HObject connectedRegion);

                //对连接的差异区域集合进行筛选
                HOperatorSet.SelectShape(
                    connectedRegion,
                    out HObject SelectedRegions,
                    "area",
                    "and",
                    120,
                    99999
                );

                HOperatorSet.CountObj(SelectedRegions, out HTuple number);
                if (number.D > 0)
                {
                    inspectResult = new DeformableInspectResult()
                    {
                        IsNoDeformable = false,
                        Message = $"{insectRegion.Name}区域结果:NG,缺陷区域数量:{number.D}",
                        DeformableRegion = SelectedRegions,
                        DefomableCount = hv_Score.Length,
                        RectifiedImage = ho_ImageRectified,
                        TeamplateImage=teamplateImage,
                        InspectRegionModel=insectRegion,
                    };
                }
                else
                {
                    inspectResult = new DeformableInspectResult()
                    {
                        IsNoDeformable = true,
                        Message = $"{insectRegion.Name}区域结果:OK,形变区域数量{hv_Score.Length}",
                        DefomableCount=hv_Score.Length,
                        RectifiedImage = ho_ImageRectified,
                        TeamplateImage = teamplateImage,
                        InspectRegionModel = insectRegion,
                    };
                }
            }
            else
            {
                inspectResult = new DeformableInspectResult()
                {
                    IsNoDeformable = true,
                    Message = $"{insectRegion.Name}区域结果:OK,无形变区域",
                    DefomableCount = hv_Score.Length,
                    RectifiedImage = ho_ImageRectified,
                    TeamplateImage = teamplateImage,
                    InspectRegionModel = insectRegion,
                };
            }

            return inspectResult;
        }
        #endregion
    }
}
