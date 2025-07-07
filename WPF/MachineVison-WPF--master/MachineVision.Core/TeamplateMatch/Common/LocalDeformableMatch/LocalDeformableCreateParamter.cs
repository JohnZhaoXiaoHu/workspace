using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Core.TeamplateMatch
{
    public class LocalDeformableCreateParamter:BaseParamter
    {
        #region  cc
        private int numLevels;
        private double angleStart;
        private double angleExtent;
        private string angleStep;
        private double scaleRMin;
        private double scaleRMax;
        private string scaleRStep;
        private double scaleCMin;
        private double scaleCMax;
        private string scaleCStep;
        private string optimization;
        private string metric;
        private string contrast;
        private string minContrast;
        /* private HObject modelID;*/



        /// <summary>
        /// 金字塔层数
        /// </summary>
        public int NumLevels
        {
            get { return numLevels; }
            set { numLevels = value; RaisePropertyChanged(); }
        }



        /// <summary>
        /// 起始角度
        /// </summary>
        public double AngleStart
        {
            get { return angleStart; }
            set
            {
                angleStart = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 角度范围
        /// </summary>
        public double AngleExtent
        {
            get { return angleExtent; }
            set
            {
                angleExtent = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 角度步长
        /// </summary>
        public string AngleStep
        {
            get { return angleStep; }
            set
            {
                angleStep = value;
                RaisePropertyChanged();
            }
        }




        //行方向图案的最小缩放比例
        public double ScaleRMin
        {
            get { return scaleRMin; }
            set { scaleRMin = value; RaisePropertyChanged(); }
        }



        /// <summary>
        /// 行方向图案的最大缩放比例
        /// </summary>
        public double ScaleRMax
        {
            get { return scaleRMax; }
            set { scaleRMax = value; RaisePropertyChanged(); }
        }



        /// <summary>
        /// 列方向图案的缩放比例步长
        /// </summary>
        public string ScaleRStep
        {
            get { return scaleRStep; }
            set { scaleRStep = value; RaisePropertyChanged(); }
        }



        /// <summary>
        /// 列方向图案的最小缩放比例
        /// </summary>
        public double ScaleCMin
        {
            get { return scaleCMin; }
            set { scaleCMin = value; RaisePropertyChanged(); }
        }



        /// <summary>
        /// 列方向图案的最大缩放比例
        /// </summary>
        public double ScaleCMax
        {
            get { return scaleCMax; }
            set { scaleCMax = value; RaisePropertyChanged(); }
        }



        /// <summary>
        /// 列方向图案的缩放比例步长
        /// </summary>
        public string ScaleCStep
        {
            get { return scaleCStep; }
            set { scaleCStep = value; RaisePropertyChanged(); }
        }


        /// <summary>
        /// 优化方式
        /// </summary>
        public string Optimization
        {
            get { return optimization; }
            set
            {
                optimization = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 度量方式
        /// </summary>
        public string Metric
        {
            get { return metric; }
            set
            {
                metric = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 对比度
        /// </summary>
        public string Contrast
        {
            get { return contrast; }
            set
            {
                contrast = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 最小对比度
        /// </summary>
        public string MinContrast
        {
            get { return minContrast; }
            set
            {
                minContrast = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 模板Id
        /// </summary>
        /* public HObject ModelID
         {
             get { return modelID; }
             set
             {
                 modelID = value;
                 RaisePropertyChanged();
             }
         }*/


        //初始化模板参数
        public override void InitParamterValue()
        {
            NumLevels = 0;
            AngleStart = 0;
            AngleExtent = 360;
            AngleStep = "auto";
            ScaleRMin = 1;
            ScaleRMax = 1;
            ScaleRStep = "auto";
            scaleCMin = 1;
            ScaleCMax = 1;
            ScaleCStep = "auto";
            Optimization = "auto";
            Metric = "use_polarity";
            Contrast = "auto";
            MinContrast = "auto";
        }
        #endregion

    }
}
