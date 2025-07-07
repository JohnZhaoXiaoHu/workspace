using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragVision.Plugin.Params.模版匹配
{
    /// <summary>
    /// 查找形状匹配模板参数
    /// </summary>
    public class FindShapeMatchParam
    {
        /// <summary>
        /// 起始角度
        /// </summary>
        public double AngleStart { get; set; }

        /// <summary>
        /// 角度范围
        /// </summary>
        public double AngleExtent { get; set; }

        private double minScore;

        /// <summary>
        /// 最小分数
        /// </summary>
        public double MinScore
        {
            get { return minScore; }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    minScore = value;
                }
                else
                {
                    throw new Exception("最小分数必须在0-1之间");
                }
            }
        }

        private int maxMatches;

        /// <summary>
        /// 匹配数量
        /// </summary>
        public int NumMatches
        {
            get { return maxMatches; }
            set
            {
                if (value >= 0)
                {
                    maxMatches = value;
                }
                else
                {
                    throw new Exception("匹配数量必须大于等于0");
                }
            }
        }


        private double maxOverlap;
        /// <summary>
        /// 最大重叠率
        /// </summary>
        public double MaxOverlap
        {
            get { return maxOverlap; }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    maxOverlap = value;
                }
                else
                {
                    throw new Exception("最大重叠率必须在0-1之间");
                }
            }
        }

        /// <summary>
        /// 亚像素精度
        /// </summary>
        public string SubPixel { get; set; }

        /// <summary>
        /// 金字塔层数
        /// </summary>
        public int NumLevels { get; set; }



        private double greediness;
        /// <summary>
        /// 贪婪度
        /// </summary>
        public double Greediness
        {
            get { return greediness; }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    greediness = value;
                }
                else
                {
                    throw new Exception("贪婪度必须在0-1之间");
                }
            }
        }
    }
}
