using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Core.TeamplateMatch
{
    public class localDeformableFindParamter:BaseParamter
    {
       


        #region FF
        private double angleStart;
        private double angleExtent;
        private double scaleRMin;
        private double scaleRMax;
        private double scaleCMin;
        private double scaleCMax;
        private double minScore;
        private int numMatches;
        private double maxOverlap;
        private int numLevels;
        private double greediness;

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
        /// 行方向最小缩放比例
        /// </summary>
        public double ScaleRMin
        {
            get { return scaleRMin; }
            set { scaleRMin = value; RaisePropertyChanged(); }
        }


        /// <summary>
        /// 行方向最大缩放比例
        /// </summary>
        public double ScaleRMax
        {
            get { return scaleRMax; }
            set { scaleRMax = value; RaisePropertyChanged(); }
        }


        /// <summary>
        /// 列方向最小缩放比例
        /// </summary>
        public double ScaleCMin
        {
            get { return scaleCMin; }
            set { scaleCMin = value; RaisePropertyChanged(); }
        }



        /// <summary>
        /// 列方向最大缩放比例
        /// </summary>
        public double ScaleCMax
        {
            get { return scaleCMax; }
            set { scaleCMax = value; RaisePropertyChanged(); }
        }


        /// <summary>
        /// 最小匹配分数
        /// </summary>
        public double MinScore
        {
            get { return minScore; }
            set
            {
                minScore = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 匹配数量
        /// </summary>
        public int NumMatches
        {
            get { return numMatches; }
            set
            {
                numMatches = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 最大重叠率
        /// </summary>
        public double MaxOverlap
        {
            get { return maxOverlap; }
            set
            {
                maxOverlap = value;
                RaisePropertyChanged();
            }
        }


        /// <summary>
        /// 金字塔层数
        /// </summary>
        public int NumLevels
        {
            get { return numLevels; }
            set
            {
                numLevels = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 贪婪度
        /// </summary>
        public double Greediness
        {
            get { return greediness; }
            set
            {
                greediness = value;
                RaisePropertyChanged();
            }
        }

        public override void InitParamterValue()
        {
            AngleStart = 0;
            AngleExtent = 360;
            ScaleRMin = 1;
            ScaleRMax = 1;
            ScaleCMin = 1;
            ScaleCMax = 1;
            MinScore = 0.5;
            NumMatches = 0;
            MaxOverlap = 1;
            NumLevels = 0;
            Greediness = 0.9;

        }
        #endregion
    }
}
