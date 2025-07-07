using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace MachineVision.Core.TeamplateMatch
{
    /// <summary>
    /// 查找匹配模板参数
    /// </summary>
    public class ShapeFindParamter : BaseParamter
    {
        private double angleStart;
        private double angleExtent;
        private double minScore;
        private int numMatches;
        private double maxOverlap;
        private string subPixel;
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
        /// 子像素精度
        /// </summary>
        public string SubPixel
        {
            get { return subPixel; }
            set
            {
                subPixel = value;
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
           MinScore = 0.5;
           NumMatches = 0;
           MaxOverlap = 0.5;
           SubPixel = "least_squares";
           NumLevels = 0;
           Greediness = 0.9;

        }
    }
}
