using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using Prism.Mvvm;

namespace MachineVision.Defect.Models
{
    public class ImageFileModel : BindableBase
    {
        private string imagePath;
        private string imageName;

        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                RaisePropertyChanged();
            }
        }

     

        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImageName
        {
            get { return imageName; }
            set
            {
                imageName = value;
                RaisePropertyChanged();
            }
        }

       
        /// <summary>
        /// 传递给检测窗口的图片对象
        /// </summary>
        public HImage EditImage
        {
            get { return this.GetHimage(); }  
        }


        /// <summary>
        /// 获取halcon图片对象
        /// </summary>
        /// <returns></returns>
        private HImage GetHimage()
        {
            HImage image = new HImage();
            image.ReadImage(ImagePath);
            return image;
        }
    }
}
