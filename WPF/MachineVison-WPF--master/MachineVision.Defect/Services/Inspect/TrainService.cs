using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using MachineVision.Defect.Models;
using System.IO;
using System.Collections.ObjectModel;

namespace MachineVision.Defect.Services
{
    public class TrainService
    {

        private HTuple hv_Smoothness = 25;
        private ProjectModel projectModel;
        private InsectRegionModel regionModel;
        private string imagePath; //模型图片文件路径   项目根目录/项目名称/检测区域/模型图片/图片名称.png

        public TrainService(ProjectModel projectModel,  InsectRegionModel regionModel)
        {
             this.projectModel= projectModel;
             this.regionModel = regionModel;
             imagePath = AppDomain.CurrentDomain.BaseDirectory + $"\\project\\{projectModel.Name}\\训练模型图片\\{regionModel.Name}\\";
            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }
        }

        


        #region 添加训练图片
        /// <summary>
        /// 添加训练图片
        /// </summary>
        /// <param name="image">训练图片</param>
        /// /// <param name="projectModel">项目名称</param>
        /// <param name="regionModel">检测区域</param>
        /// <param name="fileName">保存的模型文件名称</param>
        public void AddTarinImage(
            HObject image,
            string fileName
        )
        {
            string fullPath =imagePath+fileName ;

            
            if(image!=null)
            {
                HOperatorSet.WriteImage(image, "bmp", 0, fullPath);
            }
        }
        #endregion


        #region  获取当前检测区域的所有训练模型图片
       public IList<ImageFileModel> GetImageList()
        {
            IList<ImageFileModel> imageList = new ObservableCollection<ImageFileModel>();

            //获取模型图片路径下的所有图片
            var files=new DirectoryInfo(imagePath).GetFiles();
            foreach(var file in files)
            {
                imageList.Add(new ImageFileModel()
                {
                    ImageName = file.Name,
                    ImagePath = file.FullName,
                });
            }
            return imageList;
        }
        #endregion


        #region 训练差异模型
        /// <summary>
        /// 训练差异模型
        /// </summary>
        /// <param name="imageList">要训练的图片列表</param>
        /// <param name="regionModel">检测区域</param>
        public async Task TrainVariationModel( )
        {

            //获取当前检测区域的所有训练模型图片
            IList<ImageFileModel> imageList = this.GetImageList();

            await Parallel.ForEachAsync(imageList, (item, token) =>
            {
                var image = item.EditImage;
                HOperatorSet.TrainVariationModel(image, regionModel.VariationModelID);

                return ValueTask.CompletedTask;
            });
        }

        #endregion

    }
}
